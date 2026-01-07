using EMS.DataAccess;
using EMS.Models;
using System.Reflection.Metadata.Ecma335;

namespace EMS.Services
{
    public class CompanyService
    {
        EMSDbContext Dbcontext;
        public CompanyService()
        {
            Dbcontext = EMSDbContext.GetInstance();
        }

        public List<CompanyModel> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public CompanyModel GetCompany()
        {
            var company = Dbcontext.Company;
            return company;
        }
        
        /*public void test()
        {
            

            return;
            Console.WriteLine("Hello, World!");

            //EMSDbContext dbContext = EMSDbContext.GetInstance();

            //var companies = dbContext.Company;

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
                if (d.DepartmentName == "IT")
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

            foreach (var dda in allITdepartmentsQueriable)
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

            var a = dbContext.Departments.Find(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
            var a1 = dbContext.Departments.FindAll(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
            var a2 = dbContext.Departments.Where(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
            var a3 = dbContext.Departments.First(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
            var a4 = dbContext.Departments.FirstOrDefault(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");

            var a5 = dbContext.Departments.Single(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");
            var a6 = dbContext.Departments.SingleOrDefault(d => d.IsActive == true && d.Location == "Head Office" && d.DepartmentName == "IT");


            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evenNumbers = numbers.Where(numbers => numbers % 2 == 0);

            List<string> names = new List<string> { "Alice", "Bob", "Carol", "David" };

            IEnumerable<string> namesStartingWithC = names.Where(name => name.StartsWith("C"));

            // Aggregation operations example -
            var maxScore = dbContext.Employees.Max(e => e.SalaryCtc);
            var minScore = dbContext.Employees.Min(e => e.SalaryCtc);
            var averageScore = dbContext.Employees.Average(e => e.SalaryCtc);
            var totalScoreSum = dbContext.Employees.Sum(e => e.SalaryCtc);
            var studentCount = dbContext.Employees.Count(e => e.Gender == EMS.Models.Enums.Genders.Female);


            // Set operations example
            var firstNames = new string[] { "John", "Jane", "Jim", "Jane" };
            var lastNames = new string[] { "Doe", "Smith", "Adams", "John" };

            var distinctFirstNames = firstNames.Distinct(); // "John", "Jane", "Jim"
            var unionNames = firstNames.Union(lastNames); // "John", "Jane", "Jim", "Doe", "Smith", "Adams"
            var intersectNames = firstNames.Intersect(lastNames); // "John"


            // Pagination example
            int pageNumber = 1;
            int pageSize = 5;

            var page = dbContext.Employees
                .Skip(10)
                .Take(15);

            // Conversion operator example
            var studentDictionary = dbContext.Employees
                .Where(student => student.SalaryCtc > 18)
                .ToDictionary(student => student.EmployeeIdPk, student => student.Employeecode);

            // Conversion operator example
            var abc = dbContext.Employees
                .Where(student => student.SalaryCtc > 18)
                .Select(student => new { a = student.EmployeeIdPk, b = student.Employeecode });




        }
        */
    }
}
