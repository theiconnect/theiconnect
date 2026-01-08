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
        public static string connectionString = "Data Source=DESKTOP-UG9N4R1;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

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
                             FROM dbo.EmpViewDetails1";
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
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                    return employees;

                }
            }
        }
        public EmployeeModel GetEmployeeById(int EmployeeIdPk)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);


            using SqlCommand command = new SqlCommand("dbo.ViewEmpViewDetails1", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeIdPk", EmployeeIdPk);

            sqlConnection.Open();

            using SqlDataReader datareader = command.ExecuteReader();
            {
                while (datareader.Read())
                {

                    EmployeeModel Model = new EmployeeModel();
                    {

                        Model.EmployeeIdPk = Convert.ToInt32(datareader["EmployeeIdPk"]);
                        Model.Employeecode = Convert.ToString(datareader["Code"]);
                        Model.FirstName = Convert.ToString(datareader["FirstName"]);
                        Model.LastName = Convert.ToString(datareader["LastName"]);
                        Model.BloodGroup = (BloodGroups)Convert.ToInt32(datareader["Bloodgroup"]);
                        Model.Gender = (Genders)Convert.ToInt32(datareader["Gender"]);
                        Model.EmailId = Convert.ToString(datareader["EmailId"]);
                        Model.MobileNumber = Convert.ToString(datareader["MobileNumber"]);
                        Model.DateOfBirth = Convert.ToDateTime(datareader["DateOfBirth"]);
                        Model.DateOfJoining = Convert.ToDateTime(datareader["DateOfJoining"]);
                        Model.ExpInMonths = Convert.ToInt32(datareader["ExpInMonths"]);
                        Model.SalaryCtc = Convert.ToDecimal(datareader["SalaryCtc"]);
                        Model.IsActive = Convert.ToBoolean(datareader["IsActive"]);
                    }
                    ;

                    return Model;
                }
                return null;
            }

        }


    }
}

        
        
