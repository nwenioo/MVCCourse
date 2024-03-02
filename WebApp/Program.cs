using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//inject methods to support controller with view
builder.Services.AddControllersWithViews(); 
var app = builder.Build();

//to use lib file for ui 
app.UseStaticFiles();
//use mvc routing 
app.UseRouting();
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
