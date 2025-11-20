using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EMS.Models.CompanyAddressTypeModel;

namespace EMS.DataAccess
{
    public class EMSDBContex
    {
        public CompanyModel GetCompanyModel()
        {
            CompanyModel Company = new CompanyModel();

            Company.CompanyIdPk = 1;
            Company.CompanyName = "Tech Solutions Ltd.";
            Company.PhoneNumber = "+91 6538282482";
            Company.Email = "techsloutions@gmail.com";
            Company.RegistrationDate = new DateTime(2010, 5, 15);
            Company.Website = "www.techsolutions.com";
            Company.BankAccountNumber = "123456789012";
            Company.TAN = "469HFDJK7";
            Company.PAN = "ABCDE1234F";
            return Company;



     }


        public List<CompanyAddressModel> GetCompanyAddressesModel(int CompanyIdPk)
        {
            CompanyAddressModel Address1 = new CompanyAddressModel();
            Address1.CompanyAddressIdPk = 1;
            Address1.AddressLine1 = "123 Main St";
            Address1.AddressLine2 = "Suite 400";
            Address1.City = "Metropolis";
            Address1.State = "NY";
            Address1.PinCode = "10001";
            Address1.Country = "USA";
            Address1.CompanyIdFk = CompanyIdPk;
            Address1.AddressTypeIdFk = CompanyAddressTypeModel.Corporate;
            
            CompanyAddressModel Address2 = new CompanyAddressModel();
            Address2.CompanyAddressIdPk = 2;
            Address2.AddressLine1 = "456 Elm St";
            Address2.AddressLine2 = "Apt 12B";
            Address2.City = "Gotham";   
            Address2.State = "Newyork";
            Address2.PinCode = "07001";
            Address2.Country = "USA";
            Address1.CompanyIdFk = CompanyIdPk;
            Address2.AddressTypeIdFk = CompanyAddressTypeModel.Otheroffice;
            
            List<CompanyAddressModel> Address = new List<CompanyAddressModel>();
            Address.Add(Address1);
            Address.Add(Address2);
            return Address;


        }
       
       
            
        public List<DepartmentModel> GetDepartmentsModel()
        {
            DepartmentModel dept = new DepartmentModel();
            dept.DepartmentIdPk = 1;
            dept.DepartmentCode = "HR001";
            dept.DepartmentName = "Human Resources";
            dept.Location = "Head Office";
            dept.IsActive = true;
           

            DepartmentModel dept1 = new DepartmentModel();
            dept1.DepartmentIdPk = 1;
            dept1.DepartmentCode = "BE002";
            dept1.DepartmentName = "Business Executive";
            dept1.Location = "Head Office";
            dept1.IsActive = true;
            
            DepartmentModel dept2 = new DepartmentModel();
            dept2.DepartmentIdPk = 2;
            dept2.DepartmentCode = "IT001";
            dept2.DepartmentName = "Information Technology";
            dept2.Location = "Tech Park";
            dept2.IsActive = true;
           
            List<DepartmentModel> departments = new List<DepartmentModel>();
            departments.Add(dept);
            departments.Add(dept1);
            departments.Add(dept2);
           
            return departments;
        }
        public List<DesignationLookUpModel> GetDesignationLookUpModel()
        {
            DesignationLookUpModel designation = new DesignationLookUpModel();
            designation.DesignationIdPk = 1;
            designation.Designation = "Software Engineer";
            designation.DesignationCode = "DSC002";

            DesignationLookUpModel designation1 = new DesignationLookUpModel();
            designation1.DesignationIdPk = 2;
            designation1.Designation = "Senior Software Engineer";
            designation1.DesignationCode = "DSC003";

            List<DesignationLookUpModel> designations = new List<DesignationLookUpModel>();
            designations.Add(designation);
            designations.Add(designation1);
            
            return designations;
        }
        public List<EmployeeAddressModel> GetEmployeeAddressModel()
        {
            EmployeeAddressModel empAddress = new EmployeeAddressModel();
            empAddress.EmployeeAddressIdPk = 1;
            empAddress.AddressLine1 = "789 Pine St";
            empAddress.AddressLine2 = "Floor 3";
            empAddress.City = "Star City";
            empAddress.State = "CA";
            empAddress.PinCode = "90001";
            empAddress.AddressTypeIdFk = EmployeeAddressTypeModel.Permanent;

            EmployeeAddressModel employeeAddress = new EmployeeAddressModel();
            empAddress.EmployeeAddressIdPk = 2;
            empAddress.AddressLine1 = "780 Pine St";
            empAddress.AddressLine2 = "Street 5";
            empAddress.City = "Star City";
            empAddress.State = "CA";
            empAddress.PinCode = "475839";
            empAddress.AddressTypeIdFk = EmployeeAddressTypeModel.Present;

            List<EmployeeAddressModel> empAddresses = new List<EmployeeAddressModel>();
            empAddresses.Add(empAddress);
            
            return empAddresses;

        }



