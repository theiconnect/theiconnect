using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Model;
using EMS.Model.Enums;

namespace EMS.DataAccess
{
    public class EMSDbContext
    {
        public CompanyModel getCompany()
        {
            // Implementation goes here
            CompanyModel company = new CompanyModel();
            company.CompanyIdPk = 1;
            company.CompanyName = "Tech Solutions";
            company.PhoneNumber = "123-456-7890";
            company.Email = "iConnecttechSolutions@gmail.com";
            company.RegistrationDate = DateTime.Now;
            company.Website = "www.iConnecttechSolutions.com";
            company.BankAccountNumer = "9876543210";
            company.TAN = "TAN123456";
            company.PAN = "PAN654321";

            return company;

        }
        public List<CompanyAddressModel> getCompanyAddress(int companyIdPk)
        {
            // Implementation goes here


            CompanyAddressModel obj2 = new CompanyAddressModel();
            obj2.CompanyAddressIdPk = 1;
            obj2.AddressLine1 = "MG Road";
            obj2.AddressLine2 = "bus stand";
            obj2.State = "Telangana";
            obj2.City = "Hyderabad";
            obj2.PinCode = "500038";
            obj2.AddressTypeIdFk = CompanyAddressTypes.Corporate;
            obj2.CompanyIdFk = companyIdPk;

            CompanyAddressModel obj = new CompanyAddressModel();
            obj.CompanyAddressIdPk = 2;
            obj.AddressLine1 = "SR Nagar street 1";
            obj.AddressLine2 = "bus stand";
            obj.State = "Telangana";
            obj.City = "Hyderabad";
            obj.PinCode = "123453";
            obj.AddressTypeIdFk = CompanyAddressTypes.Otheroffice;
            obj.CompanyIdFk = companyIdPk;

            List<CompanyAddressModel> companyAddress = new List<CompanyAddressModel>();
            companyAddress.Add(obj2);
            companyAddress.Add(obj);

            return companyAddress;
        }

        public List<DepartmentModel> getDepartments(int companyId)
        {
            // Implementation goes here.......
            DepartmentModel department = new DepartmentModel();
            department.DepartmentIdPk = 1;
            department.DepartmentCode = "HR001";
            department.DepartmentName = "Human Resources";
            department.Location = "Hyderabad";
            department.IsActive = true;
            department.companyIdFk = companyId;

            DepartmentModel department2 = new DepartmentModel();
            department2.DepartmentIdPk = 2;
            department2.DepartmentCode = "DEV002";
            department2.DepartmentName = "Development";
            department2.Location = "Bangalore";
            department2.IsActive = true;
            department2.companyIdFk = companyId;

            DepartmentModel department3 = new DepartmentModel();
            department3.DepartmentIdPk = 3;
            department3.DepartmentCode = "MKT003";
            department3.DepartmentName = "Marketing";
            department3.Location = "Mumbai";
            department3.IsActive = false;
            department3.companyIdFk = companyId;

            DepartmentModel department4 = new DepartmentModel();
            department4.DepartmentIdPk = 4;
            department4.DepartmentCode = "FIN004";
            department4.DepartmentName = "Finance";
            department4.Location = "Chennai";
            department4.IsActive = false;
            department4.companyIdFk = companyId;

            DepartmentModel department5 = new DepartmentModel();
            department5.DepartmentIdPk = 5;
            department5.DepartmentCode = "MT005";
            department5.DepartmentName = "Maintainanace";
            department5.Location = "Pune";
            department5.IsActive = true;
            department5.companyIdFk = companyId;

            DepartmentModel department6 = new DepartmentModel();
            department6.DepartmentIdPk = 6;
            department6.DepartmentCode = "SL006";
            department6.DepartmentName = "Sales";
            department6.Location = "Delhi";
            department6.IsActive = true;
            department6.companyIdFk = companyId;

            List<DepartmentModel> departments = new List<DepartmentModel>();
            departments.Add(department);
            departments.Add(department2);
            departments.Add(department3);
            departments.Add(department4);
            departments.Add(department5);
            departments.Add(department6);

            return departments;
        }

        public List<DepartmentCompanyAddressModel> getDepartmentCompanyAddress(int DeptIdFk)
        {
            // Implementation goes here
            DepartmentCompanyAddressModel deptCompanyAddress = new DepartmentCompanyAddressModel();
            deptCompanyAddress.DepartmentCompanyAddressXREFIDPk = 1;
            deptCompanyAddress.DepartmentIdFk = DeptIdFk; // Assuming department with ID 1 exists
            deptCompanyAddress.CompanyAddressIdFk = 1; // Assuming company address with ID 1 exists

            List<DepartmentCompanyAddressModel> deptCompanyAddresses = new List<DepartmentCompanyAddressModel>();
            deptCompanyAddresses.Add(deptCompanyAddress);
            return deptCompanyAddresses;
        }

