using EMS.DataAccess.ADO;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Services.Implementation;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region OLD CODE
//MVC pattern
//Add EMS.Services and EMS.DataAccess classes as references
//builder.Services.Add(b
// Add EMS.DataAccess.EMSDbContext as a singleton service

//builder.Services.AddScoped<ICompanyService, CompanyTDService>();
//builder.Services.AddScoped<IDepartmentService, DepartmentADOService>();
//builder.Services.AddScoped<IEmployeeService, EmployeeADOService>();


//builder.Services.AddScoped<IEmployeeService,>();
//builder.Services.AddTransient<EMS.Services.CompanyService>();
//builder.Services.AddSingleton<EMS.Services.CompanyService>();
#endregion

// Read a simple setting
//var mySetting = builder.Configuration["SampleKey"];

// Read a connection string
var EMSDBconnectionString = builder.Configuration.GetConnectionString("EMSDBConnection");


builder.Services.AddScoped<ICompanyRepository>(provider =>
{
    return new CompanyRepository(EMSDBconnectionString);
});

builder.Services.AddScoped<ICompanyService>(provider =>
{
    var companyRepository = provider.GetRequiredService<ICompanyRepository>();
    return new CompanyService(companyRepository);
});





builder.Services.AddScoped<IEmployeeRepository>(provider =>
{
    return new EmployeeRepository(EMSDBconnectionString);
});

builder.Services.AddScoped<IEmployeeService>(provider =>
{
    var employeeRepository = provider.GetRequiredService<IEmployeeRepository>();
    return new EmployeeService(employeeRepository);
});




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
