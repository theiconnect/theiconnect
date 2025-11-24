using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Models;
using EMS.DataAccess;

namespace EMS.Services.LINQtoCollectionsExamples
{
    public static class EMSDataQueries
    {
        // 1. Get all active employees
        public static List<EmployeeModel> GetAllActiveEmployees()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees.Where(e => e.IsActive).ToList();
        }

        // 2. Get all departments with more than N employees
        public static List<DepartmentModel> GetDepartmentsWithMoreThanNEmployees(int n)
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments.Where(d => d.Employees.Count > n).ToList();
        }

        // 3. Get all employee names and their department names (projection)
        public static List<(string EmployeeName, string DepartmentName)> GetEmployeeAndDepartmentNames()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Select(e => ($"{e.FirstName} {e.LastName}", db.Departments.First(d => d.DepartmentIdPk == e.DepartmentIdFk).DepartmentName))
                .ToList();
        }

        // 4. Get all employees grouped by department
        public static Dictionary<string, List<EmployeeModel>> GetEmployeesGroupedByDepartment()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .GroupBy(e => db.Departments.First(d => d.DepartmentIdPk == e.DepartmentIdFk).DepartmentName)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // 5. Get the highest paid employee in each department
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

        // 6. Get all employees who have ever held the "TeamLead" designation
        public static List<EmployeeModel> GetEmployeesWhoWereTeamLeads()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.Designations.Any(des => des.DesignationIdFk == Models.Enums.DesiginationTypes.TeamLead))
                .ToList();
        }

        // 7. Get all addresses (company and employee) in a specific city
        public static List<string> GetAllAddressesInCity(string city)
        {
            var db = EMSDbContext.GetInstance();
            var companyAddresses = db.CompanyAddresses.Where(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .Select(a => $"{a.AddressLine1}, {a.AddressLine2}, {a.City}");
            var employeeAddresses = db.EmployeeAddresses.Where(a => a.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .Select(a => $"{a.AddressLine1}, {a.AddressLine2}, {a.City}");
            return companyAddresses.Concat(employeeAddresses).ToList();
        }

        // 8. Get the count of employees per blood group
        public static Dictionary<Models.Enums.BloodGroups, int> GetEmployeeCountByBloodGroup()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .GroupBy(e => e.BloodGroup)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // 9. Get all employees who joined after a certain date, ordered by joining date
        public static List<EmployeeModel> GetEmployeesJoinedAfter(DateTime date)
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.DateOfJoining > date)
                .OrderBy(e => e.DateOfJoining)
                .ToList();
        }

        // 10. Get all inactive departments and their employees
        public static List<(DepartmentModel Department, List<EmployeeModel> Employees)> GetInactiveDepartmentsWithEmployees()
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments
                .Where(d => !d.IsActive)
                .Select(d => (d, d.Employees))
                .ToList();
        }

        // 11. Get all employees with more than one address
        public static List<EmployeeModel> GetEmployeesWithMultipleAddresses()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.Addresses.Count > 1)
                .ToList();
        }

        // 12. Get all employees whose current designation is "HRManager"
        public static List<EmployeeModel> GetCurrentHRManagers()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e => e.DesignationIdFk == Models.Enums.DesiginationTypes.HRManager)
                .ToList();
        }

        // 13. Get the average salary per department
        public static List<(string DepartmentName, decimal AverageSalary)> GetAverageSalaryPerDepartment()
        {
            var db = EMSDbContext.GetInstance();
            return db.Departments
                .Select(d => (
                    d.DepartmentName,
                    d.Employees.Any() ? d.Employees.Average(e => e.SalaryCtc ?? 0) : 0
                ))
                .ToList();
        }

        // 14. Get all employees who have both present and permanent addresses
        public static List<EmployeeModel> GetEmployeesWithPresentAndPermanentAddresses()
        {
            var db = EMSDbContext.GetInstance();
            return db.Employees
                .Where(e =>
                    e.Addresses.Any(a => a.AddressTypeIdFk == Models.Enums.AddressTypes.PRESENT_ADDR) &&
                    e.Addresses.Any(a => a.AddressTypeIdFk == Models.Enums.AddressTypes.PERM_ADDR)
                )
                .ToList();
        }

        // 15. Get all employees with their qualification description (if any)
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
    }
}
