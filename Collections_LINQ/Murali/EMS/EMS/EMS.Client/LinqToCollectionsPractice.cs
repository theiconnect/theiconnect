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
            //  var emps = LinqBasicProblems.GetAllEmployeesAsEnumerable();
            // var employeesAsIcollection = LinqBasicProblems.GetAllEmployeesAsICollection();
            //var allEmployeesAsIlist = LinqBasicProblems.GetAllEmployeesAsIList();
            // var empsByDeptId = LinqBasicProblems.GetAllDepartmentsAsList();
            //var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            // var departmentname= LinqBasicProblems.GetAllDepartmentNames();
            //var employeesfirstname = LinqBasicProblems.GetAllEmployeeFirstNames();
            //var activeEmployees= LinqBasicProblems.GetActiveEmployeesAsEnumerable();
            //var inActiveEmployeeAsList = LinqBasicProblems.GetInactiveEmployeesAsList();
            //var employeesWithHighSalary= LinqBasicProblems.GetEmployeesWithHighSalary();
            //var employeesOrderByFirstName= LinqBasicProblems.GetEmployeesOrderedByFirstName();
           // var employeesOrderedBySalaryDesc = LinqBasicProblems.GetEmployeesOrderedBySalaryDesc();
           //var allDepartmentCodesAsICollection = LinqBasicProblems.GetAllDepartmentCodesAsICollection();
           //var allEmployeesAsDictionary = LinqBasicProblems.GetAllEmployeesAsDictionary();
           //var employeesLookupByDepartmentId = LinqBasicProblems.GetEmployeesLookupByDepartmentId();
          // var allEmployeesAsHashSet = LinqBasicProblems.GetAllEmployeesAsHashSet();
          //var allEmployeesAsArray = LinqBasicProblems.GetAllEmployeesAsArray();
         
            // Add more calls to LinqBasicProblems methods as needed  
        }

        internal void PracticeBeginnerLinq()
        {

            //var emp = LinqBeginnerProblems.GetActiveEmployeesWithHighSalary();

            //var employeesByDepartmentId = LinqBeginnerProblems.GetEmployeesByDepartmentId(1);
            //var employeesByBloodGroup = LinqBeginnerProblems.GetEmployeesByBloodGroup(Models.Enums.BloodGroups.B_Positive);
            //var employeesByLastName = LinqBeginnerProblems.GetEmployeesByLastName("kumar");
            //var employeesJoinedInYear = LinqBeginnerProblems.GetEmployeesJoinedInYear((2020));
            //var employeesWithMoreThan5YearsExp= LinqBeginnerProblems.GetEmployeesWithMoreThan5YearsExp();
           // var employeesWithNullQualification= LinqBeginnerProblems.GetEmployeesWithNullQualification();
            //var employeesWithAlternateMobile = LinqBeginnerProblems.GetEmployeesWithAlternateMobile();
            //var employeesFirstNameStartsWithA = LinqBeginnerProblems.GetEmployeesFirstNameStartsWithA();
            //var employeesLastNameEndsWithA = LinqBeginnerProblems.GetEmployeesLastNameEndsWithA();
            // var employeesWithEmailContainingAbc= LinqBeginnerProblems.GetEmployeesWithEmailContainingAbc();
            // var employeesWithSalaryRange = LinqBeginnerProblems.GetEmployeesWithSalaryRange();
            //var employeesByDesignation = LinqBeginnerProblems.GetEmployeesByDesignation(Models.Enums.DesiginationTypes.SeniorDeveloper);
            //var employeesByGender = LinqBeginnerProblems.GetEmployeesByGender(Models.Enums.Genders.Female);
            //var employeesByAddressCity = LinqBeginnerProblems.GetEmployeesByAddressCity("Chennai");
            // var employeesWithAtLeastTwoAddresses = LinqBeginnerProblems.GetEmployeesWithAtLeastTwoAddresses();
            //var employeesAsQueryableWithEFOnlyMethod = LinqBeginnerProblems.GetEmployeesAsQueryableWithEFOnlyMethod();
            //var allEmployeesAsICollectionAndUseLinq = LinqBeginnerProblems.GetAllEmployeesAsICollectionAndUseLinq();
        }

        internal void PracticeIntermediateLinq()
        {
            //var allEmployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            //var departmentsWithMoreThan2Employees = LinqIntermediateProblems.GetDepartmentsWithMoreThan2Employees();
            //var employeesGroupedByDepartmentName = LinqIntermediateProblems.GetEmployeesGroupedByDepartmentName();
            //var employeeCountByBloodGroup = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            //var averageSalaryPerDepartment = LinqIntermediateProblems.GetAverageSalaryPerDepartment();
            //var highestPaidEmployeePerDepartment = LinqIntermediateProblems.GetHighestPaidEmployeePerDepartment();
            var employeesWhoWereTeamLeads = LinqIntermediateProblems.GetEmployeesWhoWereTeamLeads();
            //var employeesJoinedAfter = LinqIntermediateProblems.GetEmployeesJoinedAfter(new DateTime(2020, 1, 15));
            // var employeesWithPresentAndPermanentAddresses = LinqIntermediateProblems.GetEmployeesWithPresentAndPermanentAddresses();
            // var employeesWithMultipleAddresses = LinqIntermediateProblems.GetEmployeesWithMultipleAddresses();
            //var employeesWithQualification = LinqIntermediateProblems.GetEmployeesWithQualification();
            //var employeesWithAddressInState = LinqIntermediateProblems.GetEmployeesWithAddressInState("AP");
            // var employeesGroupedByGender = LinqIntermediateProblems.GetEmployeesGroupedByGender();
            // var employeesByQualificationId = LinqIntermediateProblems.GetEmployeesByQualificationId(5);
            //var employeesByDepartmentName = LinqIntermediateProblems.GetEmployeesByDepartmentName("Development");
             //var employeesWithDesignationInHistory = LinqIntermediateProblems.GetEmployeesWithDesignationInHistory(designation:DesiginationTypes.JuniorDeveloper);
            //var employeesAndRemoveInactive = LinqIntermediateProblems.GetEmployeesAndRemoveInactive();
            //var GetEmployeesAndRemoveInactive = LinqIntermediateProblems.GetEmployeesAndRemoveInactive();
            // Add more calls to LinqBasicProblems methods as needed  
        }
    }
}
