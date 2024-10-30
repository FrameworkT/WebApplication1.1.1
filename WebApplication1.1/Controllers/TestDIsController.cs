using Microsoft.AspNetCore.Mvc;
using WebApplication1._1.Services;

namespace WebApplication1._1.Controllers
{
    public class TestDIsController : Controller
    {
        private readonly ITestDI test1;
        private readonly ITestDI test2;

        public TestDIsController(ITestDI test1,ITestDI test2) //DI
        {
            this.test1 = test1;
            this.test2 = test2;
        }
        public IActionResult Index()
        {
            var id1 = test1.GenId();
            var id2 = test2.GenId();

            var showTestDI = $"{id1}    {id2}";

            return View(new {showTestDI} );
        }
    }
}
