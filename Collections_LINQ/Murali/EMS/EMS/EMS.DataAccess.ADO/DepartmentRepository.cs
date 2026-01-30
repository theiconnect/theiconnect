using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.Models;
using Microsoft.Data.SqlClient;

namespace EMS.DataAccess.ADO
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private static string ConnectionString { get; set; }
        public DepartmentRepository(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;

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


        public List<DepartmentModel> GetAllDepartments()
        {
            var departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_GetAllDepartments", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            var departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_GetAllDepartments_Search", con))
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

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_GetDepartmentById", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DepartmentId", departmentId);

                sqlConnection.Open();
                using SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    DepartmentModel model = new DepartmentModel();
                    model.DepartmentIdPk = Convert.ToInt32(dr["DepartmentIdPk"]);
                    model.DepartmentCode = Convert.ToString(dr["DepartmentCode"]);
                    model.DepartmentName = Convert.ToString(dr["DepartmentName"]);
                    model.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    model.Location = Convert.ToString(dr["DeptLocation"]);
                    model.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    if (dr["LastUpdatedOn"] != DBNull.Value)
                        model.LastUpdatedOn = Convert.ToDateTime(dr["LastUpdatedOn"]);
                    return model;
                }
                else
                {
                    return new DepartmentModel();
                }
            }
            catch (Exception ex)
            {
                return new DepartmentModel();
            }
            finally
            {
                //Any cleanup code
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand command = new SqlCommand("usp_ManageDepartment", sqlConnection);
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
    }
}