using EMS.Models.Enums;
using EMS.Services.LINQtoCollectionsExamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //    var emps = LinqBasicProblems.GetAllEmployeesAsEnumerable();
            //    var empsByDeptId = LinqBasicProblems.GetEmployeesLookupByDepartmentId();
            // var Active = LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();
            // var alldepartments = LinqBasicProblems.GetAllDepartmentAsList();
            //var alldepartmnets = LinqBasicProblems.GetAllDepartmentsAsEnumerable();
            //var allEmployees = LinqBasicProblems.GetAllEmployeesAsEnumerable();
         //   var allEmployees = LinqBasicProblems.GetEmployeesOrderedBySalaryDesc();
            // Add more calls to LinqBasicProblems methods as needed  

        }

        internal void PracticeBeginnerLinq()
        {

            //var allemployees = LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();
            //var allemployees1 = LinqBeginnerProblems.GetActiveEmployeesOrWithHighSalary();
            //var allemployees2 = LinqBeginnerProblems.GetEmployeesByDepartmentId(1);
            //var allemployees3 = LinqBeginnerProblems.GetEmployeesByBloodGroup(EMS.Models.Enums.BloodGroups.O_Positive);

            //var allemployees4 = LinqBeginnerProblems.GetEmployeesByLastName("sharma");
            //var allemployees6 = LinqBeginnerProblems.GetEmployeesJoinedInYear(2000);
           // var allemployees7 = LinqBeginnerProblems.GetEmployeesWithMoreThan5YearsExp();
           // var allemployees5 = LinqBeginnerProblems.GetEmployeesByFirstNameStartingWith("A");  
        }

        internal void PracticeIntermediateLinq()
        {
            var allEmployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            // Add more calls to LinqBasicProblems methods as needed  
        }
    }
}
