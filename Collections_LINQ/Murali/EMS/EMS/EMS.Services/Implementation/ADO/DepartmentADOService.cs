using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation.ADO
{
    public class DepartmentADOService : IDepartmentService
    {
        EMSDbContext dbContext;
        public DepartmentADOService()
        {
            dbContext = EMSDbContext.GetInstance();
        }

            return departments;
        }


        //public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        //{
        //    if (string.IsNullOrEmpty(deptName))
        //        deptName = "NULL";
        //    if (string.IsNullOrEmpty(deptLocation))
        //        deptLocation = "NULL";

        //    string queryNotRecommendedDuetoSQLInjection = @"SELECT 
        //                DepartmentIdPk, 
        //                DepartmentCode, 
        //                DepartmentName, 
        //                IsActive, 
        //                DeptLocation, 
        //                CreatedOn,
        //                ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
        //            FROM dbo.Department
        //            WHERE 1=1 ";
        //    if (!string.IsNullOrEmpty(deptName))
        //        queryNotRecommendedDuetoSQLInjection += $" AND DepartmentName = '{deptName}'";
        //    if (!string.IsNullOrEmpty(deptLocation))
        //        queryNotRecommendedDuetoSQLInjection += $" AND DeptLocation = '{deptLocation}'";
        //    queryNotRecommendedDuetoSQLInjection += " Order by LastUpdatedOn DESC";

        //    string querywithparam = @"SELECT 
        //                        DepartmentIdPk, 
        //                        DepartmentCode, 
        //                        DepartmentName, 
        //                        IsActive, 
        //                        DeptLocation, 
        //                        CreatedOn,
        //                        ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
        //                    FROM dbo.Department
        //                    WHERE
        //                        (ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
        //                        AND 
        //                        (ISNULL(@deptName, '') = '' OR DeptLocation = @deptLocation)
        //                    Order by LastUpdatedOn DESC";



        //    //       @"(ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
        //    // AND 
        //    // (ISNULL(@deptName, '') = '' OR DeptLocation = @deptLocation)
        //    //Order by LastUpdatedOn DESC";

        //    var departments = new List<DepartmentModel>();

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand(querywithparam, con))
        //        try
        //        {
        //            con.Open();
        //            cmd.Parameters.AddWithValue("@deptname", deptName ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@deptLocation", deptLocation ?? (object)DBNull.Value);
        //            using (SqlDataReader dataReader = cmd.ExecuteReader())
        //                while (dataReader.Read())
        //                {
        //                    DepartmentModel model = new DepartmentModel();
        //                    model.DepartmentIdPk = Convert.ToInt32(dataReader["DepartmentIdPk"]);
        //                    model.DepartmentCode = Convert.ToString(dataReader["DepartmentCode"]);
        //                    model.DepartmentName = Convert.ToString(dataReader["DepartmentName"]);
        //                    model.IsActive = Convert.ToBoolean(dataReader["IsActive"]);
        //                    model.Location = Convert.ToString(dataReader["DeptLocation"]);

        //                    model.CreatedOn = Convert.ToDateTime(dataReader["CreatedOn"]);

        //                    if (dataReader["LastUpdatedOn"] != DBNull.Value)
        //                        model.LastUpdatedOn = Convert.ToDateTime(dataReader["LastUpdatedOn"]);


        //                    departments.Add(model);
        //                }
        //        }
        //        catch { }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }

        //    return departments;
        //}


        public List<DepartmentModel> GetAllDepartmentsSearch (string Name, string Location )
        {
            string sql = "SELECT * FROM Department WHERE 1=1";
        if (Name != null)
        {
            sql += " AND DepartmentName = @deptName";
        }
            if (Location != null)
        {
            sql += " AND DeptLocation = @deptLocation";
        }
List<DepartmentModel> list = new List<DepartmentModel>();
    SqlConnection conn = new SqlConnection(connectionString);
    SqlCommand cmd = new SqlCommand(sql, conn);
if (Name != null)
{
    cmd.Parameters.AddWithValue("@deptName", Name);
}
if (Location != null)
{
    cmd.Parameters.AddWithValue("@deptLocation", Location);
}
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                DepartmentModel model = new DepartmentModel();
                model.DepartmentIdPk = Convert.ToInt32(reader["DepartmentIdPk"]);
                model.DepartmentCode = Convert.ToString(reader["DepartmentCode"]);
                model.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                model.Location = Convert.ToString(reader["DeptLocation"]);
                model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                if (reader["LastUpdatedOn"] != DBNull.Value)
                    model.LastUpdatedOn = Convert.ToDateTime(reader["LastUpdatedOn"]);
                list.Add(model);
            }
            conn.Close();
            return list;
        }


        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, out string responseMessage)
        {
            responseMessage = "Success";
            var department = dbContext.Departments.FirstOrDefault(d => d.DepartmentIdPk == departmentId);

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("usp_GetDepartmentList", con))
            {
                //if (isDeactivate)
                //{
                //    if(dbContext.Employees.Any(e => e.DepartmentIdFk == departmentId && e.IsActive))
                //    {

                //        responseMessage = "Unable to delete department due to Active employees exists in this deapartment!";
                //        return false;
                //    }
                //}
                //department.IsActive = !isDeactivate;

                if (isDeactivate)
                {
                    department.IsActive = false;
                }
                else
                {
                    department.IsActive = true;
                }
                return true;
            }

            responseMessage = "Department not found";
            return false;
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}

