using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BengkelMotorApp.Areas.Identity.Data;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using BengkelMotorApp.Service;
using BengkelMotorApp.Service.Implement;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<UserIdentity>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddScoped<ISparePartService, SparePartService>();
builder.Services.AddScoped<IServiceTypeService, ServiceTypeService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IViewEngine, RazorViewEngine>();
builder.Services.AddScoped<IOptionService, OptionService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();
{
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

    app.MapRazorPages();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

    // create roles
    //using (var scope = app.Services.CreateScope())
    //{
    //    // get role manager
    //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    //    // create roles
    //    var roles = new[] { "Admin", "Customer" };
    //    foreach (var role in roles)
    //    {
    //        if (!roleManager.RoleExistsAsync(role).Result)
    //        {
    //            var result = roleManager.CreateAsync(new IdentityRole(role)).Result;
    //            if (!result.Succeeded)
    //            {
    //                throw new Exception(string.Join("\n", result.Errors));
    //            }
    //        }
    //    }

    //    // create admin
    //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    //    var admin = userManager.FindByNameAsync("admin").Result;
    //    if (admin == null)
    //    {
    //        admin = new IdentityUser("admin");
    //        var result = userManager.CreateAsync(admin, "Admin123!").Result;
    //        if (!result.Succeeded)
    //        {
    //            throw new Exception(string.Join("\n", result.Errors));
    //        }
    //    }
    //}
}