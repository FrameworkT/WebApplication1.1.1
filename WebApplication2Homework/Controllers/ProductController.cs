using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2Homework.Service;

namespace WebApplication2Homework._1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ns;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService ns, ICategoryService categoryService)
        {
            this.ns = ns;
            this.categoryService = categoryService; // เพิ่มบริการจัดการหมวดหมู่
        }

        public IActionResult Index(string keyword)
        {
            var products = ns.GetAll(keyword);

            // Grouping โดยใช้ GroupBy
            var groupedProducts = products
                .GroupBy(p => p.category != null ? p.category.Name : "ไม่มีหมวดหมู่")
                .Select(g => new
                {
                    CategoryName = g.Key,
                    Products = g.ToList()
                })
                .ToList();

            return View(groupedProducts);
        }

        [HttpGet]
        public IActionResult UpCreate(int? id)
        {
            var model = new ProductViewModel
            {
                Categories = categoryService.GetAll(null)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList()
            };

            if (id.HasValue)
            {
                var product = ns.SearchData(id.Value);
                if (product != null)
                {
                    model.Product = product;
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                // ถ้า id เป็น null ให้สร้าง Product ใหม่
                model.Product = new Product();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpCreate(Product product, IFormFile file)
        {
            if (product.Id == 0)
            {
                ns.AddData(product, file);
            }
            else
            {
                ns.UpdateData(product, file);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            ns.DeleteData(id);
            return RedirectToAction("Index");
        }

    }
}
