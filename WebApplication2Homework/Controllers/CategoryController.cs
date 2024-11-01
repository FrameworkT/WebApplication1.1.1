using Microsoft.AspNetCore.Mvc;
using WebApplication2Homework.Service;

namespace WebApplication2Homework.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService ns;

        public CategoryController(ICategoryService ns)
        {
            this.ns = ns;
        }
        public IActionResult Index(string? keyword)
        {
            var category = ns.GetAll(keyword);
            return View(category);
        }
		public IActionResult UpCreate()
		{
			return View(new Category());
		}

		[HttpPost]
		public IActionResult UpCreate(Category category)
		{
			if (category.Id == 0)
				ns.AddData(category);
			else
				ns.Update(category);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			ns.DeleteData(id);
			return RedirectToAction("Index");
		}
		
	}
}
