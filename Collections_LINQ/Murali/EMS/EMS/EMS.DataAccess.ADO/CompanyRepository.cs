using EMS.IDataAccess;
using EMS.Models;
using Microsoft.Data.SqlClient;
namespace EMS.DataAccess.ADO
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyModel GetCompanyRepository()
        {
       string connectionString = "Data Source=LAPTOP-CP66449K;Initial Catalog=EMSDb;Integrated Security=True; TrustServerCertificate=True";

        CompanyModel company = new CompanyModel();
            // Implementation to retrieve company data from the database using ADO.NET

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_getCompanyDetails", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
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

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving company data: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
            return company;
        }
    }
}
