using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


//namespace EMS.Services.Implementation.ADO
//{
//    public class EmployeeADOService : IEmployeeService
//    {
//        public static string connectionString = "Data Source=LAPTOP-CP66449K;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

//        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
//        {
//            throw new NotImplementedException();
//        }

//        public List<EmployeeModel> GetAllEmployees()
//        {
//            List<EmployeeModel> employees = new List<EmployeeModel>();
//            using SqlConnection con = new SqlConnection(connectionString);
//            using SqlCommand cmd = new SqlCommand("usp_getallEmployees", con);
//            cmd.CommandType = CommandType.StoredProcedure;
//            try
//            {
//                con.Open();
//                using SqlDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    EmployeeModel model = new EmployeeModel();
//                    model.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
//                    model.FirstName = Convert.ToString(reader["FirstName"]);
//                    model.LastName = Convert.ToString(reader["LastName"]);
//                    model.MobileNumber = Convert.ToString(reader["MobileNumber"]);
//                    model.EmailId = Convert.ToString(reader["EmailId"]);
//                    model.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
//                    model.IsActive = Convert.ToBoolean(reader["IsActive"]);
//                    employees.Add(model);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error reading employees" + ex.Message);
//            }
//            finally
//            {
//                if (con.State == ConnectionState.Open)
//                    con.Close();
//            }
//            return employees;
//        }

//        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
//        {
//            throw new NotImplementedException();
//        }

//        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
//        {
//            using SqlConnection sqlConnection = new SqlConnection(connectionString);
//            try
//            {
//                SqlCommand command = new SqlCommand("dbo.updateEmployees", sqlConnection);
//                command.CommandType = CommandType.StoredProcedure;
//                command.Parameters.AddWithValue("@EmployeeIdPk", "EmployeeIdPk");
//                command.Parameters.AddWithValue("@Code", "Code");
//                command.Parameters.AddWithValue("@FirstName", "FirstName");
//                command.Parameters.AddWithValue("@LastName", "LastName");
//                command.Parameters.AddWithValue("@Bloodgroup", "Bloodgroup");
//                command.Parameters.AddWithValue("@Gender", "Gender");
//                command.Parameters.AddWithValue("@EmailId", "EmailId");
//                command.Parameters.AddWithValue("@MobileNumber", "MobileNumber");
//                command.Parameters.AddWithValue("@DateOfBirth", "DateOfBirth");
//                command.Parameters.AddWithValue("@DateOfJoining", "DateOfJoining");
//                command.Parameters.AddWithValue("@ExpInMonths", "ExpInMonths");
//                command.Parameters.AddWithValue("@SalaryCtc", "SalaryCtc");
//                command.Parameters.AddWithValue("@IsActive", "IsActive");

//                sqlConnection.Open();

//                command.ExecuteNonQuery();

//                responseMessage = "Not implemented";
//                return true;
//            }
//            catch (Exception Ex)
//            {
//                responseMessage = "Not implemented";
//                return false;
//            }
//        }

//        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, out string responseMessage)
//        {
//            throw new NotImplementedException();
//        }

//        public EmployeeModel GetEmployeeByID(int empId)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

