using EMS.DataAccess;
using EMS.Models;
using EMS.Models.Enums;

namespace EMS.Services.LINQtoCollectionsExamples
{
    /// <summary>
    /// Beginner level LINQ problems for EMSDbContext collections.
    /// Demonstrates return types: IEnumerable, IList, List, ICollection, IQueryable.
    /// Includes some intentionally incorrect usages with explanations.
    /// </summary>
    public static class LinqBeginnerProblems
    {
        // 1. Get all employees who are active and have salary above 400000 as List
        public static List<EmployeeModel> GetActiveEmployeesWithHighSalary()
        {
            var db = EMSDbContext.GetInstance();
            //EMSDbContext db = EMSDbContext.GetInstance();
            var result1 = db.Employees.Where(e => e.IsActive && (e.SalaryCtc ?? 0) > 400000).ToList();
            return result1;
        }

        // 2. Get all employees in a specific department as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesByDepartmentId(int departmentId)
        {
            var db = EMSDbContext.GetInstance();
            var result2 = db.Employees.Where(e => e.DepartmentIdFk == departmentId);
            return result2;
        }

        // 3. Get all employees with a specific blood group as List
        public static List<EmployeeModel> GetEmployeesByBloodGroup(BloodGroups bloodGroup)
        {
            var db = EMSDbContext.GetInstance();
            var result3 = db.Employees.Where(e => e.BloodGroup == bloodGroup).ToList();
            return result3;

        }

        // 4. Get all employees with a specific last name as ICollection
        public static ICollection<EmployeeModel> GetEmployeesByLastName(string lastName)
        {
            var db = EMSDbContext.GetInstance();
            var result4 = db.Employees.Where(e => e.LastName == lastName).ToList();
            return result4;
        }

        // 5. Get all employees who joined in a specific year as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesJoinedInYear(int year)
        {

            var db = EMSDbContext.GetInstance();
            var result5 = db.Employees.Where(e => e.DateOfJoining.Year == year);
            return result5;
        }

        // 6. Get all employees with more than 5 years of experience as List
        public static List<EmployeeModel> GetEmployeesWithMoreThan5YearsExp()
        {
            var db = EMSDbContext.GetInstance();
            var result6 = db.Employees.Where(e => e.ExpInMonths > 60).ToList();
            foreach (var emp in result6)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}, Experience: {emp.ExpInMonths} months");
            }
            return result6;

        }

        // 7. Get all employees with a null qualification as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesWithNullQualification()
        {
            var db = EMSDbContext.GetInstance();
            var result7= db.Employees.Where(e => !e.QualificationIdFk.HasValue);
            return result7;
        }

        // 8. Get all employees with a non-null alternate mobile number as List
        public static List<EmployeeModel> GetEmployeesWithAlternateMobile()
        {
            var db = EMSDbContext.GetInstance();
            var result8 = db.Employees.Where(e => !string.IsNullOrEmpty(e.AlternateMobileNumber)).ToList();

            return result8;
        }


        // 9. Get all employees whose first name starts with 'A' as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesFirstNameStartsWithA()
        {
            var db = EMSDbContext.GetInstance();
            var result9 = db.Employees.Where(e => e.FirstName.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            foreach (var emp in result9)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}");
            }
            return result9;
        }

        // 10. Get all employees whose last name ends with 'a' as List
        //public static List<EmployeeModel> GetEmployeesLastNameEndsWithA()
        //{
        //    var db = EMSDbContext.GetInstance();
        //    var result = db.Employees.Where(e => e.LastName.EndsWith("a")).ToList().Select(e=>e.FirstName);
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine($"{item.FirstName}");
        //    }
        //    return result;
        //}

        // 11. Get all employees with email containing "abc" as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesWithEmailContainingAbc()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.EmailId != null && e.EmailId.Contains("abc"));
        }

        // 12. Get all employees with salary between 400000 and 700000 as List
        public static List<EmployeeModel> GetEmployeesWithSalaryRange()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => (e.SalaryCtc) >= 400000 && (e.SalaryCtc) <= 700000).ToList();
        }

        // 13. Get all employees as IQueryable and try to use FirstAsync (NOT allowed, will not compile)
        // public static async Task<EmployeeModel> GetFirstEmployeeAsync()
        // {
        //     var db = EMSDbContext.GetInstance();
        //     // FirstAsync is only available for EF Core IQueryable, not for in-memory collections.
        //     // This will not compile:
        //     // return await db.Employees.AsQueryable().FirstAsync();
        //     // Error: 'IQueryable<EmployeeModel>' does not contain a definition for 'FirstAsync'
        // }

        // 14. Get all employees as IEnumerable and try to remove from it (NOT allowed)
        public static void TryRemoveFromIEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            IEnumerable<EmployeeModel> employees = db.Employees;
            
            // employees.Remove(new EmployeeModel()); // Not allowed: 'IEnumerable<T>' does not contain a definition for 'Remove'
            // IEnumerable<T> is read-only, you cannot add/remove items.
        }

        // 15. Get all employees as IQueryable and try to use EF-only methods (NOT allowed)
        public static IQueryable<EmployeeModel> GetEmployeesAsQueryableWithEFOnlyMethod()
        {
            var db = EMSDbContext.GetInstance();
            // IQueryable is not useful for in-memory collections, and EF-only methods like Include() are not available.
            // db.Employees.AsQueryable().Include(e => e.Addresses); // Not allowed: 'IQueryable<EmployeeModel>' does not contain a definition for 'Include'
            var result = db.Employees.AsQueryable();
            return result;
        }

        // 16. Get all employees with a specific designation as List
        public static List<EmployeeModel> GetEmployeesByDesignation(DesiginationTypes designation)
        {
            var db = EMSDbContext.GetInstance();
            var result= db.Employees.Where(e => e.DesignationIdFk == designation).ToList();
            return result;
        }

        // 17. Get all employees with a specific gender as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesByGender(Genders gender)
        {
            var db = EMSDbContext.GetInstance();
            var result17 = db.Employees.Where(e => e.Gender == gender);
            return result17;
        }

        // 18. Get all employees with a specific city in any address as List
        public static List<EmployeeModel> GetEmployeesByAddressCity(string city)
        {
            var db = EMSDbContext.GetInstance();
            var result= db.Employees.Where(e => e.Addresses.Any(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase))).ToList();
            return result;
        }

        // 19. Get all employees with at least two addresses as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesWithAtLeastTwoAddresses()
        {
            var db = EMSDbContext.GetInstance();
            var result= db.Employees.Where(e => e.Addresses.Count >= 2).ToList();
            return result;
        }

        // 20. Get all employees as ICollection and try to use LINQ extension (allowed, but not recommended)
        public static ICollection<EmployeeModel> GetAllEmployeesAsICollectionAndUseLinq()
        {
            var db = EMSDbContext.GetInstance();
            ICollection<EmployeeModel> employees = db.Employees.ToList();
            // This works, but ICollection<T> is not ideal for LINQ chaining.
            var filtered = employees.Where(e => e.IsActive).ToList();
            return employees;
        }
    }
}
