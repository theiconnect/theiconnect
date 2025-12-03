using EMS.Models;
using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMS.DataAccess
{
    public class EMSDBContext
    {
        public static EMSDbContext _obj;
        private EMSDbContext()
        {
            LoadDB();
        }
        public static EMSDbContext GetInstance()
        {
            if (_obj == null)
            {
                _obj = new EMSDbContext();
            }
            return _obj;
        }
        //Table Names as Public Properties
        public CompanyModel Company { get; set; } = new CompanyModel();
        public List<CompanyAddressModel> CompanyAddresses
        {
            get
            {
                return Company.Addresses;
            }
        }
        public CompanyModel GetCompany()
        {
            CompanyModel company = new CompanyModel();
            company.CompanyIdPk = 1;
            company.CompanyName = "Iconnect tech solutions";
            company.PhoneNumber = "3287419161";
            company.Email = "info@iconnecttechsolutions.com";
            company.RegistrationDate = DateTime.Now;
            company.Website = "www.iconnecttechsolutions.com";
            company.BankAccountNumber = "1234567890";
            company.TAN = "TAN12345";
            company.PAN = "ABCDE1234F";
            return company;
        }
        public List<CompanyAddressModel> GetCompanyAddress(int CompanyIdpk)
        {
            CompanyAddressModel obj1 = new CompanyAddressModel();
            obj1.CompanyAddressIdPk = 1;
            obj1.AddressLine1 = "hitech city";
            obj1.AddressLine2 = "madhapur";
            obj1.State = "telangana";
            obj1.City = "hyderabad";
            obj1.PinCode = "6252885";
            obj1.CompanyIdFK = CompanyIdpk;
            obj1.AddressTypeIdFk = CompanyAddressTypes.Corporate;


            CompanyAddressModel obj2 = new CompanyAddressModel();
            obj2.CompanyAddressIdPk = 2;
            obj2.AddressLine1 = "Abids";
            obj2.AddressLine2 = "ISKCON";
            obj2.State = "telangana";
            obj2.City = "hyderabad";
            obj2.PinCode = "6252885";
            obj2.CompanyIdFK = CompanyIdpk;
            obj2.AddressTypeIdFk = CompanyAddressTypes.OtherOffice;

            List<CompanyAddressModel> CompanyAddresses = new List<CompanyAddressModel>();
            CompanyAddresses.Add(obj1);
            CompanyAddresses.Add(obj2);
            return CompanyAddresses;
        }
        public List<DepartmentModel> GetDepartmentModel()
        {

            DepartmentModel dept1 = new DepartmentModel();
            dept1.DepartmentIdPK = 1;
            dept1.DepartmentCode = "FDG545456";
            dept1.DepartmentName = "Finance";
            dept1.Location = "sr nagar";


            DepartmentModel dept2 = new DepartmentModel();
            dept2.DepartmentIdPK = 2;
            dept2.DepartmentCode = "TYTII62542";
            dept2.DepartmentName = "Accounts";
            dept2.Location = "ameerpet";

            DepartmentModel dept3 = new DepartmentModel();
            dept3.DepartmentIdPK = 3;
            dept3.DepartmentCode = "BNV3756128";
            dept3.DepartmentName = "Marketing";
            dept3.Location = "hyderabad";


            DepartmentModel dept4 = new DepartmentModel();
            dept4.DepartmentIdPK = 4;
            dept4.DepartmentCode = "PIO714917";
            dept4.DepartmentName = "Production";
            dept4.Location = "banaglore";

            DepartmentModel dept5 = new DepartmentModel();
            dept5.DepartmentIdPK = 5;
            dept5.DepartmentCode = "WTTW7784216";
            dept5.DepartmentName = "Human Resources";
            dept5.Location = "kerala";

            List<DepartmentModel> departments = [dept1, dept2, dept3, dept4, dept5];
            return departments;

        }

        public List<DepartmentCompanyAddressXREFModel> GetDepartmentCompanyAddressXREFModel()
        {
            DepartmentCompanyAddressXREFModel obj1 = new DepartmentCompanyAddressXREFModel();
            obj1.DepartmentCompanyAddressIdPK = 1;
            obj1.DepartmentIdFk = 1;
            obj1.CompanyAddressIdFk = 1;

            DepartmentCompanyAddressXREFModel obj2 = new DepartmentCompanyAddressXREFModel();
            obj2.DepartmentCompanyAddressIdPK = 1;
            obj2.DepartmentIdFk = 2;
            obj2.CompanyAddressIdFk = 2;

            List<DepartmentCompanyAddressXREFModel> DCA = [obj1, obj2];
            return DCA;
        }
        public List<EmployeeModel> GetEmployeeModel()
        {
            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmployeeIdPk = 1;
            emp1.Employeecode = "tWTW123343235";
            emp1.FirstName = "venkata";
            emp1.MiddleName = "ramanamma";
            emp1.LastName = "chereddy";
            emp1.BloodGroup = "A";
            emp1.Gender = GenderTypes.Female;
            emp1.ManagerIdFk = 1; 
            emp1.EmailId = "chereddyvenkata@gamil.com";
            emp1.PersonalEmailId = "@1234venkat.com";
            emp1.MobileNumber = "5416471481";
            emp1.AlternateMobileNumber = "12373664647";
            emp1.DOB = DateTime.Now;
            emp1.DepartmentIdFk = 2;
            emp1.QualificationIdFk = 3;
            emp1.DesignationIdFk = 1;
            emp1.DOJ = DateTime.Now;
            emp1.SalaryCTC = 567.4654800m;
            emp1.IsActive = true;
            emp1.LWD = DateTime.Now;

            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmployeeIdPk = 2;
            emp2.Employeecode = "FGGHHG4782387042";
            emp2.FirstName = "sneha";
            emp2.MiddleName = "chevuru";
            emp2.LastName = "reddy";
            emp2.BloodGroup = "A";
            emp2.Gender = GenderTypes.Female;
            emp2.ManagerIdFk = 1;
            emp2.EmailId = "sneha@gamil.com";
            emp2.PersonalEmailId = "@1234sneha.com";
            emp2.MobileNumber = "7342582656";
            emp2.AlternateMobileNumber = "799845469506";
            emp2.DOB = DateTime.Now;
            emp2.DepartmentIdFk = 3;
            emp2.QualificationIdFk = 2;
            emp2.DesignationIdFk = 2;
            emp2.DOJ = DateTime.Now;
            emp2.SalaryCTC = 789.4654800m;
            emp2.IsActive = true;
            emp2.LWD = DateTime.Now;
                
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(emp1);
            return employeeList;
        }

        public List<EmployeeDesignationModel> GetEmployeeDesignationModel()
        {
            EmployeeDesignationModel designation1 = new EmployeeDesignationModel();
            designation1.EmployeeDesignationIdPk = 1;
            designation1.DesignationIdFk = 1;
            designation1.EmployeeIdFk = 1;
            designation1.EffectiveFrom = DateTime.Now;
            designation1.EndDate = DateTime.Now;

            EmployeeDesignationModel designation2 = new EmployeeDesignationModel();
            designation2.EmployeeDesignationIdPk = 2;
            designation2.DesignationIdFk = 2;
            designation2.EmployeeIdFk = 2;
            designation2.EffectiveFrom = DateTime.Now;
            designation2.EndDate = DateTime.Now;

            List<EmployeeDesignationModel> employeeList = [designation1, designation2];
            return employeeList;
        }

        public List<EmployeeCTCModel> GetEmployeeCTCModel()
        {
            EmployeeCTCModel EmployeeCTC = new EmployeeCTCModel();
            EmployeeCTC.EmployeeCTCPk = 1;
            EmployeeCTC.EmployeeIdFk = 1;
            EmployeeCTC.SalaryCTC = 125.4654800m;
            EmployeeCTC.EffectiveFrom= DateTime.Now;
            EmployeeCTC.EndDate = DateTime.Now;

            List<EmployeeCTCModel> CTC = new List<EmployeeCTCModel>();
            CTC.Add(EmployeeCTC);
            return new List<EmployeeCTCModel>();

        }
    }

}



