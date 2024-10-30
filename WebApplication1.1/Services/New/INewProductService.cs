namespace WebApplication1._1.Services.New
{
    public interface INewProductService
    {
        List<Product> GetAll(string keyword); //return ออกไปทั้งหมด
        void AddData(Product product); //พารามิเตอร์
        Product SearchData(int id);
        void UpdateData(Product product);
        void DeleteData(int id);

    }
}
