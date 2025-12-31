using EMS.DataAccess;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace EMS.Services.LINQtoCollectionsExamples
{
    /// <summary>
    /// Basic level LINQ problems for EMSDbContext collections.
    /// Demonstrates return types: IEnumerable, IList, List, ICollection, IQueryable.
    /// Includes some intentionally incorrect usages with explanations.
    /// </summary>
    public static class LinqBasicProblems
    {
        // 1. Get all employees as List                          
        public static List<EmployeeViewModel> GetAllEmployeesAsList()
        {
            var db = EMSDbContext.GetInstance();
            var result =  db.Employees.ToList();
            result.Add(new EmployeeViewModel
            {
                EmployeeIdPk = 9999,
                Employeecode = "E9999",
                FirstName = "Test",
                LastName = "User",
                EmailId = "meghana@gmail.com",
                MobileNumber = "9999999999",
                DepartmentIdFk = 1,
                DateOfBirth = new DateTime(1990, 1, 1),
                DateOfJoining = new DateTime(2020, 1, 1),
                DesignationIdFk = Models.Enums.DesiginationTypes.QAEngineer,
                SalaryCtc = 600000

                });
            return result;
        }


        //  1.1 get all departments as list

        public static List<DepartmentModel> GetAllDepartmentAsList()
        {
            var db = EMSDbContext.GetInstance();
         
            var result1 = db.Departments.ToList();
           
            return result1;

        }
        // 1A.Get all depertments as List
        public static List<DepartmentModel> GetAllDepartmentsAsList()
        {
            var db = EMSDbContext.GetInstance();
            var result1 = db.Departments.ToList();
            result1.Add(new DepartmentModel
            {
                DepartmentIdPk = 6,
                DepartmentCode = "APS", 
                DepartmentName = "Operations",
                Location = "Regional Office",
                CompanyIdFk = 1 ,
                IsActive = false
            });
            return result1;
        }



        // 2. Get all employees as IEnumerable
        public static IEnumerable<EmployeeViewModel> GetAllEmployeesAsEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees;
        }

        //Get all departments as IEnumerable
        public static IEnumerable<DepartmentModel> GetAllDepartmentsAsEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            var result3 = db.Departments;
            
return result3;
        }
        // 3. Get all employees as ICollection (not recommended for LINQ queries)
        public static ICollection<EmployeeViewModel> GetAllEmployeesAsICollection()
        {
            var db = EMSDbContext.GetInstance();
            // ICollection is not ideal for LINQ, but List<T> implements ICollection<T>
            var result5= db.Employees.ToList();
            return result5;
        }

        // 4. Get all employees as IList (not recommended for LINQ queries)
        public static IList<EmployeeViewModel> GetAllEmployeesAsIList()
        {
            var db = EMSDbContext.GetInstance();
            // IList is not ideal for LINQ, but List<T> implements IList<T>
            var result= db.Employees.ToList();
            return result;  
        }

        // 5. Get all employees as IQueryable (NOT recommended for in-memory collections)
        public static IQueryable<EmployeeViewModel> GetAllEmployeesAsQueryable()
        {
            var db = EMSDbContext.GetInstance();
            // IQueryable is only useful for remote query providers (like EF Core).
            // On in-memory collections, it just adds overhead and can be misleading.
            return db.Employees.AsQueryable();
        }

        // 6. Get all department names as IEnumerable<string>
        public static IEnumerable<string> GetAllDepartmentNames()
        {
            var db = EMSDbContext.GetInstance();
            var result= db.Departments.Select(d => d.DepartmentName);
            return result;
        }


        //public static IEnumerable<string> GetAllDepartmentNames()
        //{
        //    var db = EMSDbContext.GetInstance();
        //    return db.Departments.Select(d => d.Location);
        //}

        // 7. Get all employee first names as List<string>
        public static List<string> GetAllEmployeeFirstNames()
        {
            var db = EMSDbContext.GetInstance();
            var result = db.Employees.Select(e => e.FirstName).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            return result;

        }
       

        // 8. Get all active employees as IEnumerable
        public static IEnumerable<EmployeeViewModel> GetActiveEmployeesAsEnumerable()
        {
            var db = EMSDbContext.GetInstance();

            return db.Employees.Where(e => e.IsActive);
        }



        // 9. Get all inactive employees as List
        public static List<EmployeeViewModel> GetInactiveEmployeesAsList()
        {
            var db = EMSDbContext.GetInstance();
            List<EmployeeViewModel> employees = db.Employees;
            IEnumerable<EmployeeViewModel> activeEmployees = employees.Where(e=> !e.IsActive);
            List<EmployeeViewModel> empList = activeEmployees.ToList();

            return db.Employees.Where(e => !e.IsActive).ToList();
        }

        // 10. Get all employees with salary > 500000 as IEnumerable
        public static IEnumerable<EmployeeViewModel> GetEmployeesWithHighSalary()
        {
            var db = EMSDbContext.GetInstance();
            var result10 = db.Employees.Where(e => (e.SalaryCtc ?? 0) > 500000);
            foreach(var emp in result10)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Salary: {emp.SalaryCtc}");
            }
           
            return result10;
        }

        // 11. Get all employees with salary > 500000 as IQueryable (NOT recommended)
        public static IQueryable<EmployeeViewModel> GetEmployeesWithHighSalaryAsQueryable()
        {
            var db = EMSDbContext.GetInstance();
            // IQueryable is not useful here, see previous note.
            return db.Employees.Where(e => (e.SalaryCtc ?? 0) > 500000).AsQueryable();
            
            
        }

        // 12. Get all employees ordered by first name as List
        public static List<EmployeeViewModel> GetEmployeesOrderedByFirstName()
        {
            var db = EMSDbContext.GetInstance();
            var result12 = db.Employees.OrderBy(e => e.FirstName).ToList();
            foreach(var emp in result12)
                {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}");
            }
            return result12;
        }

        // 13. Get all employees ordered by salary descending as IEnumerable
        public static IEnumerable<EmployeeViewModel> GetEmployeesOrderedBySalaryDesc()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.OrderByDescending(e => e.SalaryCtc ?? 0);
        }

        // 14. Get all department codes as ICollection<string> (not recommended)
        public static ICollection<string> GetAllDepartmentCodesAsICollection()
        {
            var db = EMSDbContext.GetInstance();
            // ICollection is not ideal for LINQ, but List<T> implements ICollection<T>
            var result14 = db.Departments.Select(d => d.DepartmentCode).ToList();
            foreach(var code in result14)
            {
                Console.WriteLine($"Department Code: {code}");
            }
            return result14;
        }

        // 15. Get all employees as array (not recommended for LINQ chaining)
        public static EmployeeViewModel[] GetAllEmployeesAsArray()
        {
            var db = EMSDbContext.GetInstance();
            // Arrays are not ideal for LINQ chaining, prefer IEnumerable/List.
            var result15 = db.Employees.ToArray();
            foreach(var emp in result15)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}");
            }
            return result15;
        }

        // 16. Get all employees as HashSet (not recommended for ordering)
        public static HashSet<EmployeeViewModel> GetAllEmployeesAsHashSet()
        {
            var db = EMSDbContext.GetInstance();
            // HashSet is not ideal for ordered queries, but can be used for uniqueness.
            var result= db.Employees.ToHashSet();
            return result;
        }

        // 17. Get all employees as Dictionary by EmployeeIdPk
        public static Dictionary<int, EmployeeViewModel> GetAllEmployeesAsDictionary()
        {
            var db = EMSDbContext.GetInstance();
            var result= db.Employees.ToDictionary(e => e.EmployeeIdPk);
            return result;
        }

        // 18. Get all employees as Lookup by DepartmentIdFk
        public static ILookup<int, EmployeeViewModel> GetEmployeesLookupByDepartmentId()
        {
            var db = EMSDbContext.GetInstance();
            var result= db.Employees.ToLookup(e => e.DepartmentIdFk);
            return result;
        }

        // 19. Get all employees as IQueryable and try to use ToListAsync (NOT allowed, will not compile)
        // public static async Task<List<EmployeeModel>> GetAllEmployeesToListAsync()
        // {
        //     var db = EMSDbContext.GetInstance();
        //     // ToListAsync is only available for EF Core IQueryable, not for in-memory collections.
        //     // This will not compile:
        //     // return await db.Employees.AsQueryable().ToListAsync();
        //     // Error: 'IQueryable<EmployeeModel>' does not contain a definition for 'ToListAsync'
        // }

        // 20. Get all employees as IEnumerable and try to add to it (NOT allowed)
        public static void TryAddToIEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            IEnumerable<EmployeeViewModel> employees = db.Employees;
            var result= employees.ToList();
            
            // employees.Add(new EmployeeModel()); // Not allowed: 'IEnumerable<T>' does not contain a definition for 'Add'
            // IEnumerable<T> is read-only, you cannot add/remove items.
        }


        //get all employees full names

        //public static List<string> AllEmployeesFullNames()
        //{
        //    var db = EMSDbContext.GetInstance();
        //    return db.Employees.Select(e => new{FirstName = e.FirstName,LastName = e.LastName}).ToList();
             
        //}
    }
}
