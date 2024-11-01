using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using WebApplication1._1.Data;

namespace WebApplication1._1.Services.New
{
    public class NewProductService : INewProductService
    {
        private readonly DataContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewProductService(DataContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Product> GetAll(string keyword)
        {
            var products = _dbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                var upperKeyword = keyword.ToUpper();
                products = products.Where(px => px.Name.ToUpper().Contains(upperKeyword) ||
                                                  px.Price.ToString().Contains(upperKeyword));
            }

            return products.OrderByDescending(px => px.Id).ToList();
        }

        public void AddData(Product product, IFormFile file)
        {
            if (file != null)
                SaveFile(product, file);

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public Product SearchData(int id) => _dbContext.Products.Find(id);

        public void UpdateData(Product product, IFormFile file)
        {
            if (file != null)
            {
                DeleteOldImage(product);
                SaveFile(product, file);
            }

            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void DeleteData(int id)
        {
            var product = SearchData(id);
            if (product != null)
            {
                DeleteOldImage(product);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        private void SaveFile(Product product, IFormFile file)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            product.Image = "/images/" + fileName;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                product.ImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
            }
        }

        private void DeleteOldImage(Product product)
        {
            if (!string.IsNullOrEmpty(product.Image))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.Image.TrimStart('/'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
        }
    }
}
