using EMS.Services.Implementation.ADO;
using EMS.IServices;
using EMS.Services;
using EMS.DataAccess.ADO;
using EMS.Services.Implementation;
using EMS.IDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//MVC pattern
//Add EMS.Services and EMS.DataAccess classes as references
//builder.Services.Add(b)
// Add EMS.DataAccess.EMSDbContext as a singleton service

builder.Services.AddScoped<ICompanyService,CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentADOService>();
builder.Services.AddScoped<IEmployeeService, EmployeeADOService>();
     

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

//app.MapControllerRoute(
//    name: "default1",
//    pattern: "iconnect/{action}/{controller}/abc");

app.Run();

//locahsot:2323/ Company/a1
//CompanyController
//       A1 locahsot:2323 / Company / a1, locahsot: 2323 / iconnect /A1/ Company / abc
//       A2
