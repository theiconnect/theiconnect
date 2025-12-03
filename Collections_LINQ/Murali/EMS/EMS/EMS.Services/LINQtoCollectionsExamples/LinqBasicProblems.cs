using EMS.DataAccess;
using EMS.Models;
using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;

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
        public static List<EmployeeModel> GetAllEmployeesAsList()
        {
            var db = EMSDbContext.GetInstance();
            var result1 = db.Employees.ToList();
            return result1;
        }

        public static List<DepartmentModel> GetAllDepartmentAsList()
        {
            var db1 = EMSDbContext.GetInstance();
            var result5 = db1.Departments.ToList();
            result5.Add(new DepartmentModel
            {
                DepartmentIdPk = 6,
                DepartmentCode = "67141ewtdgh",
                DepartmentName = "product",
                Location = "sr nagar",
                CompanyIdFk = 1,
                IsActive = true
            });
            return result5;
        }
        // 2. Get all employees as IEnumerable
        public static IEnumerable<EmployeeModel> GetAllEmployeesAsEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            var result = db.Employees.ToList();
            return result;
        }

        public static List<EmployeeModel> GetAllEmployeeAsList()
        {
            var empAddr1 = new EmployeeAddressModel();
            empAddr1.EmployeeAddressModelIdPk = 100;
            empAddr1.AddressTypeIdFk = AddressTypes.PRESENT_ADDR;
            empAddr1.AddressLine1 = "asfsdf";
            empAddr1.AddressLine2 = "sr nagar";
            empAddr1.City = "HYD";
            empAddr1.State = "TS";
            empAddr1.Pincode = "500055";
            empAddr1.isActive = true;
            empAddr1.EmployeeIdFk = 12;

            var empAddr2 = new EmployeeAddressModel();
            empAddr2.EmployeeAddressModelIdPk = 100;
            empAddr2.AddressTypeIdFk = AddressTypes.PERM_ADDR;
            empAddr2.AddressLine1 = "asfsdf";
            empAddr2.AddressLine2 = "Nellore";
            empAddr2.City = "Nellore";
            empAddr2.State = "AP";
            empAddr2.Pincode = "900055";
            empAddr2.isActive = true;
            empAddr2.EmployeeIdFk = 12;

            var empAddresses = new List<EmployeeAddressModel>();
            empAddresses.Add(empAddr1);
            empAddresses.Add(empAddr2);

            var empDesig1 = new EmployeeDesignationModel();
            empDesig1.EmployeeDesignationIdPk = 2;
            empDesig1.EmployeeIdFk = 12;
            empDesig1.DesignationIdFk = DesiginationTypes.ProjectManager;
            empDesig1.EffectiveFrom = new DateTime(2022, 1, 14);
            empDesig1.EndDate = new DateTime(2022, 1, 14);

            var empDesignations = new List<EmployeeDesignationModel>();
            empDesignations.Add(empDesig1);

            var emp = new EmployeeModel();

            emp.EmployeeIdPk = 12;
            emp.Employeecode = "ytryw287423";
            emp.FirstName = "sunitha";
            emp.LastName = "reddy";
            emp.Gender = Genders.Female;
            emp.BloodGroup = BloodGroups.O_Positive;
            emp.EmailId = "meena.rao@abc.com";
            emp.MobileNumber = "9876543219";
            emp.DepartmentIdFk = 1;
            emp.DateOfBirth = new DateTime(1994, 2, 28);
            emp.DateOfJoining = new DateTime(2020, 1, 15);
            emp.ExpInMonths = 36;
            emp.SalaryCtc = 500000;
            emp.IsActive = false;
            emp.Addresses = empAddresses;
            emp.Designations = empDesignations;



            var db1 = EMSDbContext.GetInstance();
            var result6 = db1.Employees.ToList();
            result6.Add(emp);
            return result6;
        }


        // 3. Get all employees as ICollection (not recommended for LINQ queries)
        public static ICollection<EmployeeModel> GetAllEmployeesAsICollection()
        {
            var db = EMSDbContext.GetInstance();
            // ICollection is not ideal for LINQ, but List<T> implements ICollection<T>
            var result = db.Employees.ToList();
            return result;
        }

        // 4. Get all employees as IList (not recommended for LINQ queries)
        public static IList<EmployeeModel> GetAllEmployeesAsIList()
        {
            var db = EMSDbContext.GetInstance();
            // IList is not ideal for LINQ, but List<T> implements IList<T>
            var x = db.Employees.ToList();
            foreach (var X1 in x)
            {
                Console.WriteLine(X1.EmployeeIdPk);
            }
            return x;
        }

        // 5. Get all employees as IQueryable (NOT recommended for in-memory collections)
        public static IQueryable<EmployeeModel> GetAllEmployeesAsQueryable()
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
            var result = db.Departments.Select(d => d.DepartmentName);
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
            return result;
        }

        // 8. Get all active employees as IEnumerable
        public static IEnumerable<EmployeeModel> GetActiveEmployeesAsEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.IsActive);
        }

        // 9. Get all inactive employees as List
        public static List<EmployeeModel> GetInactiveEmployeesAsList()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => !e.IsActive).ToList();
        }

        // 10. Get all employees with salary > 500000 as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesWithHighSalary()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => (e.SalaryCtc ?? 0) > 500000);
        }

        // 11. Get all employees with salary > 500000 as IQueryable (NOT recommended)
        public static IQueryable<EmployeeModel> GetEmployeesWithHighSalaryAsQueryable()
        {
            var db = EMSDbContext.GetInstance();
            // IQueryable is not useful here, see previous note.
            return db.Employees.Where(e => (e.SalaryCtc ?? 0) > 500000).AsQueryable();
        }

        // 12. Get all employees ordered by first name as List
        public static List<EmployeeModel> GetEmployeesOrderedByFirstName()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.OrderBy(e => e.FirstName).ToList();
        }

        // 13. Get all employees ordered by salary descending as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesOrderedBySalaryDesc()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.OrderByDescending(e => e.SalaryCtc ?? 0);
        }

        // 14. Get all department codes as ICollection<string> (not recommended)
        public static ICollection<string> GetAllDepartmentCodesAsICollection()
        {
            var db = EMSDbContext.GetInstance();
            // ICollection is not ideal for LINQ, but List<T> implements ICollection<T>
            return db.Departments.Select(d => d.DepartmentCode).ToList();
        }

        // 15. Get all employees as array (not recommended for LINQ chaining)
        public static EmployeeModel[] GetAllEmployeesAsArray()
        {
            var db = EMSDbContext.GetInstance();
            // Arrays are not ideal for LINQ chaining, prefer IEnumerable/List.
            return db.Employees.ToArray();
        }

        // 16. Get all employees as HashSet (not recommended for ordering)
        public static HashSet<EmployeeModel> GetAllEmployeesAsHashSet()
        {
            var db = EMSDbContext.GetInstance();
            // HashSet is not ideal for ordered queries, but can be used for uniqueness.
            return db.Employees.ToHashSet();
        }

        // 17. Get all employees as Dictionary by EmployeeIdPk
        public static Dictionary<int, EmployeeModel> GetAllEmployeesAsDictionary()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.ToDictionary(e => e.EmployeeIdPk);
        }

        // 18. Get all employees as Lookup by DepartmentIdFk
        public static ILookup<int, EmployeeModel> GetEmployeesLookupByDepartmentId()
        {
            var db = EMSDbContext.GetInstance();
            var result = db.Employees.ToLookup(e => e.DepartmentIdFk);
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
            IEnumerable<EmployeeModel> employees = db.Employees;
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
