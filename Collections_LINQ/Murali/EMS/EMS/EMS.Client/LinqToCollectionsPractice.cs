using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //var emps = LinqBasicProblems.GetAllEmployeesAsEnumerable();
            //var empsByDeptId = LinqBasicProblems.GetEmployeesLookupByDepartmentId();
            //var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            // var Departments = LinqBasicProblems.GetAllDepartmentAsList();
            //var emps = LinqBasicProblems.GetAllEmployeesAsEnumerable();
            //var sai = LinqBasicProblems.GetAllDepartmentNames();

            //var GetAllEmployeesAsICollection = LinqBasicProblems.GetAllDepartmentCodesAsICollection();

            //var firstnamesEmployees = LinqBasicProblems.GetAllEmployeeFirstNames();
            //var activeEmployees = LinqBasicProblems.GetActiveEmployeesAsEnumerable();
            //var GetAllEmployeesAsArray = LinqBasicProblems.GetAllEmployeesAsArray();

            // Add more calls to LinqBasicProblems methods as needed
            // 


        }
        internal void PracticeBeginnerLinq()
        {

            // var ActiveEmployeesWithHighSalary = LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();
            //var GetEmployeesByDepartmentId = LinqBeginnerProblems.GetEmployeesByDepartmentId(2);
            //var GetEmployeesJoinedInYear = LinqBeginnerProblems.GetEmployeesJoinedInYear(2020);
            //var x = LinqBeginnerProblems.GetEmployeesWithAlternateMobile();
            //var y = LinqBeginnerProblems.GetEmployeesFirstNameStartsWithA();

            //LinqBeginnerProblems.GetEmployeesLastNameEndsWithA();
            //LinqBeginnerProblems.GetEmployeesWithEmailContainingAbc();
            //LinqBeginnerProblems.GetEmployeesWithSalaryRange();
            LinqBeginnerProblems.GetEmployeesWithNullQualification();
            //LinqBeginnerProblems.Getdepartmentnames();

        }

        internal void PracticeIntermediateLinq()
        {
            //var allEmployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();

            //LinqIntermediateProblems.GetEmployeesGroupedByDepartmentName();
            // Add more calls to LinqBasicProblems methods as needed  
        }
    }
}
