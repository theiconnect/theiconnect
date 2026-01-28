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

        public bool AddUpdateCompanyAddress(CompanyAddressModel addressModel, string UserId, out string errorMessage)
        {
            errorMessage = string.Empty;
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand cmd = new SqlCommand("usp_AddUpdateCompanyAddress", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("@CompanyAddressIdPk", addressModel.CompanyAddressIdPk);
                sqlParameter.SqlDbType = System.Data.SqlDbType.Int;
                sqlParameter.Direction = System.Data.ParameterDirection.InputOutput;
                cmd.Parameters.Add(sqlParameter);

                //cmd.Parameters.AddWithValue("@CompanyAddressIdPk", addressModel.CompanyAddressIdPk);

                cmd.Parameters.AddWithValue("@AddressLine1", addressModel.AddressLine1);
                cmd.Parameters.AddWithValue("@AddressLine2", addressModel.AddressLine2);
                cmd.Parameters.AddWithValue("@City", addressModel.City);
                cmd.Parameters.AddWithValue("@State", addressModel.State);
                cmd.Parameters.AddWithValue("@PinCode", addressModel.Pincode);
                cmd.Parameters.AddWithValue("@AddressTypeIdFk", (int)addressModel.AddressTypeIdFk);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                con.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return false;
        }
        public bool DeleteCompanyAddress(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand cmd = new SqlCommand("usp_DeleteCompanyAddress", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@CompanyAddressIdPk", id);

                con.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return false;
        }
    }
}
