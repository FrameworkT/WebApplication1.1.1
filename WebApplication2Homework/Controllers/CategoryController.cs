using Microsoft.AspNetCore.Mvc;
using WebApplication2Homework.Service;

public class CategoryController : Controller
{
    private readonly ICategoryService ns;

    public CategoryController(ICategoryService ns)
    {
        this.ns = ns;
    }

    public IActionResult Index(string keyword)
    {
        var Categorys = ns.GetAll(keyword);
        return View(Categorys);
    }

    public IActionResult UpCreate(int? id)
    {
        if (id == null)
        {
            //addd
        }
        else
        {
            //update
            var Categorys = ns.SearchData(id.Value);
            if (Categorys != null)
            {
                return View(Categorys);
            }
            return RedirectToAction("Index");

        }

        return View(new Category());
    }

    [HttpPost]
    public IActionResult UpCreate(Category category)
    {
        if (category.Id == 0)
            ns.AddData(category);
        else
            ns.UpdateData(category);

        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        ns.DeleteData(id);
        return RedirectToAction("Index");
    }

}
