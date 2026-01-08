using EMS.IServices;
using EMS.Models;
<<<<<<< HEAD
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
=======
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
>>>>>>> origin/main


namespace EMS.Services.Implementation.ADO
{
<<<<<<< HEAD
    public class EmployeeADOService: IEmployeeService
    {
        public static string ConnectionString = @"Data Source=LAPTOP-9LRGN9NO\SAIPRASADMSSQL;Initial Catalog = EMS; Integrated Security = True; TrustServerCertificate=True";

        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }
=======
    public class EmployeeADOService : IEmployeeService
    {
        public static string connectionString = "Data Source=chereddy\\VIJAY;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

>>>>>>> origin/main

        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
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

=======
>>>>>>> origin/main
        public EmployeeModel GetEmployeeByID(int empId)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD
    }

   
}
=======


        public List<EmployeeModel> GetAllEmployees()
        {
            string query = @"SELECT
                             EmployeeIdPK,
                             Code,
                             FirstName,
		                     MobileNumber,
                             Gender,
                             EmailId,
                             IsActive
                             FROM Employee1";
            var employees = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        //DataTable data = new DataTable();
                        //DataSet dataset = new DataSet();
                        //DataAdapter neobjw = new DataAdapter();
                        
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeModel model = new EmployeeModel();
                                model.EmployeeIdPk = Convert.ToInt32(reader["EmployeeIdPK"]);
                                model.Employeecode = Convert.ToString(reader["Code"]);
                                model.FirstName = Convert.ToString(reader["FirstName"]);
                                model.MobileNumber = Convert.ToString(reader["MobileNumber"]);
                                model.Gender = (Genders)Convert.ToInt32(reader["Gender"]);
                                model.EmailId = Convert.ToString(reader["EmailId"]);
                                model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                employees.Add(model);
                            }
                                
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    return employees;

                }
            }
        }

<<<<<<< HEAD
        public EmployeeModel GetAllEmployeeId(int EmployeeIdPk)
=======
        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }
        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
>>>>>>> origin/main
        {
            using SqlConnection sqlConnection= new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand("dbo.updateEmployees", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeIdPk", "EmployeeIdPk");
                command.Parameters.AddWithValue("@Code","Code");
                command.Parameters.AddWithValue("@FirstName", "FirstName");
                command.Parameters.AddWithValue("@LastName", "LastName");
                command.Parameters.AddWithValue("@Bloodgroup", "Bloodgroup");
                command.Parameters.AddWithValue("@Gender", "Gender");
                command.Parameters.AddWithValue("@EmailId", "EmailId");
                command.Parameters.AddWithValue("@MobileNumber", "MobileNumber");
                command.Parameters.AddWithValue("@DateOfBirth", "DateOfBirth");
                command.Parameters.AddWithValue("@DateOfJoining", "DateOfJoining");
                command.Parameters.AddWithValue("@ExpInMonths", "ExpInMonths");
                command.Parameters.AddWithValue("@SalaryCtc", "SalaryCtc");
                command.Parameters.AddWithValue("@IsActive", "IsActive");

                sqlConnection.Open();

                using SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {

                    EmployeeModel Model = new EmployeeModel();

                    Model.EmployeeIdPk = Convert.ToInt32(dr[EmployeeIdPk]);
                    Model.Employeecode = Convert.ToString(dr["Code"]);
                    Model.FirstName = Convert.ToString(dr["FirstName"]);
                    Model.LastName = Convert.ToString(dr["LastName"]);
                    Model.BloodGroup = (BloodGroups)Convert.ToInt32(dr["Bloodgroup"]);
                    Model.Gender = (Genders)Convert.ToInt32(dr["Gender"]);
                    Model.EmailId = Convert.ToString(dr["EmailId"]);
                    Model.MobileNumber = Convert.ToString(dr["MobileNumber"]);
                    Model.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    Model.DateOfJoining = Convert.ToDateTime(dr["DateOfJoining"]);
                    Model.ExpInMonths = Convert.ToInt32(dr["ExpInMonths"]);
                    Model.SalaryCtc = Convert.ToDecimal(dr["SalaryCtc"]);
                    Model.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    return Model;
                }
                else
                {
                    return new EmployeeModel();
                }
                
            }   
           catch(Exception Ex)
            {
                throw;
            }
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}

        
        
>>>>>>> origin/main
