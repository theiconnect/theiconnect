using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EMS.Models.Enums;

namespace EMS.DataAccess
{
    public class EMSDBContext
    {
        public CompanyModel GetCompany()
        {
            CompanyModel obj = new CompanyModel();
            obj.CompanyIdPk = 1;
            obj.CompanyName = "PRASAD Pvt Ltd";
            obj.PhoneNumber = "1234567890";
            obj.Email = "Icon123@gmail.com";
            obj.RegistrationDate = DateTime.Now;
            obj.Website = "www.abc.com";
            obj.BankAccountNumber = "123456789012";
            obj.TAN = "TAN1234567";
            obj.PAN = "PAN1234567";

            return obj;


        }
        public List<CompanyAddressModel> GetCompanyAddress(int CompanyIdPk)
        {
            CompanyAddressModel obj = new CompanyAddressModel();
            obj.CompanyAddressIdPk = 1;
            obj.AddressLine1 = "123 Main St";
            obj.AddressLine2 = "Suite 400";
            obj.State = "California";
            obj.City = "Los Angeles";
            obj.Pincode = "90001";
            obj.AddressTypeIdFk = (int)EMS.Models.Enums.CompanyAddressTypes.Corporate;
            
            CompanyAddressModel obj2 = new CompanyAddressModel();
            obj2.CompanyAddressIdPk = 2;
            obj2.AddressLine1 = "456";
            obj2.AddressLine2 = "Apt 12B";
            obj2.State = "New York";
            obj2.City = "New York City";
            obj2.Pincode = "10001";
            obj2.AddressTypeIdFk = (int)EMS.Models.Enums.CompanyAddressTypes.Secondary;



            List<CompanyAddressModel> addressList = new List<CompanyAddressModel>();

            addressList.Add(obj);
            addressList.Add(obj2);

            return addressList;

        }




        public List<DepartmentModel> GetDepartments(int CompanyIdPk)
        {
            DepartmentModel department = new DepartmentModel();
            department.DepartmentIdPk = 1;
            department.DepartmentCode = "HR01";
            department.DepartmentName = "HR";
            department.Location = "Mumbai";
            department.CompanyIdFk = CompanyIdPk;


            DepartmentModel department2 = new DepartmentModel();
            department2.DepartmentIdPk = 2;
            department2.DepartmentCode = "IT01";
            department2.DepartmentName = "IT";
            department2.Location = "Bangalore";
            department2.CompanyIdFk = CompanyIdPk;

            List<DepartmentModel> departmentList = new List<DepartmentModel>();

            departmentList.Add(department);
            departmentList.Add(department2);

            return departmentList;

        }

        public List<DepartmentCompanyAddressXREFModel> GetDepartmentCompanyAddressXREF(int CompanyIdPk)
        {
            DepartmentCompanyAddressXREFModel DCA = new DepartmentCompanyAddressXREFModel();
            DCA.DepartmentCompanyAddressXREFIdPk = 1;
            DCA.DepartmentIdFk = new DepartmentModel { DepartmentIdPk = 1, DepartmentName = "HR", DepartmentCode = "HR01", Location = "Mumbai", CompanyIdFk = CompanyIdPk };
            DCA.CompanyAddressIdFk = EMS.Models.Enums.CompanyAddressTypes.Corporate;

            List<DepartmentCompanyAddressXREFModel> DCAList = new List<DepartmentCompanyAddressXREFModel>();
            DCAList.Add(DCA);
            return DCAList;
        }

