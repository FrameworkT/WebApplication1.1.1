using Microsoft.AspNetCore.Mvc;
using WebApplication2Homework.Service;

namespace WebApplication2Homework.Controllers
{
    public class ProductController : Controller
    {
         private readonly IProductServices ns;

        public ProductController(IProductServices ns)
        {
            this.ns = ns;
        }

        public IActionResult Index(string? keyword)
        {
            var products = ns.GetAll(keyword);
            return View(products);
        }

        public IActionResult UpCreate()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult UpCreate(Product product)
        {
            if (product.Id == 0)
                ns.AddData(product);
            else
                ns.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            ns.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}

