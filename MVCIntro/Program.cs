using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCIntro.DAL.AppDbContext>
(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute
(

    name:"admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

);
app.MapControllerRoute
(

    name:"default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

);

app.Run();
