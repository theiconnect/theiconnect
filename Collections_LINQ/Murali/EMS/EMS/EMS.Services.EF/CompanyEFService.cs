using EMS.EFCore.DBFirst.Models;
using EMS.IServices;
using EMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Services.EF
{
    public class CompanyEFService : ICompanyService
    {
        private EMSDbContext eMSDbContext;
        public CompanyEFService(EMSDbContext dbContext)
        {
            eMSDbContext = dbContext;
        }

        public bool AddUpdateCompanyAddress(CompanyAddressModel addressModel, string userId, out string errorMessage)
        {
            try
            {
                if (addressModel.CompanyAddressIdPk > 0)
                {
                    var dbExistingAddress = eMSDbContext.CompanyAddresses.Where(a => a.CompanyAddressIdPk == addressModel.CompanyAddressIdPk).FirstOrDefault();
                    //Update Logic
                    if (dbExistingAddress != null)
                    {
                        dbExistingAddress.AddressLine1 = addressModel.AddressLine1;
                        dbExistingAddress.AddressLine2 = addressModel.AddressLine2;
                        dbExistingAddress.City = addressModel.City;
                        dbExistingAddress.State = addressModel.State;
                        dbExistingAddress.PinCode = addressModel.Pincode;
                        dbExistingAddress.AddressTypeIdFk = (int)addressModel.AddressTypeIdFk;
                        dbExistingAddress.LastUpdatedBy = userId;
                        dbExistingAddress.LastUpdatedOn = DateTime.Now;
                    }
                }
                else
                {
                    CompanyAddress dbNewAddress = new CompanyAddress();
                    dbNewAddress.AddressLine1 = addressModel.AddressLine1;
                    dbNewAddress.AddressLine2 = addressModel.AddressLine2;
                    dbNewAddress.City = addressModel.City;
                    dbNewAddress.State = addressModel.State;
                    dbNewAddress.PinCode = addressModel.Pincode;
                    dbNewAddress.AddressTypeIdFk = (int)addressModel.AddressTypeIdFk;
                    dbNewAddress.CompanyIdFk = eMSDbContext.Companies.FirstOrDefault().CompanyIdPk;
                    dbNewAddress.CreatedBy = userId;
                    dbNewAddress.CreatedOn = DateTime.Now;
                    //Add Logic

                    eMSDbContext.CompanyAddresses.Add(dbNewAddress);
                }

                eMSDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            errorMessage = "success";
            return true;
        }

        public bool DeleteCompanyAddress(int id, out string errorMessage)
        {
            errorMessage = "success";
            try
            {
                var dbCompanyAddress = eMSDbContext.CompanyAddresses.Where(a => a.CompanyAddressIdPk == id).FirstOrDefault();
                if (dbCompanyAddress != null)
                {
                    eMSDbContext.CompanyAddresses.Remove(dbCompanyAddress);
                    eMSDbContext.SaveChanges();
                }
                else
                {
                    errorMessage = "Company Address not found.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            return true;
        }

        public CompanyModel GetCompanyDetails()
        {
            var dbCompany = eMSDbContext.Companies
                .Include(c => c.CompanyAddresses) // Ensure related addresses are loaded
                .FirstOrDefault();

            if (dbCompany == null)
            {
                throw new InvalidOperationException("No company record found in the database.");
            }

            var companyModel = new CompanyModel
            {
                CompanyIdPk = dbCompany.CompanyIdPk,
                CompanyName = dbCompany.CompanyName ?? string.Empty,
                PhoneNumber = dbCompany.PhoneNumber ?? string.Empty,
                Email = dbCompany.Email ?? string.Empty,
                RegistrationDate = dbCompany.RegistrationDate,
                Website = dbCompany.Website ?? string.Empty,
                BankAccountNumber = dbCompany.BankAccountNumber ?? string.Empty,
                TIN = dbCompany.Tin ?? string.Empty,
                PAN = dbCompany.Pan ?? string.Empty,
                CreatedBy = dbCompany.CreatedBy ?? string.Empty,
                CreatedOn = dbCompany.CreatedOn,
                LastUpdatedBy = dbCompany.LastUpdatedBy ?? string.Empty,
                LastUpdatedOn = dbCompany.LastUpdatedOn
            };

            companyModel.Addresses = dbCompany.CompanyAddresses.Select(addr => new CompanyAddressModel
            {
                CompanyAddressIdPk = addr.CompanyAddressIdPk,
                AddressLine1 = addr.AddressLine1 ?? string.Empty,
                AddressLine2 = addr.AddressLine2 ?? string.Empty,
                City = addr.City ?? string.Empty,
                State = addr.State ?? string.Empty,
                Pincode = addr.PinCode ?? string.Empty,
                AddressTypeIdFk = (Models.Enums.AddressTypes)addr.AddressTypeIdFk
            }).ToList();

            return companyModel;

        }
    }
}
