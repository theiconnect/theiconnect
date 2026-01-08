using EMS.IServices;
using EMS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Implementation.ADO
{
    public class CompanyADOService : ICompanyService
    {
        // Implement methods defined in ICompanyService using ADO.NET

        public static string connectionString = "Data Source=Gouthami;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";

        public CompanyModel GetCompany()
        {

        string Query = @"select 
                                CompanyName,
                                PhoneNumber,
                                Email,
                                RegistrationDate,
                                Website,
                                BankAccountNumber,
                                TIN,
                                PAN
                            from Company;";

        CompanyModel company = new CompanyModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
                try
                {
                    using SqlCommand cmd = new SqlCommand(Query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        company.CompanyName = reader["CompanyName"].ToString();
                        company.PhoneNumber = reader["PhoneNumber"].ToString();
                        company.Email = reader["Email"].ToString();
                        company.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);
                        company.Website = reader["Website"].ToString();
                        company.BankAccountNumber = reader["BankAccountNumber"].ToString();
                        company.TIN = reader["TIN"].ToString();
                        company.PAN = reader["PAN"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log it, rethrow it, etc.)
                    throw new Exception("An error occurred while retrieving company data.", ex);

                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            return company;
 
        }  
        
    }
}
