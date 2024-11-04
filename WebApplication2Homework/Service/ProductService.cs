
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication2Homework.Data;
public class ProductService : IProductService
{
    private readonly Datacontext db;
    private readonly IWebHostEnvironment webEnv;

    public ProductService(Datacontext db, IWebHostEnvironment webEnv)
    {
        this.db = db;
        this.webEnv = webEnv;
    }

    public List<Product> GetAll(string keyword)
    {
        keyword = keyword?.ToUpper();

        // ใช้ Include เพื่อโหลด Category ที่เกี่ยวข้อง
        var query = db.Products.Include(p => p.category).AsQueryable();

        // การค้นหาผลิตภัณฑ์ตาม keyword
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(px => px.Name.ToUpper().Contains(keyword));
        }

        // เรียงลำดับและแปลงเป็น List
        return query.OrderByDescending(px => px.Id).ToList();
    }

    public  void AddData(Product product, IFormFile file)
    {
        string wwwRootPath = webEnv.WebRootPath;
        if (file != null)
        {
            string fileName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);
            var uploads = Path.Combine(wwwRootPath, "images");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
            //แบบที่ 1 บันทึกรุปภาพใหม่(เป็นไฟล์ภายนอก database)
            using (var fileStreams = new FileStream(Path.Combine(uploads,fileName + extension), FileMode.Create))
            {
                file.CopyTo(fileStreams);
            }
            product.Image = @"\images\" + fileName + extension;
        }
         db.Products.Add(product);
         db.SaveChanges();
    }


    public Product SearchData(int id)
    {
        return db.Products.Include(p => p.category).FirstOrDefault(p => p.Id == id);
    }

    //public void UpdateData(Product product, IFormFile file)
    //{
    //    db.Products.Update(product, file);
    //    db.SaveChanges();
    //}

    public void DeleteData(int id)
    {
        var product = SearchData(id);

        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }

    public IEnumerable<Category> GetCategories() => db.categories.ToList();
    
    
}
