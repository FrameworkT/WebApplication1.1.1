namespace WebApplication1._1.Services.New
{
    public interface INewProductService
    {
        List<Product> GetAll(string keyword); //return ออกไปทั้งหมด
        void AddData(Product product,IFormFile file); //พารามิเตอร์
        Product SearchData(int id);
        void UpdateData(Product product,IFormFile file);
        void DeleteData(int id);

    }
}
