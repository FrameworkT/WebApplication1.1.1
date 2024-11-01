namespace WebApplication2Homework.Service
{
    public interface IProductServices
    {
        List<Product> GetAll(string keyword);
        void AddData(Product product);
        void AddProduct(Product products);

        void Update(Product products);

        Product SerchData(int id);

        void DeleteData(int id);

        IEnumerable<Category> GetCategories();

        IEnumerable<IGrouping<Category, Product>> GetProductsGroupedByCategory();
    }
}

