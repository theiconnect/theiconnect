using System;
using System.Collections.Generic;
using System.Data;
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
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getallEmployees", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                            employee.BloodGroup = (BloodGroups)Convert.ToInt32(reader["BloodGroupIdFk"]);   
                            employee.PersonalEmailId = reader["PersonalEmailId"].ToString();
                            employee.MobileNumber = reader["MobileNumber"].ToString();
                            employee.AlternateMobileNumber = reader["AlternateMobileNumber"].ToString();
                            employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            employee.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                            employee.ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]);
                            employee.SalaryCtc = reader["SalaryCtc"] != DBNull.Value ? Convert.ToDecimal(reader["SalaryCtc"]) : null;
                            employee.LWD = reader["LWD"] != DBNull.Value ? Convert.ToDateTime(reader["LWD"]) : null;
                            employee.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            employees.Add(employee);
         
                        }
                    }
                }
            }
            return employees;
        }
        public bool AddUpdateEmployeeAddress(EmployeeModel Model, string UserId, out string errorMessage)
        {
            errorMessage = null;
            return true;
        }

        public bool DeleteEmployeeAddress(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            responseMessage = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_ManageEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (isNewEmployee)
                        {
                            command.Parameters.AddWithValue("@ActionType", "ADD");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ActionType", "UPDATE");
                        }
                        command.Parameters.AddWithValue("@EmployeeIdPk", inputEmployee.EmployeeIdPk);
                        command.Parameters.AddWithValue("@EmployeeCode", inputEmployee.Employeecode);
                        command.Parameters.AddWithValue("@firstName", inputEmployee.FirstName);
                        command.Parameters.AddWithValue("@lastName", inputEmployee.LastName);
                        command.Parameters.AddWithValue("@genderIdFk", inputEmployee.Gender);
                        command.Parameters.AddWithValue("@bloodGroupIdFk", inputEmployee.BloodGroup);
                        command.Parameters.AddWithValue("@emailId", inputEmployee.EmailId);
                        command.Parameters.AddWithValue("@mobileNumber", inputEmployee.MobileNumber);
                        command.Parameters.AddWithValue("@dateOfBirth", inputEmployee.DateOfBirth);
                        command.Parameters.AddWithValue("@dateOfJoining", inputEmployee.DateOfJoining);
                        command.Parameters.AddWithValue("@expInMonths", inputEmployee.ExpInMonths);
                        command.Parameters.AddWithValue("@salaryCTc", inputEmployee.SalaryCtc);
                        command.Parameters.AddWithValue("@isActive", inputEmployee.IsActive);
                        command.Parameters.AddWithValue("@UserName", userName);
                        SqlParameter parameter = new("@OutputMessage", SqlDbType.NVarChar, 500)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        return true;
        }

        public bool ActivateDeactivateEmp(int EmployeeId, bool isDeactivate, String userName, out string responseMessage)
        {
            using SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_deactivateActivate", sqlconnection);
                command.CommandType = CommandType.StoredProcedure;
                if (isDeactivate)
                    command.Parameters.AddWithValue("@ActionType", "DELETE");
                else
                    command.Parameters.AddWithValue("@ActionType", "Activate");
                command.Parameters.AddWithValue("@EmployeeIdPk", EmployeeId);
                command.Parameters.AddWithValue("@UserName", userName);
                SqlParameter outputParam = new("@OutputMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(outputParam);
                sqlconnection.Open();
                command.ExecuteNonQuery();
                responseMessage = Convert.ToString(outputParam.Value);
            }
            catch (Exception ex)
            {
                responseMessage = "Error:" + ex.Message;
                return false;
            }
            finally
            {
                if (sqlconnection.State == ConnectionState.Open)
                    sqlconnection.Close();
            }
            if (responseMessage.ToLower() == "success")
                return true;
            else
                return false;
        }
    }
}
