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
        internal void PracticeBasicLinq()
        {
            var allEmployees = LinqBasicProblems.GetAllEmployeesAsList();
            // Add more calls to LinqBasicProblems methods as needed  
        }

        internal void PracticeIntermediateLinq()
        {
            var allEmployees = LinqIntermediateProblems.GetEmployeeCountByBloodGroup();
            // Add more calls to LinqBasicProblems methods as needed  
        }
    }
}
