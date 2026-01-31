using System.Data;
using EMS.IServices;
using EMS.Models;
using Microsoft.Data.SqlClient;

namespace EMS.Services.Implementation.ADO
{
    public class DepartmentADOService : IDepartmentService
    {
        public static string connectionString = "Data Source=.;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";
        public List<DepartmentModel> GetAllDepartments_Query()
        {
            string query = @"SELECT 
	                            DepartmentIdPk, 
	                            DepartmentCode, 
	                            DepartmentName, 
	                            IsActive, 
	                            DeptLocation, 
	                            CreatedOn,
	                            ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
                            FROM dbo.Department
                            Order by LastUpdatedOn DESC";
            var departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
                try
                {
                    con.Open();
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

            using (SqlConnection con = new SqlConnection(connectionString))
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

            using (SqlConnection con = new SqlConnection(connectionString))
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

        public List<DepartmentModel> GetAllDepartments()
        {
            return GetAllDepartments(null, null);
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
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
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
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

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
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
    }

    public class DepartmentADOService_Practice : IDepartmentService
    {
        public List<DepartmentModel> GetAllDepartments_InsertUpdateDelete()
        {
            string InsertQuery = @" SET NOCOUNT ON;
                                    INSERT INTO TEST (ID,NAME)
                                    SELECT 5, 'E'";

            string UpdateQuery = @"update test set name += name";

            string DeleteQuery = @"delete test where id = 5";

            using (SqlConnection con = new SqlConnection())
            {
                try
                {
                    //1. Sql connection 
                    con.ConnectionString = "Data Source=.;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";
                    //2. connection open
                    con.Open();

                    //3. Sql Command
                    using (SqlCommand cmd = new SqlCommand())
                    {                         //3.1 pass connection to the command
                        cmd.Connection = con;
                        //3.2 pass query to the command
                        cmd.CommandText = InsertQuery;
                        //3.3 pass command type to the command
                        cmd.CommandType = System.Data.CommandType.Text;//StoredProcedure, TableDirect
                                                                       //cmd.CommandType = System.Data.CommandType.StoredProcedure;//StoredProcedure, TableDirect

                        //4. Execute command
                        int NoOfRowsAffected = cmd.ExecuteNonQuery();//Insert/Update/Delete
                                                                     //cmd.ExecuteReader();//select with multiple rows and columns
                                                                     //                    //multiple results
                                                                     //object returnValue = cmd.ExecuteScalar();//Select with a single vlaue(1-r,1-col)
                                                                     //string str =Convert.ToString(cmd.ExecuteScalar());
                    }



                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                finally
                {
                    //5. close connection
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }

            return null;

        }

        public List<DepartmentModel> GetAllDepartments_SingleValue()
        {
            //string SelectSingleValue = @"SELECT COUNT(*) FROM TEST";
            string SelectSingleValue = @"SELECT getdate()";

            using SqlConnection con = new SqlConnection();
            try
            {
                //1. Sql connection 
                con.ConnectionString = "Data Source=.;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";
                //2. connection open
                con.Open();

                //3. Sql Command
                using SqlCommand cmd = new SqlCommand();
                //3.1 pass connection to the command
                cmd.Connection = con;
                //3.2 pass query to the command
                cmd.CommandText = SelectSingleValue;
                //3.3 pass command type to the command
                cmd.CommandType = System.Data.CommandType.Text;//StoredProcedure, TableDirect
                                                               //cmd.CommandType = System.Data.CommandType.StoredProcedure;//StoredProcedure, TableDirect

                //4. Execute command
                //int NoOfRowsAffected = cmd.ExecuteNonQuery();//Insert/Update/Delete
                //cmd.ExecuteReader();//select with multiple rows and columns
                //                    //multiple results
                object returnValue = cmd.ExecuteScalar();//Select with a single vlaue(1-r,1-col)
                                                         //string str =Convert.ToString(cmd.ExecuteScalar());



            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                //5. close connection
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return null;

        }


        public List<DepartmentModel> GetAllDepartments_DataReader()
        {
            string SelectMultiRecordQuery = @"SELECT 
	                            DepartmentIdPk, 
	                            DepartmentCode, 
	                            DepartmentName, 
	                            IsActive, 
	                            DeptLocation, 
	                            CreatedOn
                            FROM dbo.Department
                            Order by DepartmentIdPk DESC

                            SELECT * from test
                            SELECT  'abc' abc

                            SELECT getdate() a, getutcdate() b, 1 c,2 d;";


            using SqlConnection con = new SqlConnection();
            try
            {
                //1. Sql connection 
                con.ConnectionString = "Data Source=.;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";
                //2. connection open
                con.Open();

                //3. Sql Command
                using SqlCommand cmd = new SqlCommand();
                //3.1 pass connection to the command
                cmd.Connection = con;
                //3.2 pass query to the command
                cmd.CommandText = SelectMultiRecordQuery;
                //3.3 pass command type to the command
                cmd.CommandType = System.Data.CommandType.Text;//StoredProcedure, TableDirect
                                                               //cmd.CommandType = System.Data.CommandType.StoredProcedure;//StoredProcedure, TableDirect

                //4. Execute command
                //int NoOfRowsAffected = cmd.ExecuteNonQuery();//Insert/Update/Delete
                //cmd.ExecuteReader();//select with multiple rows and columns
                //                    //multiple results
                //object returnValue = cmd.ExecuteScalar();//Select with a single vlaue(1-r,1-col)
                //string str =Convert.ToString(cmd.ExecuteScalar());


                using SqlDataReader dataReader = cmd.ExecuteReader();//select with multiple rows and columns
                List<DepartmentModel> departments = new List<DepartmentModel>();

                //1- result set
                while (dataReader.Read())
                {
                    DepartmentModel model = new DepartmentModel();
                    model.DepartmentIdPk = Convert.ToInt32(dataReader["DepartmentIdPk"]);
                    model.DepartmentCode = Convert.ToString(dataReader["DepartmentCode"]);
                    model.DepartmentName = Convert.ToString(dataReader["DepartmentName"]);
                    model.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
                    model.Location = Convert.ToString(dataReader["DeptLocation"]);

                    departments.Add(model);
                }

                //2 Result set
                if (dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        DepartmentModel model = new DepartmentModel();
                        model.DepartmentIdPk = Convert.ToInt32(dataReader["ID"]);
                        model.DepartmentCode = Convert.ToString(dataReader["NAME"]);

                        departments.Add(model);
                    }
                }
                string abc = string.Empty;
                string a = string.Empty;
                string b = string.Empty;
                string c = string.Empty;
                string d = string.Empty;

                //3 Result set
                if (dataReader.NextResult())
                {
                    if (dataReader.Read())
                    {
                        abc = Convert.ToString(dataReader["abc"]);
                    }
                }

                //4 Result set
                if (dataReader.NextResult())
                {
                    if (dataReader.Read())
                    {
                        a = Convert.ToString(dataReader["a"]);
                        b = Convert.ToString(dataReader["b"]);
                        c = Convert.ToString(dataReader["c"]);
                        d = Convert.ToString(dataReader["d"]);
                    }
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                //5. close connection
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return null;

        }

        public List<DepartmentModel> GetAllDepartments_DataAdapter()
        {
            string SelectMultiRecordQuery = @"SELECT 
	                            DepartmentIdPk, 
	                            DepartmentCode, 
	                            DepartmentName, 
	                            IsActive, 
	                            DeptLocation, 
	                            CreatedOn
                            FROM dbo.Department
                            Order by DepartmentIdPk DESC

                            SELECT * from test
                            SELECT  'abc' abc

                            SELECT getdate() a, getutcdate() b, 1 c,2 d;";


            using SqlConnection con = new SqlConnection();
            try
            {
                //1. Sql connection 
                con.ConnectionString = "Data Source=.;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

                using SqlDataAdapter da = new SqlDataAdapter(SelectMultiRecordQuery, con);
                DataSet ds = new DataSet();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                //5. close connection
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return null;

        }

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            throw new NotImplementedException();
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            throw new NotImplementedException();
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
            throw new NotImplementedException();
        }
    }
}

