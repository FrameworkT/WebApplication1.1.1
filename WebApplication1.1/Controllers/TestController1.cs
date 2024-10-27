using Microsoft.AspNetCore.Mvc;

namespace WebApplication1._1.Controllers
{
    public class TestController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show()
        {
            int[] data = [ 1, 2, 3,4,5,6 ];
            return View();
        }

    }
}
