using System;
using EMS.IDataAccess;
using Microsoft.Data.SqlClient;
namespace EMS.DataAccess.ADO 
{ 

public class CompanyRepository : ICompanyRepository
    {
        public static string connectionstring = "Data Source=DESKTOP-UG9N4R1;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

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
            var Company = new CompanyModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        Company.CompanyIdPk = Convert.ToInt32(reader["CompanyIdPk"]);
                        Company.CompanyName = Convert.ToString(reader["CompanyName"]);
                        Company.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                        Company.Email = Convert.ToString(reader["Email"]);
                        Company.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);
                        Company.Website = Convert.ToString(reader["Website"]);
                        Company.BankAccountNumber = Convert.ToString(reader["BankAccountNumber"]);
                        Company.TIN = Convert.ToString(reader["TIN"]);
                        Company.PAN = Convert.ToString(reader["PAN"]);
                    }
                    
                }
            }

            return Company;
        }
    }
}