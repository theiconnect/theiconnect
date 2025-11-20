// See https://aka.ms/new-console-template for more information
using EMS.DataAccess;
using EMS.Models;

Console.WriteLine("Hello, World!");

EMSDbContext dbContext = EMSDbContext.GetInstance();

var companies = dbContext.Company;

//Filter
//Group
//Sort

//context
//    .Company
//    .Departments
//    .SelectMany(dept => dept.Employees)
//    .Where(emp => emp.Gender == EMS.Models.Enums.Genders.Male)
//    .ToList();


//=> Called as Lambda Expression

DepartmentModel firstITdepartment = dbContext.Departments.Find(d => d.DepartmentName == "IT");

foreach (var d in dbContext.Departments)
{
    if(d.DepartmentName == "IT")
    {
        firstITdepartment = d;
        break;
    }
}

List<DepartmentModel> allITdepartments = dbContext.Departments.FindAll(d => d.DepartmentName == "IT");
allITdepartments.Add(new DepartmentModel { DepartmentIdPk = 999, DepartmentName = "New IT Dept" });
allITdepartments.Remove(new DepartmentModel { DepartmentIdPk = 999, DepartmentName = "New IT Dept" });

foreach (var d in dbContext.Departments)
{
    if (d.DepartmentName == "IT")
    {
        allITdepartments.Add(d);
    }
}

IEnumerable<DepartmentModel> lst = allITdepartments;

IQueryable<DepartmentModel> allITdepartmentsEnumarable = dbContext.Departments.Where(d => d.DepartmentName == "IT") as IQueryable<DepartmentModel>;


IEnumerable<DepartmentModel> allITdepartmentsEnumarable1 =
    dbContext.Departments
    .Where(d => d.DepartmentName == "IT")
    .Where(d => d.IsActive == true)
    .Where(d1 => d1.Location == "Head Office");



IQueryable<DepartmentModel> allITdepartmentsQueriable =
    dbContext.Departments
    .Where(d => d.DepartmentName == "IT")
    .Where(d => d.IsActive == true)
    .Where(d1 => d1.Location == "Head Office") as IQueryable<DepartmentModel>;

foreach(var dda in allITdepartmentsQueriable)
{
    Console.WriteLine(dda.DepartmentName);
}

//allITdepartmentsEnumarable.Add(new DepartmentModel { DepartmentIdPk = 999, DepartmentName = "New IT Dept" });
//allITdepartmentsEnumarable.Remove(new DepartmentModel { DepartmentIdPk = 999, DepartmentName = "New IT Dept" });

foreach (var d in dbContext.Departments)
{
    if (d.DepartmentName == "IT")
    {
        allITdepartments.Add(d);
    }
}

var a = dbContext.Departments.Find(d=> d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
var a1 = dbContext.Departments.FindAll(d=> d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
var a2 = dbContext.Departments.Where(d=> d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
var a3 = dbContext.Departments.First(d=> d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
var a4 = dbContext.Departments.FirstOrDefault(d=> d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");

var a5 = dbContext.Departments.Single(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
var a6 = dbContext.Departments.SingleOrDefault(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
