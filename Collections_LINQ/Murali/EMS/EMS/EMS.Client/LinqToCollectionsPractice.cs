using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models.Enums;
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
            //var empList = LinqBasicProblems.GetAllEmployeesAsList();
            //var empsByDeptId = LinqBasicProblems.GetAllDepartmentsAsList();
            // var empsByDeptEnum = LinqBasicProblems.GetAllDepartmentsAsEnumerable();
            //var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            //var emphighsal = LinqBasicProblems.GetEmployeesWithHighSalary();
            // var empnames = LinqBasicProblems.GetEmployeesOrderedByFirstName();
            //var empsaldesc = LinqBasicProblems.GetEmployeesOrderedBySalaryDesc();
            //var deptcodeascol=LinqBasicProblems.GetAllDepartmentCodesAsICollection();
            //var empasarr=LinqBasicProblems.GetAllEmployeesAsArray();
            // Add more calls to LinqBasicProblems methods as needed  
        }
        internal void PracticeBeginnerLinq()
        {
            //var activemphighsal=LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();
            //var empdept = LinqBeginnerProblems.GetEmployeesByDepartmentId(1);
            //var empblood=LinqBeginnerProblems.GetEmployeesByBloodGroup(EMS.Models.Enums.BloodGroups.A_Positive);
            //var empbylastname=LinqBeginnerProblems.GetEmployeesByLastName("Smith");
            //var empjoinyear=LinqBeginnerProblems.GetEmployeesJoinedInYear(2020);
            //var empexp=LinqBeginnerProblems.GetEmployeesWithMoreThan5YearsExp();
            //var empmobile=LinqBeginnerProblems.GetEmployeesWithAlternateMobile();
            //var empgender=LinqBeginnerProblems.GetEmployeesByGender(EMS.Models.Enums.Genders.Male);
            // var empqulifi= LinqBeginnerProblems.GetEmployeesWithNullQualification();
            //var empnameA=LinqBeginnerProblems.GetEmployeesFirstNameStartsWithA();

        }

        internal void PracticeIntermediateLinq()
        {
            var twoEmployees = LinqIntermediateProblems.GetDepartmentsWithMoreThan2Employees();
            // Add more calls to LinqBasicProblems methods as needed  
        }
    }
}
