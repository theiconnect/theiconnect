using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using EMS.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//MVC pattern
//Add EMS.Services and EMS.DataAccess classes as references
//builder.Services.Add(b
// Add EMS.DataAccess.EMSDbContext as a singleton service

builder.Services.AddScoped<ICompanyService, CompanyTDService>();
builder.Services.AddScoped<IDepartmentService, DepartmentTDService>();
builder.Services.AddScoped<IEmployeeService, EmployeeTDServices>();
     

//builder.Services.AddScoped<IEmployeeService,>();
//builder.Services.AddTransient<EMS.Services.CompanyService>();
//builder.Services.AddSingleton<EMS.Services.CompanyService>();

//=======================================================================
//Middle ware - Request pipeline configuration
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

//Conventional Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Demo}/{action=CascadingDropdowns}/{id?}");

WebApplication app1 = app;

app1.Run();

//locahsot:2323/ Company/a1
//CompanyController
//       A1 locahsot:2323 / Company / a1, locahsot: 2323 / iconnect /A1/ Company / abc
//       A2
