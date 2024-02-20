using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StockAppWebAPI1.Filters
{
    public class JwtAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _config;
        public JwtAuthorizeFilter(IConfiguration config)
        {
            _config = config;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var tokenHander = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("Jwt:SecretKey") ?? "");
            try
            {
                tokenHander.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //Nếu token hết hạn,
                    //thì khi gọi phương thức ValidateToken,
                    //mã lỗi SecurityTokenExpiredException sẽ được throw ra
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken.ValidTo > DateTime.UtcNow)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                var userId = int.Parse(jwtToken.Claims.First().Value);
                context.HttpContext.Items["userId"] = userId;
            }
            catch
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
