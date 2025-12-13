var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//MVC pattern
//Add EMS.Services and EMS.DataAccess classes as references
//builder.Services.Add(b
// Add EMS.DataAccess.EMSDbContext as a singleton service

builder.Services.AddScoped<EMS.Services.CompanyService>();
builder.Services.AddScoped<EMS.Services.DepartmentService>();
builder.Services.AddScoped<EMS.Services.EmployeeServices>();

//builder.Services.AddSingleton<EMS.Services.CompanyService>();
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
    pattern: "{controller=Employee}/{action=EmployeeList}/{id?}");

//app.MapControllerRoute(
//    name: "default1",
//    pattern: "iconnect/{action}/{controller}/abc");

app.Run();


//locahsot:2323/ Company/a1
//CompanyController
//       A1 locahsot:2323 / Company / a1, locahsot: 2323 / iconnect /A1/ Company / abc
//       A2
