using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;
using EMS.Services.LINQtoCollectionsExamples;

namespace EMS.Client
{
    internal class LinqToCollectionsPractice
    {
        internal void PracticeAdvancedLinq()
        {
            throw new NotImplementedException();
        }

        internal void PracticeBasicLinq()
        {
            IEnumerable<EmployeeModel> emps = LinqBasicProblems.GetAllEmployeesAsEnumerable();

            //var empsbyDeptId = LinqBasicProblems.GetEmployeesLookupByDepartmentId();
            //var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            //var inactiveEmployees = LinqBasicProblems.GetInactiveEmployeesAsList();
            //var activeEmployees = LinqBasicProblems.GetActiveEmployeesAsEnumerable();
            //var getAllEmployee = LinqBasicProblems.GetAllEmployeeFirstNames();
            //var allDepartmentNames= LinqBasicProblems.GetAllDepartmentNames();
            //var employeesWithHighSalary = LinqBasicProblems.GetEmployeesWithHighSalary();
            //var employeesOrderedBySalaryDesc = LinqBasicProblems.GetEmployeesOrderedBySalaryDesc();
            //var allEmployeesAsDictionary = LinqBasicProblems.GetAllEmployeesAsDictionary();
            //var employeesLookupByDepartmentId = LinqBasicProblems.GetEmployeesLookupByDepartmentId();
            // Add more calls to LinqBasicProblems methods as needed  
        }

        internal void PracticeBeginnerLinq()
        {
            //var activeEmployeesWithHighSalary = LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();
            //var employeesByDepartment = LinqBeginnerProblems.GetEmployeesByDepartmentId(4);
            //var empoyeesByBloodGroup = LinqBeginnerProblems.GetEmpoyeesByBloodGroup(Models.Enums.BloodGroups.O_Positive);
            //var employeesByLastName = LinqBeginnerProblems.GetEmployeesByLastName("Reddy");
            //var employeesJoinedInYear = LinqBeginnerProblems.GetEmployeesJoinedInYear(1985);
            //var employeesWithMoreThan5YearsExp = LinqBeginnerProblems.GetEmployeesWithMoreThan5YearsExp();
            //var employeesWithNullQualification = LinqBeginnerProblems.GetEmployeesWithNullQualification();
            //var employeesWithSalaryRange = LinqBeginnerProblems.GetEmployeesWithSalaryRange();
            //var employeesByDesignation = LinqBeginnerProblems.GetEmployeesByDesignation(Models.Enums.DesiginationTypes.HRManager);
            //var employeesByGender = LinqBeginnerProblems.GetEmployeesByGender(Models.Enums.Genders.Female);
            //var employeesWithAtLeastTwoAddresses = LinqBeginnerProblems.GetEmployeesWithAtLeastTwoAddresses();
        }

        internal void PracticeIntermediateLinq()
        {
            //var allEmployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            var departmentsWithMoreThan2Employees = LinqIntermediateProblems.GetDepartmentsWithMoreThan2Employees();
            var employeesGroupedByDepartmentName = LinqIntermediateProblems.GetEmployeesGroupedByDepartmentName();
            var employeeCountByBloodGroup = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            var averageSalaryPerDepartment = LinqIntermediateProblems.GetAverageSalaryPerDepartment();
            var highestPaidEmployeePerDepartment = LinqIntermediateProblems.GetHighestPaidEmployeePerDepartment();
            var employeesWhoWereTeamLeads = LinqIntermediateProblems.GetEmployeesWhoWereTeamLeads();

            // Add more calls to LinqBasicProblems methods as needed  
        }
}
}
