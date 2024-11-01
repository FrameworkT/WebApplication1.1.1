namespace WebApplication2Homework.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; } //กุญเเจ เป็นลักษณะเฉพาะ foren key คีย์นอก 1 to m
        public Category Category { get; set; } //คู่กัน 
    }
}
