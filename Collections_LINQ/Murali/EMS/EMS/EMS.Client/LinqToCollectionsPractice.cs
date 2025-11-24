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
            //var empList = LinqBasicProblems.GetAllEmployeesAsList();
          var empsByDeptId = LinqBasicProblems.GetAllDepartmentsAsList();
           // var empsByDeptEnum = LinqBasicProblems.GetAllDepartmentsAsEnumerable();
            //var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            // Add more calls to LinqBasicProblems methods as needed  
        }

        internal void PracticeBeginnerLinq()
        {
            throw new NotImplementedException();
        }

        internal void PracticeIntermediateLinq()
        {
            var allEmployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            // Add more calls to LinqBasicProblems methods as needed  
        }
    }
}
