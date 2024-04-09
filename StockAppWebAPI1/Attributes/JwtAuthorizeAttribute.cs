using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI11.Filters;

namespace StockAppWebAPI11.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
        {
        }
    }
}
