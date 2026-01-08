using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


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
                        throw new Exception("Error reading employees");
                    }
                    finally
                    {
                        con.Close();
                    }
                    return employees;

                }
            }
        }
        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using SqlCommand command = new SqlCommand("dbo.AddEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeIdPk", inputEmployee.EmployeeIdPk);
                command.Parameters.AddWithValue("@Code", inputEmployee.Employeecode);
                command.Parameters.AddWithValue("@FirstName", inputEmployee.FirstName);
                command.Parameters.AddWithValue("@MobileNumber", inputEmployee.MobileNumber);
                command.Parameters.AddWithValue("@Gender", inputEmployee.Gender);
                command.Parameters.AddWithValue("@EmailId", inputEmployee.EmailId);
                command.Parameters.AddWithValue("@IsActive", inputEmployee.IsActive);
                SqlParameter outputParam = new("@OutputMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(outputParam);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                responseMessage = Convert.ToString(outputParam.Value);
            }
            catch (Exception ex)
            {
                responseMessage = "Error: " + ex.Message;
                return false;
            }
            finally
            {
                //Any cleanup code
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            if (responseMessage.ToLower() == "success")
                return true;
            else
                return false;

        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}

        
        
