using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCIntro.DAL;
using MVCIntro.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCIntro.DAL.AppDbContext>
(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);
builder.Services.AddIdentity<AppUser, IdentityRole>(opt=>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;

    opt.User.RequireUniqueEmail = true;
    opt.Lockout.AllowedForNewUsers = true;
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
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
