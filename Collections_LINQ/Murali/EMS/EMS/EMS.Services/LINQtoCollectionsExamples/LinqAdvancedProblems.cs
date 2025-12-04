using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Models;
using EMS.DataAccess;
using EMS.Models.Enums;

namespace EMS.Services.LINQtoCollectionsExamples
{
    /// <summary>
    /// Advanced level LINQ problems for EMSDbContext collections.
    /// Demonstrates return types: IEnumerable, IList, List, ICollection, IQueryable.
    /// Includes some intentionally incorrect usages with explanations.
    /// </summary>
    public static class LinqAdvancedProblems
    {

        public static void Test()
        {
            
        }

        //where(e=> e.EmployeeId ==0)//Anonymous function
        // 1. Get all employees with the maximum salary in the company as List
        public static List<EmployeeModel> GetEmployeesWithMaxSalary()
        {
            var db = EMSDbContext.GetInstance();
            var maxEmpId = db.Employees.Max(e => e.EmployeeIdPk);
            var emp = db.Employees.Where(e => e.EmployeeIdPk == maxEmpId);

            var maxSalary = db.Employees.Max(e => e.SalaryCtc ?? 0);
            return db.Employees.Where(e => (e.SalaryCtc ?? 0) == maxSalary).ToList();
        }

        // 2. Get all departments with no employees as IEnumerable
        public static IEnumerable<DepartmentModel> GetDepartmentsWithNoEmployees()
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments.Where(d => d.Employees == null || d.Employees.Count == 0);
        }

        // 3. Get all employees who have changed departments (by checking if they have designations in multiple departments)
        public static List<EmployeeModel> GetEmployeesWithDepartmentChanges()
        {
            var db = EMSDbContext.GetInstance();
            // This assumes EmployeeDesignationModel has DepartmentIdFk (not in your model, so this is a logical placeholder)
            // return db.Employees.Where(e => e.Designations.Select(d => d.DepartmentIdFk).Distinct().Count() > 1).ToList();
            // Not allowed: EmployeeDesignationModel does not have DepartmentIdFk
            // Instead, we can check if an employee's DepartmentIdFk ever changed (not possible with current model)
            return new List<EmployeeModel>(); // Placeholder
        }

