using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;

namespace EMS.DataAccess
{
    public class EMSDbContext
    {
        public void getcompany()
        {
          CompanyModel obj = new CompanyModel();
            obj.CompanyId = 1;
            obj.CompanyName = "Iconnect";
            obj.CompanyPhoneNumber = "7567767890";
            obj.CompanyEmail = "Iconnect@gmail.com";
            obj.CompanyRegistrationDate = "12-05-2025";
            obj.Website = "www.Iconnect.com";
            obj.BankAccountNumber = "000000000";
            obj.TAN = "567900456567";
            obj.PAN = "456789087";
            
                
        }
      
          public List  <CompanyAddressModel>  GetCompanyAddress(int companyIdpK)
          {
           CompanyAddressModel obj1 = new CompanyAddressModel();

            obj1.CompanyAddressIdPK = 123;
            obj1.AddressLine1 = "Hyd1";
            obj1.AddressLine2 = "Hyd2";
            obj1.State = "telangana";
            obj1.City = "Hyderabad";
            obj1.PinCode = "1234";

            CompanyAddressModel obj2 = new CompanyAddressModel();

            obj2.CompanyAddressIdPK = 123;
            obj2.AddressLine1 = "Btm1";
            obj2.AddressLine2 = "Btm2";
            obj2.State = "Karnataka";
            obj2.City = "Bangalore";
            obj2.PinCode = "234";

            List<CompanyAddressModel> companyAddresses = new List<CompanyAddressModel>();
            companyAddresses.Add(obj1);
            companyAddresses.Add(obj2);
            return CompanyAddress;
          }
        public List <DepartmentModel> GetDepartment(int CompanyIdPK)
        {
            DepartmentModel obj1 = new DepartmentModel();
            obj1.DepartmentIdPK = "123";
            obj1.DepartmentCode = "001";
            obj1.DepartmentName = "IT";
            obj1.Location  = "telangana";
            obj1.Isactive = "Yes";

            DepartmentModel obj2 = new DepartmentModel();
            obj2.DepartmentIdPK = "389";
            obj2.DepartmentCode = "002";
            obj2.DepartmentName = "Testing";
            obj2.Location = "telangana";
            obj2.Isactive = "Yes";


            List<DepartmentModel> Departments = new List<Department>();
            Departments.Add(obj1);
            Departments.Add(obj2);
            return Departments;

        }
        public list<EmployeeModel> getEmployees(int DepartmentIdPK)
        {
            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmployeeIdPK = "001";
            obj1.EmployeeCode = "123";
            obj1.FirstName = "pravallika";
            obj1.MiddelName = "pra";
            obj1.LastName = "chereddy";
            obj1.BloodGroup = "o positive";
            obj1.Gender = "Female";
            obj1.EmailId = "pravallikaIconnect@gmail.com";
            obj1.PersonalEmailId= "pravallikachereddy900@gmail.com"
            obj1.ManagerIdFK = "Awe001";
            obj1.MobileNumber = "4567889023";
            obj1.AltMobileNumber = "3890298892";
            obj1.DeptIdFK = "DEP-001";
            obj1.Doj = "26-05-2004";
            obj1.ExpInMonths = 4;
            obj1.Dob = "26-05-2004";
            obj1.QualificationId = "001";
            obj1.DesignationId = "0023768";
            obj1.SalaryCTC = "6.5LPA";
            obj1.IsActive = "yes";
            obj1.LWD = "null";

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmployeeIdPK = "002";
            obj2.EmployeeCode = "326";
            obj2.FirstName = "venkat";
            obj2.MiddelName = "Ravanamma";
            obj2.LastName = "chereddy";
            obj2.BloodGroup = "o positive";
            obj2.Gender = "Female";
            obj2.EmailId = "RavanammaIconnect@gmail.com";
            obj2.PersonalEmailId = "Ravanamma000@gmail.com"
            obj2.ManagerIdFK = "AWE001";
            obj2.MobileNumber = "9456898746";
            obj2.AltMobileNumber = "9890245692";
            obj2.DeptIdFK = "DEP-001";
            obj2.Doj = "28-01-2003";
            obj2.ExpInMonths = 5;
            obj2.Dob = "28-01-2003";
            obj2.QualificationId = "002";
            obj2.DesignationId = "0123688";
            obj2.SalaryCTC = "7.0LPA";
            obj2.IsActive = "yes";
            obj2.LWD = "null";
            List<EmployeeModel>Employees = new List<EmployeeModel>();
            Employees.Add(obj1);
            Employees.Add(obj2);
            return Employees;


          public List<EmployeeAddressModel> GetEmployeeAddress(int DepartmentIdpK)
        {
            EmployeeAddressModel obj1 = new CompanyAddressModel();

            obj1.EmployeeAddressIdPK = 1;
            obj1.AddressLine1 = "sr nagar";
            obj1.AddressLine2 = "Ameerpet";
            obj1.State = "Telangana";
            obj1.City = "Hyderabad";
            obj1.PinCode = "1234";

            EmployeeAddressModel obj2 = new EmployeeAddressModel();

            obj2.EmployeeAddressIdPK = 2;
            obj2.AddressLine1 = "sanath nagar";
            obj2.AddressLine2 = "Ameerpet";
            obj2.State = "Telangana";
            obj2.City = "Hydreabad";
            obj2.PinCode = "5678";

            List<EmployeeAddressModel> EmployeeAddresses = new List<CompanyAddressModel>();
            EmployeeAddresses.Add(obj1);
            EmployeeAddresses.Add(obj2);
            return EmployeeAddress;


        }
    