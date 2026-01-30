using EMS.IDataAccess;
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

namespace EMS.DataAccess.ADO
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static string ConnectionString { get; set; }
        public EmployeeRepository(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                using SqlCommand cmd = new SqlCommand("usp_GetAllEmployees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeModel model = new EmployeeModel();
                    model.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
                    model.Employeecode = Convert.ToString(reader["EmployeeCode"]);
                    model.FirstName = Convert.ToString(reader["FirstName"]);
                    model.LastName = Convert.ToString(reader["LastName"]);
                    if (reader["BloodGroup"] != DBNull.Value)
                        model.BloodGroup = (BloodGroups)Convert.ToInt32(reader["BloodGroup"]);
                    model.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                    if (reader["Gender"] != DBNull.Value)
                        model.Gender = (Genders)Convert.ToInt32(reader["Gender"]);
                    model.EmailId = Convert.ToString(reader["EmailId"]);
                    if (reader["DateOfBirth"] != DBNull.Value)
                        model.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    if (reader["DateOfJoining"] != DBNull.Value)
                        model.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                    model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    if (reader["ExpInMonths"] != DBNull.Value)
                        model.ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]);
                    if (reader["SalaryCtc"] != DBNull.Value)
                        model.SalaryCtc = Convert.ToDecimal(reader["SalaryCtc"]);
                    employees.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading employees" + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return employees;
        }

        public EmployeeModel GetEmployeeDetailsById(int EmployeeId)
        {
            EmployeeModel model = new EmployeeModel();
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                using SqlCommand cmd = new SqlCommand("usp_GetEmployeeDetailsById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPk"]);
                    model.Employeecode = Convert.ToString(reader["EmployeeCode"]);
                    model.FirstName = Convert.ToString(reader["FirstName"]);
                    model.LastName = Convert.ToString(reader["LastName"]);
                    model.BloodGroup = (BloodGroups)Convert.ToInt32(reader["BloodGroup"]);
                    model.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                    model.Gender = (Genders)Convert.ToInt32(reader["Gender"]);
                    model.EmailId = Convert.ToString(reader["EmailId"]);
                    model.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    model.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                    model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    model.ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]);
                    model.SalaryCtc = Convert.ToDecimal(reader["SalaryCtc"]);
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        EmployeeAddressModel addressModel = new EmployeeAddressModel();
                        addressModel.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                        addressModel.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                        addressModel.City = Convert.ToString(reader["City"]);
                        addressModel.State = Convert.ToString(reader["State"]);
                        addressModel.Pincode = Convert.ToString(reader["PINCode"]);
                        addressModel.AddressTypeIdFk = (AddressTypes)Convert.ToInt32(reader["AddressTypeIdFk"]);
                        model.Addresses.Add(addressModel);
                    }
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        EmployeeAddressModel addressHistory = new EmployeeAddressModel();
                        addressHistory.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                        addressHistory.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                        addressHistory.City = Convert.ToString(reader["City"]);
                        addressHistory.State = Convert.ToString(reader["State"]);
                        addressHistory.Pincode = Convert.ToString(reader["PINCode"]);
                        addressHistory.AddressTypeIdFk = (AddressTypes)Convert.ToInt32(reader["AddressTypeIdFk"]);

                        model.AddressHistory.Add(addressHistory);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading employees" + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return model;
        }

        public bool SaveEmployee(EmployeeModel model, bool isNewEmployee, string userName, out string responseMessage)
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

                command.Parameters.AddWithValue("@EmployeeIdPk", model.EmployeeIdPk);
                command.Parameters.AddWithValue("@EmployeeCode", model.Employeecode);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@BloodGroup", model.BloodGroup);
                command.Parameters.AddWithValue("@MobileNumber", model.MobileNumber);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@EmailId", model.EmailId);
                command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                command.Parameters.AddWithValue("@DateOfJoining", model.DateOfJoining);
                command.Parameters.AddWithValue("@ExpInMonths", model.ExpInMonths);
                command.Parameters.AddWithValue("@SalaryCtc", model.SalaryCtc);
                command.Parameters.AddWithValue("@IsActive", model.IsActive);
                command.Parameters.AddWithValue("@UserName", userName);

                var permAddr = model.Addresses.Find(a => a.AddressTypeIdFk == AddressTypes.PERM_ADDR);
                var presAddr = model.Addresses.Find(a => a.AddressTypeIdFk == AddressTypes.PRESENT_ADDR);

                command.Parameters.AddWithValue("@PERM_AddressLine1", permAddr.AddressLine1);
                command.Parameters.AddWithValue("@PERM_AddressLine2", permAddr.AddressLine2);
                command.Parameters.AddWithValue("@PERM_City", permAddr.City);
                command.Parameters.AddWithValue("@PERM_State", permAddr.State);
                command.Parameters.AddWithValue("@PERM_PIN", permAddr.Pincode);

                command.Parameters.AddWithValue("@Pres_AddressLine1", presAddr.AddressLine1);
                command.Parameters.AddWithValue("@Pres_AddressLine2", presAddr.AddressLine2);
                command.Parameters.AddWithValue("@Pres_City", presAddr.City);
                command.Parameters.AddWithValue("@Pres_State", presAddr.State);
                command.Parameters.AddWithValue("@Pres_PIN", presAddr.Pincode);

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
            return true;
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






















//public EmployeeModel GetEmployeeById(int employeeId)
//{
//    using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
//    try
//    {
//        using SqlCommand command = new SqlCommand("usp_GetDepartmentById", sqlConnection);
//        command.CommandType = CommandType.StoredProcedure;

//        command.Parameters.AddWithValue("@EmployeeId", employeeId);

//        sqlConnection.Open();
//        using SqlDataReader dr = command.ExecuteReader();

//        if (dr.Read())
//        {
//            EmployeeModel employee = new EmployeeModel();
//            employee.EmployeeIdPk = Convert.ToInt32(dr["EmployeeIdPk"]);
//            employee.Employeecode = Convert.ToString(dr["EmployeeCode"]);
//            employee.FirstName = Convert.ToString(dr["FirstName"]);
//            employee.LastName = Convert.ToString(dr["LastName"]);
//            employee.MobileNumber = Convert.ToString(dr["MobileNumber"]);
//            employee.Gender = (Genders)Convert.ToInt32(dr["Gender"]);
//            employee.EmailId = Convert.ToString(dr["EmailId"]);
//            employee.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
//            employee.IsActive = Convert.ToBoolean(dr["IsActive"]);
//            employee.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
//            if (dr["LastUpdatedOn"] != DBNull.Value)
//                employee.LastUpdatedOn = Convert.ToDateTime(dr["LastUpdatedOn"]);
//            return employee;
//        }
//        else
//        {
//            return new EmployeeModel();
//        }
//    }
//    catch (Exception ex)
//    {
//        return new EmployeeModel();
//    }
//    finally
//    {
//        //Any cleanup code
//        if (sqlConnection.State == ConnectionState.Open)
//            sqlConnection.Close();
//    }
//}


