using EMS.IDataAccess;
using EMS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EMS.DataAccess.ADO
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyModel GetCompany()
        {
           
            string connectionString = "Data Source=LAPTOP-9LRGN9NO\\SAIPRASADMSSQL;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

            CompanyModel company = new CompanyModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("usp_getcompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {


                                company.CompanyIdPk = Convert.ToInt32(reader["CompanyIdPk"]);
                                company.CompanyName = reader["CompanyName"].ToString();
                                company.PhoneNumber = reader["PhoneNumber"].ToString();
                                company.Email = reader["Email"].ToString();
                                company.RegistrationDate = reader["RegistrationDate"] as DateTime?;
                                company.Website = reader["Website"].ToString();
                                company.BankAccountNumber = reader["BankAccountNumber"].ToString();
                                company.TIN = reader["TIN"].ToString();
                                company.PAN = reader["PAN"].ToString();
                                //company.CreatedBy = reader["CreatedBy"].ToString();
                                //company.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                                //company.LastUpdatedBy = reader["LastUpdatedBy"].ToString();
                                //company.LastUpdatedOn = reader["LastUpdatedOn"] as DateTime?;
                                
                                
                            }

                        }
                        return company;
                    }
                    catch (Exception ex)
                    {
                        throw ex;

                    }
                }
            }

           
        }

        
    }
}
