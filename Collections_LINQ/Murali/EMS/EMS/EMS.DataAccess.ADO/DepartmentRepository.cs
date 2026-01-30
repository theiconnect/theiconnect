using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;


namespace EMS.DataAccess.ADO
{
    public class DepartmentRepository : IDepartmentRespository
    {
        private static string ConnectionString { get; set; }
        public DepartmentRepository(string _connectionString)
        {
            ConnectionString = _connectionString;
        }
        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand cmd = new SqlCommand("usp_GetAllDepartments", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepartmentModel department = new DepartmentModel();
                    department.DepartmentIdPk = Convert.ToInt32(reader["DepartmentIdPk"]);
                    department.DepartmentCode = Convert.ToString(reader["DepartmentCode"]);
                    department.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    department.Location = Convert.ToString(reader["DeptLocation"]);
                    department.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    departments.Add(department);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving department details.", ex);
            }
            finally
            {
                con.Close();
            }
            return departments;
        }
        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)

        {
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_ManageDepartment", con);
                command.CommandType = CommandType.StoredProcedure;
                if (isNewDepartment)
                    command.Parameters.AddWithValue("@ActionType", "ADD");
                else
                    command.Parameters.AddWithValue("@ActionType", "UPDATE");


                command.Parameters.AddWithValue("@DepartmentIdPk", inputDepartment.DepartmentIdPk);
                command.Parameters.AddWithValue("@DepartmentCode", inputDepartment.DepartmentCode);
                command.Parameters.AddWithValue("@DepartmentName", inputDepartment.DepartmentName);
                command.Parameters.AddWithValue("@DeptLocation", inputDepartment.Location);
                command.Parameters.AddWithValue("@IsActive", inputDepartment.IsActive);
                command.Parameters.AddWithValue("@UserName", userName);
                SqlParameter outputParam = new("@OutputMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(outputParam);

                con.Open();
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
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            if (responseMessage.ToLower() == "success")
                return true;
            else
                return false;
        }

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_ManageDepartment", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                if (isDeactivate)
                    command.Parameters.AddWithValue("@ActionType", "DELETE");
                else
                    command.Parameters.AddWithValue("@ActionType", "ACTIVATE");

                command.Parameters.AddWithValue("@DepartmentIdPk", departmentId);
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
        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
            if (string.IsNullOrEmpty(deptName))
                deptName = "NULL";
            if (string.IsNullOrEmpty(deptLocation))
                deptLocation = "NULL";

            string queryNotRecommendedDuetoSQLInjection = @"SELECT 
		                        DepartmentIdPk, 
		                        DepartmentCode, 
		                        DepartmentName, 
		                        IsActive, 
		                        DeptLocation, 
		                        CreatedOn,
		                        ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
	                        FROM dbo.Department
	                        WHERE 1=1 ";
            if (!string.IsNullOrEmpty(deptName))
                queryNotRecommendedDuetoSQLInjection += $" AND DepartmentName = '{deptName}'";
            if (!string.IsNullOrEmpty(deptLocation))
                queryNotRecommendedDuetoSQLInjection += $" AND DeptLocation = '{deptLocation}'";
            queryNotRecommendedDuetoSQLInjection += " Order by LastUpdatedOn DESC";

            string querywithparam = @"SELECT 
		                                DepartmentIdPk, 
		                                DepartmentCode, 
		                                DepartmentName, 
		                                IsActive, 
		                                DeptLocation, 
		                                CreatedOn,
		                                ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
	                                FROM dbo.Department
	                                WHERE
		                                (ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
		                                AND 
		                                (ISNULL(@deptName, '') = '' OR DeptLocation = @deptLocation)
	                                Order by LastUpdatedOn DESC";



            //       @"(ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
            // AND 
            // (ISNULL(@deptName, '') = '' OR DeptLocation = @deptLocation)
            //Order by LastUpdatedOn DESC";

            var departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(querywithparam, con))
                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@deptname", deptName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@deptLocation", deptLocation ?? (object)DBNull.Value);
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                        {
                            DepartmentModel model = new DepartmentModel();
                            model.DepartmentIdPk = Convert.ToInt32(dataReader["DepartmentIdPk"]);
                            model.DepartmentCode = Convert.ToString(dataReader["DepartmentCode"]);
                            model.DepartmentName = Convert.ToString(dataReader["DepartmentName"]);
                            model.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                            model.Location = Convert.ToString(dataReader["DeptLocation"]);

                            model.CreatedOn = Convert.ToDateTime(dataReader["CreatedOn"]);

                            if (dataReader["LastUpdatedOn"] != DBNull.Value)
                                model.LastUpdatedOn = Convert.ToDateTime(dataReader["LastUpdatedOn"]);


                            departments.Add(model);
                        }
                }
                catch { }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

            return departments;
        }

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            var departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_GetAllDepartments", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptName", deptName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@deptLocation", deptLocation ?? (object)DBNull.Value);
                try
                {
                    con.Open();
                    using SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DepartmentModel model = new DepartmentModel();
                        model.DepartmentIdPk = Convert.ToInt32(dataReader["DepartmentIdPk"]);
                        model.DepartmentCode = Convert.ToString(dataReader["DepartmentCode"]);
                        model.DepartmentName = Convert.ToString(dataReader["DepartmentName"]);
                        model.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                        model.Location = Convert.ToString(dataReader["DeptLocation"]);

                        model.CreatedOn = Convert.ToDateTime(dataReader["CreatedOn"]);

                        if (dataReader["LastUpdatedOn"] != DBNull.Value)
                            model.LastUpdatedOn = Convert.ToDateTime(dataReader["LastUpdatedOn"]);


                        departments.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    //Log the error 
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }

            return departments;
        }

    }
}
  


