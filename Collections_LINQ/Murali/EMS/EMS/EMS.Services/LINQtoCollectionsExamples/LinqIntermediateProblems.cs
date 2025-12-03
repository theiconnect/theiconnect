using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Models;
using EMS.DataAccess;
using EMS.Models.Enums;

namespace EMS.Services.LINQtoCollectionsExamples
{
    /// <summary>
    /// Intermediate level LINQ problems for EMSDbContext collections.
    /// Demonstrates return types: IEnumerable, IList, List, ICollection, IQueryable.
    /// Includes some intentionally incorrect usages with explanations.
    /// </summary>
    public static class LinqIntermediateProblems
    {
        // 1. Get all departments with more than 2 employees as List
        public static List<DepartmentModel> GetDepartmentsWithMoreThan2Employees()
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments.Where(d => d.Employees.Count > 2).ToList();
        }

        // 2. Get all employees grouped by department name as Dictionary
        public static Dictionary<string, List<EmployeeModel>> GetEmployeesGroupedByDepartmentName()
        {
            var db = EMSDbContext.GetInstance();
            var result = db.Employees
                .GroupBy(e => db.Departments.First(d => d.DepartmentIdPk == e.DepartmentIdFk).DepartmentName)
                .ToDictionary(g => g.Key, g => g.ToList());
            foreach(var kvp in result)
            {
                Console.WriteLine($"{kvp.Key},{string.Join(", ", kvp.Value.Select(x => x.LastName))}");
                Console.WriteLine($"{kvp.Key}: Count={kvp.Value.Count}");
            }
            return result;
        }

        // 3. Get the count of employees per blood group as Dictionary
        public static Dictionary<BloodGroups, int> GetEmployeeCountByBloodGroup()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .GroupBy(e => e.BloodGroup)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // 4. Get the average salary per department as List of tuples
        public static List<(string DepartmentName, decimal AverageSalary)> GetAverageSalaryPerDepartment()
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments
                .Select(d => (
                    d.DepartmentName,
                    d.Employees.Any() ? d.Employees.Average(e => e.SalaryCtc ?? 0) : 0
                )).ToList();    

        }

        // 5. Get the highest paid employee in each department as List of tuples
        public static List<(string DepartmentName, EmployeeModel Employee)> GetHighestPaidEmployeePerDepartment()
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments
                .Select(d => (
                    d.DepartmentName,
                    d.Employees.OrderByDescending(e => e.SalaryCtc ?? 0).FirstOrDefault()
                ))
                .Where(x => x.Item2 != null)
                .ToList();
        }

        // 6. Get all employees who have ever held the "TeamLead" designation as List
        public static List<EmployeeModel> GetEmployeesWhoWereTeamLeads()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.Designations.Any(des => des.DesignationIdFk == DesiginationTypes.TeamLead))
                .ToList();
        }

        // 7. Get all employees who joined after a certain date, ordered by joining date as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesJoinedAfter(DateTime date)
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.DateOfJoining > date)
                .OrderBy(e => e.DateOfJoining);
        }

        // 8. Get all employees with both present and permanent addresses as List
        public static List<EmployeeModel> GetEmployeesWithPresentAndPermanentAddresses()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e =>
                    e.Addresses.Any(a => a.AddressTypeIdFk == AddressTypes.PRESENT_ADDR) &&
                    e.Addresses.Any(a => a.AddressTypeIdFk == AddressTypes.PERM_ADDR)
                )
                .ToList();
        }

        // 9. Get all employees with more than one address as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesWithMultipleAddresses()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.Addresses.Count > 1);
        }

        // 10. Get all employees with their qualification description (if any) as List of tuples
        public static List<(EmployeeModel Employee, string Qualification)> GetEmployeesWithQualification()
        {
            var db = EMSDbContext.GetInstance();
            var qualifications = db.QualificationLookups.ToDictionary(q => q.QualificationIdPk, q => q.Qualification);
            return db.Employees
                .Select(e => (
                    e,
                    e.QualificationIdFk.HasValue && qualifications.ContainsKey(e.QualificationIdFk.Value)
                        ? qualifications[e.QualificationIdFk.Value]
                        : "N/A"
                ))
                .ToList();
        }

        // 11. Get all employees as IQueryable and try to use WhereAsync (NOT allowed, will not compile)
        // public static async Task<List<EmployeeModel>> GetEmployeesWhereAsync()
        // {
        //     var db = EMSDbContext.GetInstance();
        //     // WhereAsync is not available for in-memory collections.
        //     // This will not compile:
        //     // return await db.Employees.AsQueryable().WhereAsync(...);
        // }

        // 12. Get all employees as IEnumerable and try to clear it (NOT allowed)
        public static void TryClearIEnumerable()
        {
            var db = EMSDbContext.GetInstance();
            IEnumerable<EmployeeModel> employees = db.Employees;
            // employees.Clear(); // Not allowed: 'IEnumerable<T>' does not contain a definition for 'Clear'
            // IEnumerable<T> is read-only, you cannot clear items.
        }

        // 13. Get all employees as IQueryable and try to use EF-only methods (NOT allowed)
        public static IQueryable<EmployeeModel> GetEmployeesAsQueryableWithEFOnlyMethod()
        {
            var db = EMSDbContext.GetInstance();
            // IQueryable is not useful for in-memory collections, and EF-only methods like ThenInclude() are not available.
            // db.Employees.AsQueryable().ThenInclude(e => e.Designations); // Not allowed: 'IQueryable<EmployeeModel>' does not contain a definition for 'ThenInclude'
            return db.Employees.AsQueryable();
        }

        // 14. Get all employees with at least one address in a given state as List
        public static List<EmployeeModel> GetEmployeesWithAddressInState(string state)
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.Addresses.Any(a => a.State.Equals(state, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // 15. Get all employees grouped by gender as Dictionary
        public static Dictionary<Genders, List<EmployeeModel>> GetEmployeesGroupedByGender()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .GroupBy(e => e.Gender)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // 16. Get all employees with a specific qualification as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesByQualificationId(int qualificationId)
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.QualificationIdFk == qualificationId);
        }

        // 17. Get all employees with a specific department name as List
        public static List<EmployeeModel> GetEmployeesByDepartmentName(string departmentName)
        {
            var db = EMSDbContext.GetInstance();
            var department = db.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
            if (department == null) return new List<EmployeeModel>();
            return db.Employees.Where(e => e.DepartmentIdFk == department.DepartmentIdPk).ToList();
        }

        // 18. Get all employees with a specific designation in their history as List
        public static List<EmployeeModel> GetEmployeesWithDesignationInHistory(DesiginationTypes designation)
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.Designations.Any(d => d.DesignationIdFk == designation))
                .ToList();
        }

        // 19. Get all employees as ICollection and try to use AddRange (NOT allowed)
        public static void TryAddRangeToICollection()
        {
            var db = EMSDbContext.GetInstance();
            ICollection<EmployeeModel> employees = db.Employees.ToList();
            // employees.AddRange(db.Employees); // Not allowed: 'ICollection<T>' does not contain a definition for 'AddRange'
            // Use List<T> for AddRange.
        }

        // 20. Get all employees as List and use RemoveAll (allowed)
        public static List<EmployeeModel> GetEmployeesAndRemoveInactive()
        {
            var db = EMSDbContext.GetInstance();
            var employees = db.Employees.ToList();
            employees.RemoveAll(e => !e.IsActive); // This is allowed on List<T>
            return employees;
        }
    }
}
