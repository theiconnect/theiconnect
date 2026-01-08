using EMS.IServices;
using EMS.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EMS.Services.Implementation.ADO
{
    public class EmployeeADOService: IEmployeeService
    {
        public static string ConnectionString = @"Data Source=LAPTOP-9LRGN9NO\SAIPRASADMSSQL;Initial Catalog = EMS; Integrated Security = True; TrustServerCertificate=True";

        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<EmployeeModel> employees = new List<EmployeeModel>();
                while(reader.Read())
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
                    emp.Employeecode = reader["EmployeeCode"].ToString();
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.MiddleName = reader["MiddleName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    // Map other properties as needed
                    employees.Add(emp);
                }
                return employees;
            }
        }

        public EmployeeModel GetEmployeeByID(int empId)
        {
            throw new NotImplementedException();
        }
    }

   
}
