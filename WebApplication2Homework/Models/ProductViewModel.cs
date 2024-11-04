using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2Homework.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<string> Images { get; set; } // Property เพื่อใช้แสดงรูปภาพในหน้า View
    }
}