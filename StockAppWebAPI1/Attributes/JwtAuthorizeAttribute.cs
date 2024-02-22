using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI1.Filters;

namespace StockAppWebAPI1.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
        {
        }
    }
}
