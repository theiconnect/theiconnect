using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.IServices;
using EMS.Models;
using Microsoft.Data.SqlClient;

namespace EMS.Services.Implementation.ADO
{
    public class DepartmentADOService : IDepartmentService
    {
        public List<DepartmentModel> GetAllDepartments()
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

            throw new NotImplementedException();
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
    }
}

