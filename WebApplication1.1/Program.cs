global using WebApplication1._1.Models;
using WebApplication1._1.Data;
using WebApplication1._1.Services;
using WebApplication1._1.Services.New;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductService, ProductService>();

//builder.Services.AddSingleton<ITestDI, TestDI>(); //เปลี่ยนไม่ได้
/*builder.Services.AddScoped<ITestDI, TestDI>();*/ //เปลี่ยนำได้เหมือนกัน
builder.Services.AddTransient<ITestDI, TestDI>(); //เปลี่ยนได้ไม่เหมือนกัน

builder.Services.AddDbContext<DataContext>(); //ลงทะเบียน
builder.Services.AddScoped<INewProductService,NewProductService>(); //ลงทะเบียน

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
