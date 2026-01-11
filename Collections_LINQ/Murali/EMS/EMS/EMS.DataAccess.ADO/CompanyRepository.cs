using EMS.IDataAccess;
using EMS.Models;
using Microsoft.Data.SqlClient;

namespace EMS.DataAccess.ADO
{
    public class CompanyRepository : ICompanyRepository
    {
        string connectionString =
            "Data Source=chereddy\\VIJAY;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

        public CompanyModel GetCompanyDetails()
        {
            string query = @"SELECT 
                             CompanyIdPk,
                             CompanyName,
                             PhoneNumber,
                             Email,
                             RegistrationDate,
                             Website,
                             [BankAccountNumber],
                             TIN,
                             PAN
                             From [dbo].[Company]";
            var company = new CompanyModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                    
                        company.CompanyIdPk = Convert.ToInt32(reader["CompanyIdPk"]);
                        company.CompanyName = Convert.ToString(reader["CompanyName"]);
                        company.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        company.Email = Convert.ToString(reader["Email"]);
                        company.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);
                        company.Website = Convert.ToString(reader["Website"]);
                        company.BankAccountNumber = Convert.ToString(reader["BankAccountNumber"]);
                        company.TIN = Convert.ToString(reader["TIN"]);
                        company.PAN = Convert.ToString(reader["PAN"]);
                        
                    }
                }
            }

            return company;
        }
    }
}
