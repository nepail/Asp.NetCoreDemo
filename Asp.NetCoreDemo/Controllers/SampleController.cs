using Asp.NetCoreDemo.Models.Interfaces;
using Asp.NetCoreDemo.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreDemo.Controllers
{
    public class SampleController : Controller
    {
        private readonly ISample _transient;
        private readonly ISample _scoped;
        private readonly ISample _singleton;
        private readonly SampleService _service;

        public SampleController(ITransient transient, IScoped scoped, ISingleton singleton, SampleService service)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IDictionary<string, string>> Get()
        {
            var serviceHashCode = _service.GetSampleHashCode();
            var controllerHashCode = $"Transient: {_transient.GetHashCode()}," +
                                     $"Scoped: {_scoped.GetHashCode()}," +
                                     $"Singleton: {_singleton.GetHashCode()}";

            return new Dictionary<string, string>
            {
                { "Service", serviceHashCode },
                {"Contorller", controllerHashCode }
            };
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
