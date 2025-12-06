using EMS.Models;

namespace EMS.DataAccess
{
    public class EMSDBContext
    {
        public CompanyModel GetCompanyModel() {

            CompanyModel Company = new CompanyModel();
            Company.CompanyIdPk = 1;
            Company.CompanyName = "ABC Pvt Ltd";
            Company.PhoneNumber = "1234567890";
            Company.Email = " abc@gmail.com";
            Company.RegritationDate = DateTime.Now;
            Company.Website = "www.abc.com";
            Company.BankAccountNumber = "9876543210";
            Company.TAN = "BYN1234";
            Company.PAN = "BNY12344";
            return Company;
        }

        public List<CompanyAddressModel> GetCompanyAddressModel(int CompanyIdPk)
        {

            CompanyAddressModel Address1 = new CompanyAddressModel();
            Address1.CompanyAddressModelIdPk = 1;
            Address1.AddressLine1 = "123 Main St";
            Address1.AddressLine2 = "Suite 400";
            Address1.City = "Metropolis";
            Address1.State = "NY";
            Address1.Pincode = "10001";
            Address1.Country = "USA";
            Address1.CompanyIdFk = CompanyIdPk;
            Address1.AddressTypeIdFk = CompanyAddressTypeModel.HeadOffice;

            CompanyAddressModel Address2 = new CompanyAddressModel();
            Address2.CompanyAddressModelIdPk = 2;
            Address2.AddressLine1 = "456 Elm St";
            Address2.AddressLine2 = "Apt 12B";
            Address2.City = "Gotham";
            Address2.State = "NJ";
            Address2.Pincode = "07001";
            Address2.Country = "USA";
            Address2.CompanyIdFk = CompanyIdPk;
            Address2.AddressTypeIdFk = CompanyAddressTypeModel.BranchOffice;


            List<CompanyAddressModel> Address = new List<CompanyAddressModel>();
            Address.Add(Address1);
            Address.Add(Address2);
            return Address;

        }


