using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Model;


namespace EMS.DataAccess
{
    public class EMSDBContext
    {

        public CompanyModel GetCompanyModel()
        {
            CompanyModel obj = new CompanyModel();
            obj.CompanyIdPk = 1;
            obj.CompanyName = "Iconnect";
            obj.PhoneNumber = "9959782458";
            obj.Email = "Iconnect@gmail.com";
            obj.RegistrationDate = new DateTime(2020, 05, 01);
            obj.Website = "www.Iconnect.com";
            obj.BankAccountNumber = "000000000";
            obj.TAN = "567900456567";
            obj.PAN = "456789087";
            return obj;
        }

        public List<CompanyAddressModel> GetCompanyAddressModel( int CompanyIdPk)
        {
            CompanyAddressModel obj = new CompanyAddressModel();
            obj.CompanyAddressIdPk = 1;
            obj.AddressLine1 = "ameerpet";
            obj.AddressLine2 = "begumpet";
            obj.State = "Telangana";
            obj.City = "Hyderabad";
            obj.Pincode = "506001";
            obj.CompanyIdFk = CompanyIdPk;
            obj.AddressTypeIdFk = CompanyAddressTypeModel.HeadOffice;

            CompanyAddressModel obj1 = new CompanyAddressModel();
            obj1.CompanyAddressIdPk = 1;
            obj1.AddressLine1 = "tarnaka";
            obj1.AddressLine2 = "uppal";
            obj1.State = "Telangana";
            obj1.City = "Hyderabad";
            obj1.Pincode = "506001";
            obj1.CompanyIdFk = CompanyIdPk;
            obj1.AddressTypeIdFk = CompanyAddressTypeModel.BranchOffice;
            List<CompanyAddressModel> companyAddressList = new List<CompanyAddressModel>();
            companyAddressList.Add(obj);
            companyAddressList.Add(obj1);
            return companyAddressList;
        }
        public List<DepartmentModel> GetDepartmentModel()
        {
            DepartmentModel obj1 = new DepartmentModel();
            obj1.DepartmentIdPk = 1;
            obj1.DepartmentName = "scientist";
            obj1.DepartmentCode = "333";
            obj1.Location = "nellore";
            obj1.IsActive = true;

            DepartmentModel obj2 = new DepartmentModel();
            obj2.DepartmentIdPk = 1;
            obj2.DepartmentName = "engineer";
            obj2.DepartmentCode = "444";
            obj2.Location = "banglore";
            obj2.IsActive = true;

            DepartmentModel obj3 = new DepartmentModel();
            obj3.DepartmentIdPk = 1;
            obj3.DepartmentName = "manager";
            obj3.DepartmentCode = "555";
            obj3.Location = "chennai";
            obj3.IsActive = true;


            DepartmentModel obj4 = new DepartmentModel();
            obj4.DepartmentIdPk = 1;
            obj4.DepartmentName = "analyst";
            obj4.DepartmentCode = "666";
            obj4.Location = "pune";
            obj4.IsActive = true;


            DepartmentModel obj5 = new DepartmentModel();
            obj5.DepartmentIdPk = 1;
            obj5.DepartmentName = "consultant";
            obj5.DepartmentCode = "777";
            obj5.Location = "mumbai";
            obj5.IsActive = true;


            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            departmentList.Add(obj1);
            departmentList.Add(obj2);
            departmentList.Add(obj3);
            departmentList.Add(obj4);
            departmentList.Add(obj5);
            return departmentList;

        }
        public List<DepartmentCompanyAddressModel> GetDepartmentCompanyAddressModel()
        {
            DepartmentCompanyAddressModel obj1 = new DepartmentCompanyAddressModel();
            obj1.DepartmentCompanyAddressModelIdPk = 1;
            obj1.DepartmentIdPk = 1;
            obj1.CompanyAddressIdFK = 1;

            DepartmentCompanyAddressModel obj2 = new DepartmentCompanyAddressModel();
            obj2.DepartmentCompanyAddressModelIdPk = 2;
            obj2.DepartmentIdPk = 2;
            obj2.CompanyAddressIdFK = 2;

            DepartmentCompanyAddressModel obj3 = new DepartmentCompanyAddressModel();
            obj3.DepartmentCompanyAddressModelIdPk = 3;
            obj3.DepartmentIdPk = 3;
            obj3.CompanyAddressIdFK = 3;

            List<DepartmentCompanyAddressModel> Dca = new List<DepartmentCompanyAddressModel>();
            Dca.Add(obj1);
            Dca.Add(obj2);
            Dca.Add(obj3);
            return Dca;
        }
        public List<EmployeeModel> GetEmployeeModel()
        {
            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmployeeCode = 1;
            obj1.FirstName = "John";
            obj1.MiddleName = "A.";
            obj1.LastName = "Doe";
            obj1.BloodGroup = "O+";
            obj1.Gender = " Male";   
            obj1.EmailId = "john2311@gmail.com";
            obj1.PersonalEmailId = "ll";
            obj1.ManagerIdFk = "1111";
            obj1.MobileNumber = "9959782458";
            obj1.AlternateMobileNumber = "9988776655";
            obj1.DeptIdFk = 1;
            obj1.DOJ = new DateTime(2021, 06, 15);
            obj1.ExpInMonths = 24;
            obj1.DOB = new DateTime(1995, 08, 20);
            obj1.QualificationIdFk = 1;
            obj1.DesignationIdFk = 1;
            obj1.SalaryCTC = 75000.00M;
            obj1.IsActive = true;
            obj1.LWD = new DateTime(0001, 01, 01);

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmployeeCode = 2;
            obj2.FirstName = "Jane";
            obj2.MiddleName = "B.";
            obj2.LastName = "Smith";
            obj2.BloodGroup = "A+";
            obj2.Gender = "Female";
            obj2.EmailId = "jane11@gmail.com";
            obj2.PersonalEmailId = "mm";
            obj2.ManagerIdFk = "2222";
            obj2.MobileNumber = "9966778899";
            obj2.AlternateMobileNumber = "8877665544";
            obj2.DeptIdFk = 2;
            obj2.DOJ = new DateTime(2020, 03, 10);
            obj2.ExpInMonths = 36;
            obj2.DOB = new DateTime(1992, 11, 05);
            obj2.QualificationIdFk = 2;
            obj2.DesignationIdFk = 2;
            obj2.SalaryCTC = 85000.00M;
            obj2.IsActive = true;
            obj2.LWD = new DateTime(0001, 01, 01);

            EmployeeModel obj3 = new EmployeeModel();
            obj3.EmployeeCode = 3;
            obj3.FirstName = "Michael";
            obj3.MiddleName = "C.";
            obj3.LastName = "Johnson";
            obj3.BloodGroup = "B+";
            obj3.Gender= "Male";
            obj3.EmailId = "michael11@gmail.com";
            obj3.PersonalEmailId = "nn";
            obj3.ManagerIdFk = "3333";
            obj3.MobileNumber = "9944556677";
            obj3.AlternateMobileNumber = "7766554433";
            obj3.DeptIdFk = 3;
            obj3.DOJ = new DateTime(2019, 12, 01);
            obj3.ExpInMonths = 48;
            obj3.DOB = new DateTime(1990, 05, 15);
            obj3.QualificationIdFk = 3;
            obj3.DesignationIdFk = 3;
            obj3.SalaryCTC = 95000.00M;
            obj3.IsActive = true;
            obj3.LWD = new DateTime(0001, 01, 01);



            List <EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(obj1);
            employeeList.Add(obj2);
            employeeList.Add(obj3);
            return employeeList;
           
        }
        public EmployeeDesignation GetEmployeeDesignation()
        {
            EmployeeDesignation obj = new EmployeeDesignation();
            obj.EmployeeDesignationIdPK = 1;
            obj.DesignationIdFK = 1;
            obj.EffectiveFrom = new DateTime(2022, 01, 01);
            obj.EndDate = new DateTime(2023, 01, 01);
            return obj;
        }
        public EmployeeCTC GetEmployeeCTC()
        {
            EmployeeCTC obj = new EmployeeCTC();
            obj.EmployeeCTCPK = 1;
            obj.EmployeeIdFK = 1;
            obj.SalaryCTC = "75000.00";
            obj.EffectiveFrom = new DateTime(2022, 01, 01);
            obj.Enddate = new DateTime(2023, 01, 01);
            return obj;
        }
        public EmployeeAddressModel GetEmployeeAddressModel()
        {
            EmployeeAddressModel obj = new EmployeeAddressModel();
            obj.EmployeeAddressIdPK = 1;
            obj.AddressLine1 = "ameerpet";
            obj.AddressLine2 = "begumpet";
            obj.State = "Telangana";
            obj.City = "Hyderabad";
            obj.Pincode = "506001";
            obj.AddressTypeIdFK = 1;
            return obj;
        }
        public DesignationLookUpModel GetDesignationLookUpModel()
        {
            DesignationLookUpModel obj = new DesignationLookUpModel();
            obj.DesignationIdPk = 1;
            obj.DesignationCode = "SE001";
            obj.Designation = "Software Engineer";

            DesignationLookUpModel obj1 = new DesignationLookUpModel();
            obj1.DesignationIdPk = 2;
            obj1.DesignationCode = "SSE002";
            obj1.Designation = "Senior Software Engineer";

            List<DesignationLookUpModel> employeeList = new List<DesignationLookUpModel>();
            employeeList.Add(obj);
            employeeList.Add(obj1);
            return obj;
        }
        public QualificationLookUpModel GetQualificationLookUpModel()
        {
            QualificationLookUpModel obj = new QualificationLookUpModel();
            obj.QualificationIdPK = 1;
            obj.QualificationCode = "BTECH001";
            obj.Qualification = "Bachelor of Technology";
            QualificationLookUpModel obj1 = new QualificationLookUpModel();
            obj1.QualificationIdPK = 2;
            obj1.QualificationCode = "MTECH002";
            obj1.Qualification = "Master of Technology";
            List<QualificationLookUpModel> qualificationList = new List<QualificationLookUpModel>();
            qualificationList.Add(obj);
            qualificationList.Add(obj1);
            return obj;
        }
    }
}