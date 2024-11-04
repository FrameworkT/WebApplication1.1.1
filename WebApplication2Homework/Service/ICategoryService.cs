namespace WebApplication2Homework.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll(string keyword);
        void AddData(Category category);
        Category SearchData(int id);
        void UpdateData(Category category);
        void DeleteData(int id);
    }
}