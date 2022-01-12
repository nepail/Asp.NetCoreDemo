using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreDemo.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
