using Microsoft.AspNetCore.Mvc;
using WebApplication1._1.Services.New;

namespace WebApplication1._1.Controllers
{
    public class NewProductController : Controller
    {
        private readonly INewProductService _productService;

        public NewProductController(INewProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string? keyword)
        {
            var products = _productService.GetAll(keyword);
            return View(products);
        }

        public IActionResult UpCreate(int? id)
        {
            var product = id.HasValue ? _productService.SearchData(id.Value) : new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult UpCreate(Product product, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                    _productService.AddData(product, file);
                else
                    _productService.UpdateData(product, file);

                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            _productService.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
