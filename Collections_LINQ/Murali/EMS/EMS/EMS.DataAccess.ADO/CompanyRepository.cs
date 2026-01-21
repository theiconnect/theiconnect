using EMS.IDataAccess;

namespace EMS.DataAccess.ADO
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository() { }

        public CompanyModel GetCompany()
        {
            var companie = new CompanyModel();
            string connectionString = "Data Source=3SHAAAAA;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("select CompanyName,PhoneNumber,Email,RegistartionDate,website,bankAccount,tin,pan from Comapnydb;", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            companie = new CompanyModel
                            {
                                CompanyName = (string)reader["CompanyName"],
                                PhoneNumber = (string)reader["PhoneNumber"],
                                Email = (string)reader["Email"],
                                RegistrationDate = (DateTime)reader["RegistartionDate"],
                                Website = (string)reader["Website"],
                                BankAccountNumber = (string)reader["BankAccount"],
                                TIN = (string)reader["Tin"],
                                PAN = (string)reader["Pan"]
                            };
                        }
                    }
                }
            }
        }

        public List<CompanyModel> GetAllCompanies()
        {
            var companies = new List<CompanyModel>();
            string connectionString = "Data Source=3SHAAAAA;Initial Catalog=EMS;Integrated Security=True; TrustServerCertificate=True";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("select CompanyName,PhoneNumber,Email,RegistartionDate,website,bankAccount,tin,pan from Comapnydb;", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var company = new CompanyModel
                            {
                                CompanyName = (string)reader["CompanyName"],
                                PhoneNumber = (string)reader["PhoneNumber"],
                                Email = (string)reader["Email"],
                                RegistrationDate = (DateTime)reader["RegistartionDate"],
                                Website = (string)reader["Website"],
                                BankAccountNumber = (string)reader["BankAccount"],
                                TIN = (string)reader["Tin"],
                                PAN = (string)reader["Pan"]
                            };
                            companies.Add(company);
                        }
                    }
                }
            }
        }
    }
}