        public List<DepartmentModel> GetDepartmentModel()
        {
            DepartmentModel Dept1 = new DepartmentModel();
            Dept1.DepartmentIdPk = 1;
            Dept1.DepartmentName = "Human Resources";
            Dept1.DepartmentCode = "HR001";
            Dept1.Location = "New York";
            Dept1.IsActive = true;


            DepartmentModel Dept2 = new DepartmentModel();
            Dept2.DepartmentIdPk = 2;
            Dept2.DepartmentName = "Finance";
            Dept2.DepartmentCode = "FIN001";
            Dept2.Location = "Chicago";
            Dept2.IsActive = true;


            DepartmentModel Dept3 = new DepartmentModel();
            Dept3.DepartmentIdPk = 3;
            Dept3.DepartmentName = "IT Services";
            Dept3.DepartmentCode = "IT001";
            Dept3.Location = "San Francisco";
            Dept3.IsActive = true;


            DepartmentModel Dept4 = new DepartmentModel();
            Dept4.DepartmentIdPk = 4;
            Dept4.DepartmentName = "Marketing";
            Dept4.DepartmentCode = "MKT001";
            Dept4.Location = "Los Angeles";
            Dept4.IsActive = true;


            DepartmentModel Dept5 = new DepartmentModel();
            Dept5.DepartmentIdPk = 5;
            Dept5.DepartmentName = "Sales";
            Dept5.DepartmentCode = "SAL001";
            Dept5.Location = "Miami";
            Dept5.IsActive = true;

            List<DepartmentModel> Departments = new List<DepartmentModel>();
            Departments.Add(Dept1);
            Departments.Add(Dept2);
            Departments.Add(Dept3);
            Departments.Add(Dept4);
            Departments.Add(Dept5);
            return Departments;






        public List<DepartmentCompanyAddressModel> GetDepartmentCompanyAddressModel(int CompanyAddressIdPk, int DepartmentIdPk)
        {
            DepartmentCompanyAddressModel DeptAddress1 = new DepartmentCompanyAddressModel();
            DeptAddress1.DepartmentCompanyAddressIdPk = 1;
            DeptAddress1.CompanyAddressIdFk = CompanyAddressIdPk;
            DeptAddress1.DepartmentIdFk = DepartmentIdPk;

            List<DepartmentCompanyAddressModel> DeptAddresses = new List<DepartmentCompanyAddressModel>();
            DeptAddresses.Add(DeptAddress1);
            return DeptAddresses;
        }

        public List<EmployeeModel> GetEmployeeModel(int DepartmentIdPk, int QualificationIdPk int DesignationIdPk)
        {
            EmployeeModel Employee = new EmployeeModel();
            Employee.EmployeeIdPk = 1;
            Employee.FirstName = "goutham";
            Employee.LastName = "kanna";
            Employee.DateOfBirth = new DateTime(2004, 1, 7);
            Employee.Email = "abc@gmail.com"
            Employee.PersonalEmailId = "xyz@gamail.com"
            Employee.EmployeeCode = "EMP001";
            Employee.Gender = EmployeeGender.Female;
            Employee.MobileNumber = "1234567890";
            Employee.AlternateMobileNumber = "0987654321";
            Employee.DepartmentIdFk = DepartmentIdPk
            Employee.DateOfJoining = new DateTime(2020,11,11);
            Employee.ExpInMonths = 36;
            Employee.QualificationIdFk = QualificationIdPk
            Employee.DesignationIdFk = DesignationIdPk
            Employee.SalaryCTC = 75000.00;
            Employee.IsActive = true;
            Employee.LWD = null;

            EmployeeModel Employee2 = new EmployeeModel();
            Employee2.EmployeeIdPk = 2;
            Employee2.FirstName = "Rajesh";
            Employee2.LastName = "Kanna";
            Employee2.DateOfBirth = new DateTime(1996, 3, 18);
            Employee2.Email = "rajesh@gmail.com";
            Employee2.PersonalEmailId = "rajesh1@gmail.com";
            Employee2.EmployeeCode = "EMP002";
            Employee.Gender = EmployeeGender.Male;
            Employee2.MobileNumber = "2345678901";
            Employee2.AlternateMobileNumber = "1098765432";
            Employee2.DepartmentIdFk = DepartmentIdPk
            Employee2.DateOfJoining = new DateTime(2019, 5, 20);
            Employee2.ExpInMonths = 48;
            Employee2.QualificationIdFk = QualificationIdPk
            Employee2.DesignationIdFk = DesignationIdPk
            Employee2.SalaryCTC = 85000.00;
            Employee2.IsActive = False;
            Employee2.LWD = new DateTime(2023, 2, 15);

            List<EmployeeModel> Employees = new List<EmployeeModel>();
            Employees.Add(Employee);
            Employees.Add(Employee2);
            return Employees;

 

        }
        public List<QualificationLookUpModel> GetQualificationLookUpModel()
        {
            QualificationLookUpModel Qualification1 = new QualificationLookUpModel();
            Qualification1.QualificationIdPk = 1;
            Qualification1.QualificationCode = "QF001";
            Qualification1.Qualification = "Bachelor's Degree in Computer Science";


            QualificationLookUpModel Qualification2 = new QualificationLookUpModel();
            Qualification2.QualificationIdPk = 2;
            Qualification2.QualificationCode = "QF002";
            Qualification2.Qualification = "Master's Degree in Business Administration";

            QualificationLookUpModel Qualification3 = new QualificationLookUpModel();
            Qualification3.QualificationIdPk = 3;
            Qualification3.QualificationCode = "QF003";
            Qualification3.Qualification = "Bachelor's Degree in Finance";

            QualificationLookUpModel Qualification4 = new QualificationLookUpModel();
            Qualification4.QualificationIdPk = 4;
            Qualification4.QualificationCode = "QF004";
            Qualification4.Qualification = "Master's Degree in Marketing";

            QualificationLookUpModel Qualification5 = new QualificationLookUpModel();
            Qualification5.QualificationIdPk = 5;
            Qualification5.QualificationCode = "QF005";
            Qualification5.Qualification = "Bachelor's Degree in Human Resources";

            List<QualificationLookUpModel> Qualifications = new List<QualificationLookUpModel>();
            Qualifications.Add(Qualification1);
            Qualifications.Add(Qualification2);
            Qualifications.Add(Qualification3);
            Qualifications.Add(Qualification4);
            Qualifications.Add(Qualification5);
            return Qualifications;


        }




        public List<EmployeeAddressModel> GetEmployeeAddressModel(int EmployeeIdPk)
        {
            EmployeeAddressModel EmpAddress1 = new EmployeeAddressModel();
            EmpAddress1.EmployeeAddressIdPk = 1;
            EmpAddress1.AddressLine1 = "789 Oak St";
            EmpAddress1.AddressLine2 = "Floor 3";
            EmpAddress1.City = "Springfield";
            EmpAddress1.State = "IL";
            EmpAddress1.PinCode = "62701";
            EmpAddress1.Country = "USA";
            EmpAddress1.AddressTypeIdFk = EmployeeAddressTypeModel.PermanentAddress;



            EmployeeAddressModel EmpAddress2 = new EmployeeAddressModel();
            EmpAddress2.EmployeeAddressIdPk = 2;
            EmpAddress2.AddressLine1 = "321 Pine St";
            EmpAddress2.AddressLine2 = "Unit 5A";
            EmpAddress2.City = "Shelbyville";
            EmpAddress2.State = "IL";
            EmpAddress2.PinCode = "62565";
            EmpAddress2.Country = "USA";
            EmpAddress2.AddressTypeIdFk = EmployeeAddressTypeModel.TemporaryAddress;

            List<EmployeeAddressModel> EmpAddresses = new List<EmployeeAddressModel>();
            EmpAddresses.Add(EmpAddress1);
            EmpAddresses.Add(EmpAddress2);
            return EmpAddresses;
        }

        public List<DesignationLookUpModel> GetDesignationLookUpModel()
        {
            DesignationLookUpModel Designation1 = new DesignationLookUpModel();
            Designation1.DesignationIdPk = 1;
            Designation1.DesignationCode = "DS001";
            Designation1.Designation = "Senior Software Engineer";

            DesignationLookUpModel Designation2 = new DesignationLookUpModel();
            Designation2.DesignationIdPk = 2;
            Designation2.DesignationCode = "DS002";
            Designation2.Designation = "Project Manager";

            DesignationLookUpModel Designation3 = new DesignationLookUpModel();
            Designation3.DesignationIdPk = 3;
            Designation3.DesignationCode = "DS003";
            Designation3.Designation = "HR Manager";

            DesignationLookUpModel Designation4 = new DesignationLookUpModel();
            Designation4.DesignationIdPk = 4;
            Designation4.DesignationCode = "DS004";
            Designation4.Designation = "Finance Analyst";

            DesignationLookUpModel Designation5 = new DesignationLookUpModel();
            Designation5.DesignationIdPk = 5;
            Designation5.DesignationCode = "DS005";
            Designation5.Designation = "Marketing Coordinator";
            List<DesignationLookUpModel> Designations = new List<DesignationLookUpModel>();

            Designations.Add(Designation1);
            Designations.Add(Designation2);
            Designations.Add(Designation3);
            Designations.Add(Designation4);
            Designations.Add(Designation5);

            return Designations;
        }

        public EmployeeDesignation GetEmployeeDesignation(int EmployeeIdPk, int DesignationIdPk)
        {
            EmployeeDesignation EmpDesignation = new EmployeeDesignation();
            EmpDesignation.EmployeeDesignationIdPk = 1;
            EmpDesignation.EmployeeIdFk = EmployeeIdPk;
            EmpDesignation.DesignationIdFk = DesignationIdPk;
            EmpDesignation.EffectiveFrom = new DateTime(2022, 01, 01);
            EmpDesignation.EndDate = new DateTime(2023, 01, 01);
            return EmpDesignation;
        }



        public List<EmployeeCTCModel> GetEmployeeCTCModel(int employeeIdPk)
        {
            return new List<EmployeeCTCModel>
        {
            new EmployeeCTCModel
            {
                EmployeeCTCIdPk = 1,
                EmployeeIdFk = employeeIdPk,
                SalaryCTC = "75000",
                EffectiveFrom = new DateTime(2022, 01, 01),
                EndDate = new DateTime(2023, 01, 01)
            },
            new EmployeeCTCModel
            {
                EmployeeCTCIdPk = 2,
                EmployeeIdFk = employeeIdPk,
                SalaryCTC = "85000",
                EffectiveFrom = new DateTime(2023, 02, 01),
                EndDate = new DateTime(2024, 02, 01)
            }
        };
        }




    }
}