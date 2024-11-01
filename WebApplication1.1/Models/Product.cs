using System.ComponentModel.DataAnnotations;

namespace WebApplication1._1.Models
{
    public class Product
    {
        [Required(ErrorMessage ="กรุณากรอกข้อมูล")]
        [Display(Name = "รหัสสินค้า")]
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Name { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [Range(1, 999, ErrorMessage = "กรุณากรอกราคาระหว่าง {1} ถึง {2}")]
        public double Price { get; set; }

        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int Amount { get; set; }
        public string? Image { get; set; } = string.Empty;
        public string? ImageBase64 { get; set; } = string.Empty;
    }
}
