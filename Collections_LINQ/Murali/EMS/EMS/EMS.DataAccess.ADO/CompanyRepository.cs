using EMS.IDataAccess;
using EMS.Models;
using EMS.Models.Enums;
using Microsoft.Data.SqlClient;

namespace EMS.DataAccess.ADO
{
    public class CompanyRepository : ICompanyRepository
    {
        private static string ConnectionString { get; set; }
        public CompanyRepository(string _connectionString)
        {
            ConnectionString = _connectionString;
        }

        public CompanyModel GetCompanyDetails()
        {
            CompanyModel company = new CompanyModel();
            using SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                using SqlCommand cmd = new SqlCommand("usp_GetCompanyDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    company.CompanyIdPk = Convert.ToInt32(reader["CompanyIdPk"]);
                    company.CompanyName = Convert.ToString(reader["CompanyName"]);
                    company.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    company.Email = Convert.ToString(reader["Email"]);
                    if (reader["RegistrationDate"] != DBNull.Value)
                        company.RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]);
                    company.Website = Convert.ToString(reader["Website"]);
                    company.BankAccountNumber = Convert.ToString(reader["BankAccountNumber"]);
                    company.TIN = Convert.ToString(reader["TIN"]);
                    company.PAN = Convert.ToString(reader["PAN"]);
                    company.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                    company.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                    if (reader["LastUpdatedBy"] != DBNull.Value)
                        company.LastUpdatedBy = Convert.ToString(reader["LastUpdatedBy"]);
                    if (reader["LastUpdatedOn"] != DBNull.Value)
                        company.LastUpdatedOn = Convert.ToDateTime(reader["LastUpdatedOn"]);
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        CompanyAddressModel address = new CompanyAddressModel();
                        address.CompanyAddressIdPk = Convert.ToInt32(reader["CompanyAddressIdPk"]);
                        address.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                        address.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                        address.City = Convert.ToString(reader["City"]);
                        address.State = Convert.ToString(reader["State"]);
                        address.Pincode = Convert.ToString(reader["PinCode"]);
                        address.AddressTypeIdFk = (AddressTypes)Convert.ToInt32(reader["AddressTypeIdFk"]);
                        address.AddressTypeName = Convert.ToString(reader["AddressTypeDescription"]);

                        company.Addresses.Add(address);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception (not implemented here)
                throw new Exception("An error occurred while retrieving company details.", ex);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return company;
        }
    }
}
