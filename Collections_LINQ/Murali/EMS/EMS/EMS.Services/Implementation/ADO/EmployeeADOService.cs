using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;


namespace EMS.Services.Implementation.ADO
{
    public class EmployeeADOService : IEmployeeService
    {
        public static string connectionString = "Data Source=anuvenkata\\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True; TrustServerCertificate=True";

        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        {
            throw new NotImplementedException();
        }

        public EmployeeModel GetEmployeeByID(int empId)
        {
            throw new NotImplementedException();
        }


        public List<EmployeeModel> GetAllEmployees()
        {
            string query = @"SELECT 
                              EmployeeIdPk,
                              Code,
                              FirstName,
                              MobileNumber,
                              Gender,
                              EmailId,
                              IsActive
                              FROM dbo.Employee";
            var employees = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeModel model = new EmployeeModel();
                                model.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
                                model.Employeecode = Convert.ToString(reader["Code"]);
                                model.FirstName = Convert.ToString(reader["FirstName"]);
                                model.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                                model.Gender = Enum.Parse<Models.Enums.Genders>(reader["Gender"].ToString());
                                model.EmailId = Convert.ToString(reader["EmailId"]);
                                model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                employees.Add(model);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error reading employees", ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                    return employees;

                }
            }
        }

        
    }
}

        
        
