
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContentMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