        public EmployeeModel GetEmployeeModel(int QualificationIdPk, int DesignationIdPk,int DepartmentIdPk)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmployeeIdPk = 1;
            emp.EmployeeCode = "EMP001";
            emp.FirstName = "John";
            emp.MiddleName = "Roy";
            emp.LastName = "Doe";
            emp.BloodGroup = "O+";
            emp.DOB = new DateTime(1990, 1, 1);
            emp.EmailId = "john@gmail.com";
            emp.PersonalEmailId = "john123@gmail.com";
            emp.MobileNumber = "9876543210";
            emp.AlternateMobileNumber = "8765432109";
            emp.DOJ = new DateTime(2015, 6, 1);
            emp.ExpInMonths = 108;
            emp.SalaryCTC= 750000;
            emp.IsActive = true;
            emp.LWD= null;
            emp.QualificationIdFk = QualificationIdPk;
            emp.DesignationIdFk= DesignationIdPk;


            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmployeeIdPk = 2;
            emp1.EmployeeCode = "EMP002";
            emp1.FirstName = "Ravi";
            emp1.MiddleName = "Kumar";
            emp1.LastName = "Sharma";
            emp1.BloodGroup = "A+";
            emp1.DOB = new DateTime(1991, 2, 10);
            emp1.EmailId = "ravi@gmail.com";
            emp1.PersonalEmailId = "ravikumar@gmail.com";
            emp1.MobileNumber = "7821073682";
            emp1.AlternateMobileNumber = "8765923411";
            emp1.DOJ = new DateTime(2016, 3, 13);
            emp1.ExpInMonths = 104;
            emp1.SalaryCTC = 80000;
            emp1.IsActive = false;
            emp1.LWD = new DateTime(2020, 5, 11);
            emp1.QualificationIdFk = QualificationIdPk;
            emp1.DesignationIdFk = DesignationIdPk;
            
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees.Add(emp);
            employees.Add(emp1);

            return emp;
        }



        public List<EmployeeCTC> GetEmployeeCTCModel(int EmployeeIdPk)
        {
            EmployeeCTC empCTC = new EmployeeCTC();
            empCTC.EmployeeCTCPk = 1;
            empCTC = new EmployeeCTC();
            empCTC.EmployeeIdFk = EmployeeIdPk;

            EmployeeCTC empCTC1= new EmployeeCTC();
            empCTC1.EmployeeCTCPk = 2;
            empCTC1.EmployeeIdFk = EmployeeIdPk;
            
            List<EmployeeCTC> empCTCs = new List<EmployeeCTC>();
            empCTCs.Add(empCTC);
            empCTCs.Add(empCTC1);

            return empCTCs;
        }
        public List<EmployeeDesignation> GetEmployeeDesignationModel(int EmployeeIdPk)
        {
            EmployeeDesignation empDesig = new EmployeeDesignation();
            empDesig.EmployeeDesignationIdPk = 1;
            empDesig = new EmployeeDesignation();
            empDesig.EffectiveFrom = new DateTime (2015, 6, 1);
            empDesig.EndDate =  new DateTime (2020, 5, 31);
            empDesig.EmployeeIdFk = EmployeeIdPk;

            EmployeeDesignation empDesig1 = new EmployeeDesignation();
            empDesig1.EmployeeDesignationIdPk = 2;
            empDesig1.EffectiveFrom = new DateTime (2020, 6, 1);
            empDesig1.EndDate =  new DateTime(2024, 5, 12);
            empDesig1.EmployeeIdFk = EmployeeIdPk;

            List<EmployeeDesignation> empDesigs = new List<EmployeeDesignation>();
            empDesigs.Add(empDesig);
            empDesigs.Add(empDesig1);

            return empDesigs;
        }

        public List<QualificationLookUpModel> GetQualificationLookUpModel()
        {
            QualificationLookUpModel qualification = new QualificationLookUpModel();
            qualification.QualificationIdPk = 1;
            qualification.Qualification = "Bachelor of Technology";
            qualification.QualificationCode = "B.Tech";

            QualificationLookUpModel qulification1 = new QualificationLookUpModel();
            qulification1.QualificationIdPk = 2;
            qulification1.Qualification = "Master of Business Administration";
            qulification1.QualificationCode = "MBA";

            QualificationLookUpModel qulification2 = new QualificationLookUpModel();
            qulification2.QualificationIdPk = 3;
            qulification2.Qualification = "Bachelor of Commerce";
            qulification2.QualificationCode = "B.Com";

            List<QualificationLookUpModel> qualifications = new List<QualificationLookUpModel>();
            qualifications.Add(qualification);
            qualifications.Add(qulification1);
            qualifications.Add(qulification2);

            return qualifications;
        }
    }
}