        public EmployeeModel GetEmployee(int DepartmentIdPk)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmployeeIdPk = 1;
            emp.FirstName = "kuruva";
            emp.LastName = "prasad";
            emp.MiddleName = "Sai";
            emp.EmailId = "saiprasad123@gmail.com";
            emp.PersonEmailId = "ASDF234@gmail.com";
            emp.BloodGroup = "O+";
            emp.Gender = GenderTypes.Male;
            emp.MobileNumber = "7893260089";
            emp.AlternateMobileNumber = "1234567890";
            emp.DepartmentIdFk = DepartmentIdPk;
            emp.DateOfJoining = DateTime.Now;
            emp.ExpInMonths = 1;
            emp.DateOfBirth = DateTime.Now;
            emp.QualificationIdFk = QualificationLookupModel.Masters;
            emp.DesignationIdFk = DesiginationLookupModel.ProjectManager;
            emp.SalaryCtc = 50000;
            emp.IsActive = true;
            emp.LWD = DateTime.Now;

            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmployeeIdPk = 2;
            emp2.FirstName = "kuruva";
            emp2.LastName = "Sunkanna";
            emp2.MiddleName = "";
            emp2.EmailId = "Sunkanna950@950@gmail.com";
            emp2.PersonEmailId = "Kuruvasunkanna12@gmail.com";
            emp2.BloodGroup = "A+";
            emp2.Gender = GenderTypes.Male;
            emp2.MobileNumber = "9505189327";
            emp2.AlternateMobileNumber = "9606581127";
            emp2.DepartmentIdFk = DepartmentIdPk;
            emp2.DateOfJoining = DateTime.Now;
            emp2.ExpInMonths = 2;
            emp2.DateOfBirth = DateTime.Now;
            emp2.QualificationIdFk =   QualificationLookupModel.Bachelors;
            emp2.DesignationIdFk = DesiginationLookupModel.TeamLead;
            emp2.SalaryCtc = 60000;
            emp2.IsActive = true;
            emp2.LWD = DateTime.Now;
            List<EmployeeModel> empList = new List<EmployeeModel>();
            empList.Add(emp);
            empList.Add(emp2);
            return emp;
        }

        
        public List<EmployeeAddressModel> GetEmployeeAddressModels()
        {
            EmployeeAddressModel employeeAddressModel1 = new EmployeeAddressModel(); 
            employeeAddressModel1.EmployeeAddressModelIdPk = 1;
            employeeAddressModel1.AddressLine1 = "puttapasham [v]";
            employeeAddressModel1.AddressLine2 = "via  Kodumur";
            employeeAddressModel1.City = "kurnool";
            employeeAddressModel1.State = "Andhra Pradesh";
            employeeAddressModel1.Pincode = "518463";
            employeeAddressModel1.AddressTypeIdFk = EmployeeAddressTypes.Permanent;

            EmployeeAddressModel employeeAddressModel2 = new EmployeeAddressModel();
            employeeAddressModel2.EmployeeAddressModelIdPk = 2;
            employeeAddressModel2.AddressLine1 = "H.No:12-345,MG Road SR Nagar";
            employeeAddressModel2.AddressLine2 = "Near by Shivam Tea Shop";
            employeeAddressModel2.City = "Hyderabad";
            employeeAddressModel2.State = "Telangana";
            employeeAddressModel2.Pincode = "500016";
            employeeAddressModel2.AddressTypeIdFk = EmployeeAddressTypes.Present;
            List<EmployeeAddressModel> empAddressList = new List<EmployeeAddressModel>(); 
            empAddressList.Add(employeeAddressModel1);
            empAddressList.Add(employeeAddressModel2);
            
            return empAddressList;
        }

        
        public List<EmployeeDesignationModel> GetEmployeeDesignations(int EmployeeIdPk ,int DesignationIdPk)
        {
            EmployeeDesignationModel empDesig1 = new EmployeeDesignationModel();
            empDesig1.EmployeeDesignationIdPk = 1;
            empDesig1.EmployeeIdFk = EmployeeIdPk;
            empDesig1.DesignationIdFk = DesiginationLookupModel.TeamLead;
            empDesig1.EffectiveFrom = DateTime.Now;
            empDesig1.EndDate = DateTime.Now.AddYears(1);

            EmployeeDesignationModel empDesig2 = new EmployeeDesignationModel();    
            empDesig2.EmployeeDesignationIdPk = 2;
            empDesig2.EmployeeIdFk = EmployeeIdPk;
            empDesig2.DesignationIdFk = DesiginationLookupModel.DevOpsEngineer ;
            empDesig2.EffectiveFrom = DateTime.Now;
            empDesig2.EndDate = DateTime.Now.AddYears(1);

            List<EmployeeDesignationModel> empDesigList = new List<EmployeeDesignationModel>();
            empDesigList.Add(empDesig1);
            empDesigList.Add(empDesig2);

            return empDesigList;
        }
       public List<EmployeeCTCModel> GetEmployeeCTCModels(int EmployeeIdPk)
        {
            EmployeeCTCModel empCTC1 = new EmployeeCTCModel();
            empCTC1.EmployeeCTCIdPk = 1;
            empCTC1.EmployeeIdFk = new EmployeeModel { EmployeeIdPk = 1, FirstName = "kuruva", LastName = "prasad" };
            empCTC1.SalaryCTC = 50000;
            empCTC1.EffectiveFrom = DateTime.Now;
            empCTC1.EndDate = DateTime.Now.AddYears(1);
            EmployeeCTCModel empCTC2 = new EmployeeCTCModel();
            empCTC2.EmployeeCTCIdPk = 2;
            empCTC2.EmployeeIdFk = new EmployeeModel { EmployeeIdPk = 2, FirstName = "kuruva", LastName = "Sunkanna" };
            empCTC2.SalaryCTC = 60000;
            empCTC2.EffectiveFrom = DateTime.Now;
            empCTC2.EndDate = DateTime.Now.AddYears(1);
            List<EmployeeCTCModel> empCTCList = new List<EmployeeCTCModel>();
            empCTCList.Add(empCTC1);
            empCTCList.Add(empCTC2);
            return empCTCList;
        }


    }
}