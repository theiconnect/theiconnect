using EMS.IDataAccess;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccess.ADO
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static string ConnectionString { get; set; }
        public EmployeeRepository(string _connectionString)
        {
            ConnectionString = _connectionString;
        }

        public List<EmployeeModel> GetEmployeeDetails()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand cmd = new SqlCommand("usp_GetEmployeeDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeModel employee = new EmployeeModel
                    {
                        EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]),
                        Employeecode = Convert.ToString(reader["EmployeeCode"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        BloodGroup=(BloodGroups) Convert.ToInt32(reader["BloodGroup"]),
                        Gender = (Genders)Convert.ToInt32(reader["Gender"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                        MobileNumber = Convert.ToString(reader["MobileNumber"]),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]),
                        ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]),
                        SalaryCtc = Convert.ToDecimal(reader["SalaryCtc"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                    employees.Add(employee);
                }
                return employees;
            }
            catch (Exception ex)
            {
                // Log exception (not implemented here)
                throw new Exception("An error occurred while retrieving Employee details.", ex);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            
        }


        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_ManageEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                if (isNewEmployee)
                    command.Parameters.AddWithValue("@ActionType", "ADD");
                else
                    command.Parameters.AddWithValue("@ActionType", "UPDATE");

                command.Parameters.AddWithValue("@EmployeeIdPk", inputEmployee.EmployeeIdPk);
                command.Parameters.AddWithValue("@EmployeeCode", inputEmployee.Employeecode);
                command.Parameters.AddWithValue("@FirstName", inputEmployee.FirstName);
                command.Parameters.AddWithValue("@LastName", inputEmployee.LastName);
                command.Parameters.AddWithValue("@BloodGroup", inputEmployee.BloodGroup);
                command.Parameters.AddWithValue("@MobileNumber", inputEmployee.MobileNumber);
                command.Parameters.AddWithValue("@Gender", inputEmployee.Gender);
                command.Parameters.AddWithValue("@EmailId", inputEmployee.EmailId);
                command.Parameters.AddWithValue("@DateOfBirth", inputEmployee.DateOfBirth);
                command.Parameters.AddWithValue("@DateOfJoining", inputEmployee.DateOfJoining);
                command.Parameters.AddWithValue("@ExpInMonths", inputEmployee.ExpInMonths);
                command.Parameters.AddWithValue("@SalaryCtc", inputEmployee.SalaryCtc);
                command.Parameters.AddWithValue("@IsActive", inputEmployee.IsActive);
                command.Parameters.AddWithValue("@UserName", userName);
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

        public bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, String userName, out string responseMessage)
        {
            using SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_DeleteEmployee", sqlconnection);
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