        // 4. Get all employees with at least one inactive address as List
        public static List<EmployeeModel> GetEmployeesWithInactiveAddress()
        {
            //EMSDbContext.GetInstance()
            //    .Company
            //    .Departments.Where(d => d.Employees.Any(e => e.Addresses.Any(a => !a.isActive));

            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.Addresses.Any(a => !a.isActive)).ToList();
        }

        // 5. Get the department with the most employees as DepartmentModel
        public static DepartmentModel GetDepartmentWithMostEmployees()
        {
            var db = EMSDbContext.GetInstance();
            var result = db.Departments.OrderByDescending(d => d.Employees.Count);

            return db.Departments.OrderByDescending(d => d.Employees.Count).FirstOrDefault();
        }

        // 6. Get all employees who have never been a TeamLead as List
        public static List<EmployeeModel> GetEmployeesNeverTeamLead()
        {

            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => !e.Designations.Any(d => d.DesignationIdFk == DesiginationTypes.TeamLead)).ToList();
        }

        // 7. Get all employees with at least one address in both "NY" and "CA" states as List
        public static List<EmployeeModel> GetEmployeesWithAddressesInNYAndCA()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e =>
                e.Addresses.Any() &&
                e.Addresses.Any(a => a.State == "NY") &&
                e.Addresses.Any(a => a.State == "CA")
            ).ToList();
        }

        // 8. Get all employees with the same first and last name as IEnumerable
        public static IEnumerable<EmployeeModel> GetEmployeesWithSameFirstAndLastName()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.FirstName == e.LastName);
        }

        // 9. Get all employees who have ever had more than one designation at the same time (overlapping periods)
        public static List<EmployeeModel> GetEmployeesWithOverlappingDesignations()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e =>
                e.Designations.Any(d1 =>
                    e.Designations.Any(d2 =>
                        d1 != d2 &&
                        d1.EffectiveFrom <= (d2.EndDate ?? DateTime.MaxValue) &&
                        (d1.EndDate ?? DateTime.MaxValue) >= d2.EffectiveFrom
                    )
                )
            ).ToList();
        }

        // 10. Get all employees who have never had a permanent address as List
        public static List<EmployeeModel> GetEmployeesWithoutPermanentAddress()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => !e.Addresses.Any(a => a.AddressTypeIdFk == AddressTypes.PERM_ADDR)).ToList();
        }

        // 11. Get all employees as IQueryable and try to use EF navigation property (NOT allowed)
        public static IQueryable<EmployeeModel> GetEmployeesAsQueryableWithNavigation()
        {
            var db = EMSDbContext.GetInstance();
            // db.Employees.AsQueryable().Include(e => e.Department); // Not allowed: 'IQueryable<EmployeeModel>' does not contain a definition for 'Include'
            return db.Employees.AsQueryable();
        }

        // 12. Get all employees with the most recent joining date as List
        public static List<EmployeeModel> GetEmployeesWithMostRecentJoiningDate()
        {
            var db = EMSDbContext.GetInstance();

            db.Employees.Where(e => e.DateOfJoining == (db.Employees.Max(e1 => e1.DateOfJoining))).ToList();


            var maxDate = db.Employees.Max(e => e.DateOfJoining);
            return db.Employees.Where(e => e.DateOfJoining == maxDate).ToList();
        }

        // 13. Get all employees who have worked in more than one department (NOT possible with current model)
        public static List<EmployeeModel> GetEmployeesWorkedInMultipleDepartments()
        {
            // Not possible: EmployeeModel only has one DepartmentIdFk and no department history
            return new List<EmployeeModel>();
        }

        // 14. Get all employees with at least one address in a city that starts with "New" as List
        public static List<EmployeeModel> GetEmployeesWithAddressInCityStartingWithNew()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.Addresses.Any(a => a.City.StartsWith("New", StringComparison.OrdinalIgnoreCase))).ToList();
        }

        // 15. Get all employees with at least one inactive designation (has EndDate set) as List
        public static List<EmployeeModel> GetEmployeesWithInactiveDesignation()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.Designations.Any(d => d.EndDate.HasValue)).ToList();
        }

        // 16. Get all employees as ICollection and try to use RemoveWhere (NOT allowed)
        public static void TryRemoveWhereOnICollection()
        {
            var db = EMSDbContext.GetInstance();
            IEnumerable<EmployeeModel> employeesIEnumerable = db.Employees.ToList();
            ICollection<EmployeeModel> employeesICollection = db.Employees.ToList();
            List<EmployeeModel> employeesList = db.Employees.ToList();

            employeesList.Add(new EmployeeModel());//possible
            employeesList.Remove(db.Employees.First());//possible

            //employeesIEnumerable.Add(new EmployeeModel());//not possible
            //employeesIEnumerable.Remove(db.Employees.First());//not possible


            // employees.RemoveWhere(e => !e.IsActive); // Not allowed: 'ICollection<T>' does not contain a definition for 'RemoveWhere'
            // Use HashSet<T> for RemoveWhere.
        }

        // 17. Get all employees as HashSet and use RemoveWhere (allowed)
        public static HashSet<EmployeeModel> GetEmployeesAsHashSetAndRemoveInactive()
        {
            var db = EMSDbContext.GetInstance();
            var set = db.Employees.ToHashSet();
            set.RemoveWhere(e => !e.IsActive);
            return set;
        }

        // 18. Get all employees with at least one address in a city that contains a space as List
        public static List<EmployeeModel> GetEmployeesWithAddressInCityWithSpace()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.Addresses.Any(a => a.City.Contains(" "))).ToList();
        }

        // 19. Get all employees as IQueryable and try to use EF async method (NOT allowed)
        // public static async Task<List<EmployeeModel>> GetEmployeesToListAsync()
        // {
        //     var db = EMSDbContext.GetInstance();
        //     // ToListAsync is only available for EF Core IQueryable, not for in-memory collections.
        //     // This will not compile:
        //     // return await db.Employees.AsQueryable().ToListAsync();
        // }

        // 20. Get all employees with at least one address in each state present in the company as List
        public static List<EmployeeModel> GetEmployeesWithAddressInAllStates()
        {
            var db = EMSDbContext.GetInstance();
            // Get all distinct states from company addresses
            var allStates = db.CompanyAddresses.Select(a => a.State).Distinct().ToList();

            List<int> A = new() { 1, 2, 3, 4, 5 };//List
            List<int> B = new() { 2, 3 };//List

            // Check if B is subset of A
            bool isSubset = B.All(b => A.Contains(b));

            //looping through each employee
            return db.Employees.Where(e =>
                allStates.All(state => e.Addresses.Any(a => a.State == state))
            ).ToList();
        }
    }
}
