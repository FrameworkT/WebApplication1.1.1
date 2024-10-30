using Microsoft.AspNetCore.Mvc;
using WebApplication1._1.Models;
using WebApplication1._1.Services;

namespace WebApplication1._1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService ps;

        public ProductsController(IProductService ps)
        {
            this.ps = ps;
        }
        public IActionResult Index()
        {
            return View(ps.GetProducts());
        }
        public IActionResult Delete(int id)
        {

            ps.DeleteData(id);

            return RedirectToAction("Index");
        }
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                //create
                ProductService.IsCreate = true;
            }
            else
            {
                //update
                ProductService.IsCreate = false;
                var updateProduct = ps.SearchProduct(id.Value);
                return View(updateProduct);
            }
            return View();
        }
        [HttpPost] //attribute คุณสมบัติ Post ต้องการเพิ่มข้อมูล put เเก้ไข delete ลบ get อ่าน 
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (ProductService.IsCreate)
                {
                    //Create
                    //ถูกต้อง
                    var exist = ps.AddData(product);
                    if (!exist) return RedirectToAction("Index"); //ถ้าไม่ซ้ำ

                    TempData["alert"] = "คุณตั้งรหัสซ้ำ";
                }

                else
                {
                    //Update
                    ps.UpdateData(product);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}