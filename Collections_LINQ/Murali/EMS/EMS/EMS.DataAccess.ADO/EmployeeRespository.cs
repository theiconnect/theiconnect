using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using EMS.IDataAccess;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace EMS.DataAccess.ADO
{
    public class EmployeeRespository : IEmployeeRepository
    {


        private static string ConnectionString { get; set; }
        public object Cmd { get; private set; }

        public EmployeeRespository(string _connectionString)
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
                    EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
                    employee.Employeecode = Convert.ToString(reader["Employeecode"]);
                    employee.FirstName = Convert.ToString(reader["FirstName"]);
                    employee.LastName = Convert.ToString(reader["LastName"]);
                    employee.BloodGroup = (BloodGroups)Convert.ToInt32(reader["BloodGroup"]);
                    employee.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                    employee.Gender = (Genders)Convert.ToInt32(reader["Gender"]);
                    employee.EmailId = Convert.ToString(reader["EmailId"]);
                    employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    employee.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                    employee.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    employee.ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]);
                    employee.SalaryCtc = Convert.ToDecimal(reader["SalaryCtc"]);
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving employee details.", ex);
            }
            finally
            {
                con.Close();
            }
            return employees;
        }
        //public EmployeeModel GetEmployeeById(int employeeId)
        //{
        //    using SqlConnection con = new SqlConnection(ConnectionString);
        //    try
        //    {
        //        using SqlCommand cmd = new SqlCommand("usp_GetEmployeeById", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@EmployeeIdPk", employeeId);
        //        con.Open();
        //        using SqlDataReader reader = cmd.ExecuteReader();

        //        if(reader.Read())
        //        {
        //            EmployeeModel model= new EmployeeModel();
        //            model.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
        //            model.Employeecode = Convert.ToString(reader["Employeecode"]);
        //            model.FirstName = Convert.ToString(reader["FirstName"]);
        //            model.LastName = Convert.ToString(reader["LastName"]);
        //            model.MobileNumber = Convert.ToString(reader["MobileNumber"]);
        //            model.Gender = (Genders)Convert.ToInt32(reader["Gender"]);
        //            model.EmailId = Convert.ToString(reader["EmailId"]);
        //            model.IsActive = Convert.ToBoolean(reader["IsActive"]);
        //            return model;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while retrieving employee details by ID.", ex);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //}
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
                command.Parameters.AddWithValue("@BloodGroup", (int)inputEmployee.BloodGroup);
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
        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate,string userName, out string errorMesssage)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (isDeactivate)
                    cmd.Parameters.AddWithValue("@ActionType", "DELETE");
                else
                    cmd.Parameters.AddWithValue("@ActionType", "ACTIVATE");
                cmd.Parameters.AddWithValue("@EmployeeIdPk", employeeId);
                cmd.Parameters.AddWithValue("@UserName", userName);
                SqlParameter outputparam = new("OutputMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output,
                };
                cmd.Parameters.Add(outputparam);
                con.Open();
                cmd.ExecuteNonQuery();
                errorMesssage = Convert.ToString(outputparam.Value);
                return string.IsNullOrEmpty(errorMesssage);
            }
            catch (Exception ex)
            {
                errorMesssage = "An error occurred while activating/deactivating employee: " + ex.Message;
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}



