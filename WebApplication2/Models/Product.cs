using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public ProductExtend ProductExtend { get; set; } //ต้องมี[Owned]

        public int CategoryId { get; set; } //กุญเเจ เป็นลักษณะเฉพาะ foren key คีย์นอก 1 to m
        public Category Category { get; set; } //คู่กัน 

        //public int XXXID { get; set; } //กุญเเจ เป็นลักษณะเฉพาะ foren key คีย์นอก 1 to m
        //[ForeignKey("XXXID")]
        //public Category Category { get; set; } //คู่กัน 

        public List<ProductDetails> ProductDetails { get; set; }
    }
}
