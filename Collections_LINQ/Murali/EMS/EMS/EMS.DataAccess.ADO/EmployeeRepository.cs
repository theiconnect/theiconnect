using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace EMS.DataAccess.ADO
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private static string ConnectionString { get; set; }
        public EmployeeRepository(string _connectionString)
        {
            ConnectionString = _connectionString;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT * FROM Employee"; // Example query
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel
                        {
                            EmployeeIdPk = Convert.ToInt32(reader["Id"]),
                            Employeecode = reader["Employeecode"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            BloodGroup = (Models.Enums.BloodGroups)Convert.ToInt32(reader["BloodGroupIdFk"]),
                            Gender = (Models.Enums.Genders)Convert.ToInt32(reader["GenderIdFk"]),
                            EmailId = reader["EmailId"].ToString(),
                            PersonalEmailId = reader["PersonalEmailId"].ToString(),
                            MobileNumber = reader["MobileNumber"].ToString(),
                            AlternateMobileNumber = reader["AlternateMobileNumber"].ToString(),
                            DepartmentIdFk = Convert.ToInt32(reader["DepartmentIdFk"]),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]),
                            ExpInMonths = Convert.ToInt32(reader["ExpInMonths"]),
                            QualificationIdFk = reader["QualificationIdFk"] as int?,
                            DesignationIdFk = (Models.Enums.DesiginationTypes)Convert.ToInt32(reader["DesignationIdFk"]),
                            SalaryCtc = reader["SalaryCtc"] as decimal?,
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            LWD = reader["LWD"] as DateTime?,
                        };
                        employees.Add(employee);




                    }
                }
                return employees;
            }
        }

        public bool SaveEmployee(EmployeeModel employeeModel, bool v, out string responseMessage)
        {
            var model = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();


                using (SqlCommand cmd = new SqlCommand("UpdateEmployee", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeIdPk);
                    cmd.Parameters.AddWithValue("@EmployeeCode", employeeModel.Employeecode);
                    cmd.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);

                    cmd.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                    cmd.Parameters.AddWithValue("@BloodGroupIdFk", (int)employeeModel.BloodGroup);
                    cmd.Parameters.AddWithValue("@GenderIdFk", (int)employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@EmailId", employeeModel.EmailId);

                    cmd.Parameters.AddWithValue("@MobileNumber", employeeModel.MobileNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employeeModel.DateOfBirth);
                    cmd.Parameters.AddWithValue("@DateOfJoining", employeeModel.DateOfJoining);
                    cmd.Parameters.AddWithValue("@ExpInMonths", employeeModel.ExpInMonths);
                    cmd.Parameters.AddWithValue("@SalaryCTC", (object?)employeeModel.SalaryCtc ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("IsActive", employeeModel.IsActive);


                    cmd.ExecuteNonQuery();
                    responseMessage = "Employee details saved successfully.";
                    return true;
                }




            }
        }


        public bool SavenewEmployee(EmployeeModel employeeModel, out string responseMessage)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                con.Open();
                // Implementation for saving a new employee should be here
            }
            responseMessage = "Employee saved successfully."; // Ensure out parameter is always assigned
            return true;
        }

        public bool SavenewEmployee(EmployeeModel employeeModel, bool v, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}

