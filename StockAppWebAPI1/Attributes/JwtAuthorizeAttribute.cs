using Microsoft.AspNetCore.Mvc;

namespace StockAppWebAPI1.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeAttribute))
        {
        }
    }
}
