namespace WebApplication2.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public int ComponentId { get; set; } 1 to 1 ห้ามใส่คีย์อีกจะเกิด loop
        public Component Component { get; set; } //เชื่อม component
    }
}