        public EmployeeModel getEmployees(int DeptIdPk)
        {
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeIdPk = 1;
            employee.EmployeeCode = "EMP001";
            employee.FirstName = "John";
            employee.MiddleName = "A.";
            employee.LastName = "Doe";
            employee.BloodGroup = "O+";
            employee.Gender = GenderType.Male;
            employee.EmailId = "John@iconnect.com";
            employee.PersonalEmailId = "John123@gmail.com";
            employee.MobileNumber = "9121974910";
            employee.AlternateMobileNumber = "9121974911";

            employee.DeptIdFk = DeptIdPk;
            employee.DOJ = new DateTime(2020, 1, 15);
            employee.ExpInMonths = 36;
            employee.DOB = new DateTime(1990, 5, 20);
            employee.QualificationIdFk = QualificationLookUpEnum.Bachelors;
            employee.DesignationIdFk = DesignationLookUpEnum.JuniorDeveloper;
            employee.SalaryCTC = 75000.00M;
            employee.IsActive = true;
            employee.LWD = null;

            return employee;
        }

        public List<EmployeeAddressModel> getEmployeeAddresses(int EmployeeIdPk)
        {
            // Implementation goes here
            EmployeeAddressModel empAddress1 = new EmployeeAddressModel();
            empAddress1.EmployeeAddressIdPk = 1;
            empAddress1.AddressLine1 = "123 Main St";
            empAddress1.AddressLine2 = "Apt 4B";
            empAddress1.State = "California";
            empAddress1.City = "Los Angeles";
            empAddress1.PinCode = "90001";
            empAddress1.AddressTypeIdFk = EmployeeAddressTypes.Permanent;
            empAddress1.EmployeeIdFk = EmployeeIdPk;

            EmployeeAddressModel empAddress2 = new EmployeeAddressModel();
            empAddress2.EmployeeAddressIdPk = 2;
            empAddress2.AddressLine1 = "456 Elm St";
            empAddress2.AddressLine2 = "Suite 5C";
            empAddress2.State = "California";
            empAddress2.City = "San Francisco";
            empAddress2.PinCode = "94101";
            empAddress2.AddressTypeIdFk = EmployeeAddressTypes.Present;
            empAddress2.EmployeeIdFk = EmployeeIdPk;
            List<EmployeeAddressModel> employeeAddresses = new List<EmployeeAddressModel>();
            employeeAddresses.Add(empAddress1);
            employeeAddresses.Add(empAddress2);
            return employeeAddresses;
        }

        public List<EmployeeDesignation> getEmployeeDesignation(int EmployeeIdPk, int DesignationIdPk)
        {
            // Implementation goes here
            EmployeeDesignation designation1 = new EmployeeDesignation();
            designation1.EmployeeDesignationIdPk = 1;
            designation1.DesignationIdFk = DesignationIdPk;
            designation1.EmployeeIdFk = EmployeeIdPk;
            designation1.EffectiveFrom = new DateTime(2021, 6, 1);
            designation1.EndDate = new DateTime(2023, 5, 31);

            EmployeeDesignation designation2 = new EmployeeDesignation();
            designation2.DesignationIdPk = 2;
            designation2.DesignationIdFk = DesignationIdPk;
            designation2.EmployeeIdFk = EmployeeIdPk;
            designation2.EffectiveFrom = new DateTime(2023, 6, 1);
            designation2.EndDate = null; // Current designation

            List<EmployeeDesignation> designations = new List<EmployeeDesignation>();
            designations.Add(designation1);
            designations.Add(designation2);
            return designations;
        }
        public List<EmployeeCTC> getEmployeeCTC(int EmployeeIdPk)
        {
            // Implementation goes here
            EmployeeCTC ctc1 = new EmployeeCTC();
            ctc1.EmployeeCTCIdPk = 1;
            ctc1.EmployeeIdFk = EmployeeIdPk;
            ctc1.CTCAmount = 60000.00M;
            ctc1.EffectiveFrom = new DateTime(2020, 1, 15);
            ctc1.EffectiveTo = new DateTime(2021, 12, 31);

            EmployeeCTC ctc2 = new EmployeeCTC();
            ctc2.EmployeeCTCIdPk = 2;
            ctc2.EmployeeIdFk = EmployeeIdPk;
            ctc2.CTCAmount = 75000.00M;
            ctc2.EffectiveFrom = new DateTime(2022, 1, 1);
            ctc2.EffectiveTo = null; // Current CTC

            List<EmployeeCTC> ctcs = new List<EmployeeCTC>();
            ctcs.Add(ctc1);
            ctcs.Add(ctc2);

            return ctcs;
        }
    }
}
