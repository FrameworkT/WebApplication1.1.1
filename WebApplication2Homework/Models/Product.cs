using System.ComponentModel.DataAnnotations;

namespace WebApplication2Homework.Models
{
    public class Product
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "ชื่อผลิตภัณฑ์จำเป็นต้องกรอก")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ราคาเป็นข้อมูลจำเป็น")]
        public double Price { get; set; }
        public int Amount { get; set; }
        public string? Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }// ชื่อไฟล์ สร้างforeing key
        public Category category { get; set; }//ความสำพันธ์ 1:m


    }
}