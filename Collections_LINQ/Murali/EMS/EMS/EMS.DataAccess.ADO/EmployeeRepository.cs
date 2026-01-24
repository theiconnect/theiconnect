using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;

namespace EMS.DataAccess.ADO
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static string ConnectionString { get; set; }
        public EmployeeRepository(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;

        }
        public List<EmployeeModel> GetEmployeeDetails()
        {
            string query = @"SELECT
        -- Employee
        EmployeeIdPk,
        EmployeeCode,
        FirstName,
        MiddleName,
        LastName,
        EmailId,
        PersonalEmailId,
        GenderIdFk,
        MobileNumber,
        AlternateMobileNumber,
        DateOfBirth,
        DateOfJoining,
        ExpInMonths,
        LWD
    from dbo.Employee";
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            EmployeeModel employee = new EmployeeModel();
                            employee.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
                            employee.Employeecode = reader["EmployeeCode"].ToString();
                            employee.FirstName = reader["FirstName"].ToString();
                            employee.MiddleName = reader["MiddleName"].ToString();
                            employee.LastName = reader["LastName"].ToString();  
                            employee.EmailId = reader["EmailId"].ToString();
                            employee.Gender = (Genders)Convert.ToInt32(reader["GenderIdFk"]);
                            employee.PersonalEmailId = reader["PersonalEmailId"].ToString();
                            employee.MobileNumber = reader["MobileNumber"].ToString();
                            employee.AlternateMobileNumber = reader["AlternateMobileNumber"].ToString();
                            employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            employee.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                            employee.ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]);
                            employee.LWD = reader["LWD"] != DBNull.Value ? Convert.ToDateTime(reader["LWD"]) : null;

                            employees.Add(employee);
         
                        }
                    }
                }
            }
            return employees;
        }
        public bool AddUpdateEmployeeAddress(CompanyAddressModel addressModel, string UserId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeeAddress(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        
    }
}
