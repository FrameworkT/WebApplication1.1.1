namespace WebApplication2Homework.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll(string keyword);
        void AddData(Category category);
        void AddCategory(Category category);

        void Update(Category category);

        Category SerchData(int id);

        void DeleteData(int id);

    }
}
