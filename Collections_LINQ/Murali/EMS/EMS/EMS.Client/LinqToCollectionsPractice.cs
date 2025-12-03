using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            //throw new NotImplementedException();
        }

        internal void PracticeBasicLinq()
        {
            //var emps = LinqBasicProblems.GetAllEmployeesAsList();
             //   var emps = LinqBasicProblems.GetAllEmployeesAsEnumerable();
            //    var empsByDeptId = LinqBasicProblems.GetEmployeesLookupByDepartmentId();
            //    var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            //    var allDepartments = LinqBasicProblems.GetAllDepartmentAsList();
            //    var allEmployees = LinqBasicProblems.GetAllEmployeesAsICollection();
            //    var alldepartments = LinqBasicProblems.GetAllDepartmentNames();
            //    var allEmployees = LinqBasicProblems.GetAllEmployeeFirstNames();
            //    var emp = LinqBasicProblems.GetAllEmployeesAsIList();
              var emp = LinqBasicProblems.GetEmployeesLookupByDepartmentId();

            //var empnames = LinqBasicProblems.AllEmployeesFullNames();
            // Add more calls to LinqBasicProblems methods as needed  
        }

        internal void PracticeBeginnerLinq()
        {

            //var employeesWithHighSalary = LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();
            //var allemployees = LinqBeginnerProblems.GetEmployeesByDepartmentId(1);
            //var employees = LinqBeginnerProblems.GetEmployeesByBloodGroup(Models.Enums.BloodGroups.AB_Positive);
            //var allemployees = LinqBeginnerProblems.GetEmployeesByLastName("Reddy");

            //var allemployeesdates = LinqBeginnerProblems.GetEmployeesJoinedInYear(2015);
            //var allemployeesyears = LinqBeginnerProblems.GetEmployeesWithMoreThan5YearsExp();
            //var allemployeesyears = LinqBeginnerProblems.GetEmployeesWithNullQualification();
            //var allemployeesyears = LinqBeginnerProblems.GetEmployeesWithAlternateMobile();
            //vqrllemployeesyears = LinqBeginnerProblems.GetEmployeesFirstNameStartsWithA();
            //var allemployees = LinqBeginnerProblems.GetEmployeesLastNameEndsWithA();
            //var allemployees = LinqBeginnerProblems.GetEmployeesWithEmailContainingAbc();
            //var allemployees = LinqBeginnerProblems.GetEmployeesByAddressCity("New York");
            //var allemployees = LinqBeginnerProblems.GetEmployeesWithAtLeastTwoAddresses();

        }   
        


        internal void practiceintermediatelinq()
        {
            //var allemployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            var allemployee = LinqIntermediateProblems.GetDepartmentsWithMoreThan2Employees();
            //var employeedepts = LinqIntermediateProblems.GetEmployeesGroupedByDepartmentName();
            //var depts = LinqIntermediateProblems.GetDepartmentNameIdGroup();
            //var depts = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            //var depts = LinqIntermediateProblems.GetOnlyEmployeeNames();
            //var depts = LinqIntermediateProblems.GetAverageSalaryPerDepartment();
            //var depts = LinqIntermediateProblems.GetHighestPaidEmployeePerDepartment();
            //var depts = LinqIntermediateProblems.GetEmployeesWhoWereTeamLeads();
            //var joiningdate = LinqIntermediateProblems.GetEmployeesJoinedAfter(new DateTime(2020, 1, 1));
            //var joiningdate = LinqIntermediateProblems.GetEmployeesWithPresentAndPermanentAddresses();
            //var multipleaddress = LinqIntermediateProblems.GetEmployeesWithMultipleAddresses();
            // add more calls to linqbasicproblems methods as needed  
            //var removeemployee = LinqIntermediateProblems.GetEmployeesAndRemoveInactive();
            //var designation = LinqIntermediateProblems.GetEmployeesWithDesignationInHistory(EMS.Models.Enums.DesiginationTypes.TeamLead);
            //var genders = LinqIntermediateProblems.GetEmployeesGroupedByGender();
            //var qualifications = LinqIntermediateProblems.GetEmployeesByQualificationId(1);
        }
    }
}
