using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication2Homework.Data;

public class ProductService : IProductService
{
    private readonly Datacontext db;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(Datacontext db, IWebHostEnvironment webHostEnvironment)
    {
        this.db = db;
        _webHostEnvironment = webHostEnvironment;
    }

    public List<Product> GetAll(string keyword)
    {
        keyword = keyword?.ToUpper();

        // ใช้ Include เพื่อโหลด Category ที่เกี่ยวข้อง
        var query = db.Products.Include(p => p.category).AsQueryable();
        //var products = db.Products.OrderByDescending(px => px.Id).ToList();
        // การค้นหาผลิตภัณฑ์ตาม keyword
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(px => px.Name.ToUpper().Contains(keyword)
                                   );
        }

        // เรียงลำดับและแปลงเป็น List
        return query.OrderByDescending(px => px.Id).ToList();
    }


    public void AddData(Product product, IFormFile file)
    {
        db.Products.Add(product);
        db.SaveChanges();
    }

    public Product SearchData(int id)
    {
        return db.Products.Find(id);
    }

    public void UpdateData(Product product, IFormFile file)
    {
        db.Products.Update(product);
        db.SaveChanges();
    }

    public void DeleteData(int id)
    {
        var product = SearchData(id);

        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();
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
}
    
