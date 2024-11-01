namespace WebApplication2.Models
{
    public class ComponentProduct
    {
        //public int Id { get; set; } M:M กำหนด pimary key ด้วย key เดียวก็ได้
        public int ComponentId { get; set; } // //เป็น Pimary key
        public Component Component { get; set; }
        public int ProductId { get; set; } //เป็น Pimary key
        public Product Product { get; set; }
    }
}
