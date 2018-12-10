using Microsoft.AspNetCore.Antiforgery;
using ebus.Controllers;

namespace ebus.Web.Host.Controllers
{
    public class AntiForgeryController : ebusControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
