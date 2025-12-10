using System.Data.Common;
using EMS.Models;

namespace EMS.DataAccess
{
    public class EMSDBContext
    {
        public CompanyModel GetCompany()
        {
            CompanyModel company = new CompanyModel();
            company.CompanyId = 1;
            company.CompanyName = "Test";
            company.PhoneNumber = "1234567890";
            company.Email = "infoys@gmail.com";
            company.RegistrationDate = DateTime.Now;
            company.Website = "www/google.com";
            company.BankAccountNumer = "67539234";
            company.PAN = "ABCD1234";
            return company;
        }
        public List<CompanyAddressModel> GetCompanyAddresses(int companyId)
        {
            CompanyAddressModel obj = new CompanyAddressModel();
            obj.CompanyAddressIdpk = 1;
            obj.AddressLine1 = "kothapalem";
            obj.AddressLine2 = "Gudur";
            obj.state = "Telegana";
            obj.city = "Hyderabad";
            obj.pincode = "1234567890";


            CompanyAddressModel obj1 = new CompanyAddressModel();
            obj1.CompanyAddressIdpk = 1;
            obj1.AddressLine1 = "kothapalem";
            obj1.AddressLine2 = "Gudur";
            obj1.state = "Telegana";
            obj1.city = "Hyderabad";
            obj1.pincode = "1234567890";

            List<CompanyAddressModel> companyAddresses = new List<CompanyAddressModel>();
            companyAddresses.Add(obj);
            companyAddresses.Add(obj1);

            
            return companyAddresses;

        }

         public List<DepartmentModel> Departments()

        {
            DepartmentModel department = new DepartmentModel();
            department.DepartmentId = 1;
            department.DepartmentCode = "1234567890";
            department.DepartmentName = "connect";
            department.Location = "Hyderabad";
            department.IsActive = true;

            DepartmentModel department1 = new DepartmentModel();
            department1.DepartmentId = 1;
            department1.DepartmentCode = "1234567890";
            department1.DepartmentName = "connect";
            department1.Location = "goa";
            department1.IsActive = false;

            List<DepartmentModel> departments = new List<DepartmentModel>();
            departments.Add(department);
            departments.Add(department1);
            
           
            return departments;

        }
        public List<DepartmentCompanyAddressXREFModel> GetDepartmentCompanyAddressXREFModels()
        {
            List<DepartmentCompanyAddressXREFModel> departmentCompanyAddressXREFModels = new List<DepartmentCompanyAddressXREFModel>();
            DepartmentCompanyAddressXREFModel model = new DepartmentCompanyAddressXREFModel();
            model.DepartmentIdFK = 1;
            model.DepartmentCompanyAddressXREFIdpk = 1;
            model.CompanyAddressIdFK = 1;

            DepartmentCompanyAddressXREFModel model1 = new DepartmentCompanyAddressXREFModel();
            model1.DepartmentIdFK = 876;
            model1.DepartmentCompanyAddressXREFIdpk = 24446;
            model1.CompanyAddressIdFK = 1;

            departmentCompanyAddressXREFModels.Add(model);
            return departmentCompanyAddressXREFModels;
        }
        public List<EmployeeModel> GetEmpolyees()
        {
            List<EmployeeModel> empolyeeModels = new List<EmployeeModel>();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeCode = 1;
            model.FirstName = "KaripiReddy";
            model.MiddleName = "Venkata";
            model.LastName = "Ravanamma";
            model.BloodGroup = "B-POSITIVE";
            model.Gender = "Female";
            model.EmailId = "";
            model.PersonalEmailId = "karipireddyvenkataravanammma@gmail.com";
            model.ManagerIdFk = 265;
            model.MobileNumber = 1;
            model.AlternateMobileNumber = 1;
            model.DeptIdFk = 1;
            model.DOJ = DateTime.Now;
            model.ExpInMonths = 2;
            model.DOB = DateTime.Now;
            model.QualificationIdFk = 1;
            model.DesignationIdFk = 1;
            model.SalaryCTC = 87;
            model.IsActive = true;
            model.LWD = DateTime.Now;

            EmployeeModel model1 = new EmployeeModel();
            model1.EmployeeCode = 1;
            model1.FirstName = "karipiReddy";
            model1.MiddleName = "null";
            model1.LastName = "Anusha";
            model.BloodGroup = "B-POSITIVE";
            model.Gender = "Female";
            model.EmailId = "";
            model.PersonalEmailId = "karipireddyanusha@gmail.com";
            model.ManagerIdFk = 265;
            model.MobileNumber = 1;
            model.AlternateMobileNumber = 1;
            model.DeptIdFk = 1;
            model.DOJ = DateTime.Now;
            model.ExpInMonths = 2;
            model.DOB = DateTime.Now;
            model.QualificationIdFk = 1;
            model.DesignationIdFk = 1;
            model.SalaryCTC = 87;
            model.IsActive = true;
            model.LWD = DateTime.Now;

            empolyeeModels.Add(model);
            return empolyeeModels;
        }
        public List<QualificationLookupModel> GetQualificationLookupModels()
        {
            List<QualificationLookupModel> qualificationLookupModels = new List<QualificationLookupModel>();
            QualificationLookupModel qualificationmodels = new QualificationLookupModel();
            qualificationmodels.QualificationIdPK = 34;
            qualificationmodels.QualificationCode = "BTECH01";
            qualificationmodels.Qualification = "B.Tech";

            QualificationLookupModel qualificationmodels1= new QualificationLookupModel();
            qualificationmodels1.QualificationIdPK = 23;
            qualificationmodels1.QualificationCode = "MBA21";
            qualificationmodels1.Qualification = "MBA";
            qualificationLookupModels.Add(qualificationmodels1);
            return qualificationLookupModels;
        }


        public List<EmployeeAddressModel> GetEmployeeAddresses(int employeeId)
        {
            List<EmployeeAddressModel> employeeAddressModels = new List<EmployeeAddressModel>();
            EmployeeAddressModel employeeAddressModel = new EmployeeAddressModel();
            employeeAddressModel.CompanyAddressIdpk = 98;
            employeeAddressModel.AddressLine1 = "ongole";
            employeeAddressModel.AddressLine2 = "Bapatla";
            employeeAddressModel.state = "amaravathi";
            employeeAddressModel.city = "Nellore";
            employeeAddressModel.pincode = "12345";

            EmployeeAddressModel employeeAddressModel1 = new EmployeeAddressModel();
            employeeAddressModel1.CompanyAddressIdpk = 23;
            employeeAddressModel1.AddressLine1 = "dundigum";
            employeeAddressModel1.AddressLine2 = "bogole";
            employeeAddressModel1.state = "bihar";
            employeeAddressModel1.city = "kavali";
            employeeAddressModel1.pincode = "12345";

            employeeAddressModels.Add(employeeAddressModel1);
            return employeeAddressModels;
        }

        public List<DesignationLookupModel> GetDesignationLookupModels()
        {
            List<DesignationLookupModel> designationLookupModels = new List<DesignationLookupModel>();
            DesignationLookupModel designModels = new DesignationLookupModel();
            designModels.DesignationIdPK = 1;
            designModels.DesignationCode = "MNG001";
            designModels.Designation = "Manager";

            DesignationLookupModel designModels1 = new DesignationLookupModel();
            designModels1.DesignationIdPK = 2;
            designModels1.DesignationCode = "MNG002";
            designModels1.Designation = "Manager";
            designationLookupModels.Add(designModels1);
            return designationLookupModels;
        }
        public List<EmployeeDesignationModel> GetEmployeeDesignationsModels() {
            {
                List<EmployeeDesignationModel> employeeDesignModels = new List<EmployeeDesignationModel>();
              EmployeeDesignationModel employeeDesignModel = new EmployeeDesignationModel();
                employeeDesignModel.EmployeeDesignationIdPK= 1;
                employeeDesignModel.DesignationIdFk = 1;
                employeeDesignModel.EmployeeIdFK= 1;
                employeeDesignModel.EffectiveForm = DateTime.Now;
                employeeDesignModel.EndDate = DateTime.Now; 

                EmployeeDesignationModel employeeDesignModel1 = new EmployeeDesignationModel();
                employeeDesignModel1.EmployeeDesignationIdPK = 2;
                employeeDesignModel1.DesignationIdFk = 2;
                employeeDesignModel1.EmployeeIdFK = 2;
                employeeDesignModel1.EffectiveForm= DateTime.Now;
                employeeDesignModel1.EndDate = DateTime.Now;
                employeeDesignModels.Add(employeeDesignModel1);
                return employeeDesignModels;

            }

            public List<EmployeeCTCModel> GetemployeeCTCModels()
        {
            List<EmployeeCTCModel> employeeCTCModels = new List<EmployeeCTCModel>();
            EmployeeCTCModel employeeCTCModel= new EmployeeCTCModel();
            employeeCTCModel.EmployeeCTCPK = 1;
            employeeCTCModel.EmployeeIdFK = 1;
            employeeCTCModel.SalaryCTC = 50000;
            employeeCTCModel.EffectiveForm= DateTime.Now;
            employeeCTCModel.EndDate = DateTime.Now;

            EmployeeCTCModel employeeCTCModel1 = new EmployeeCTCModel();
            employeeCTCModel1.EmployeeCTCPK = 1;
            employeeCTCModel1.EmployeeIdFK= 1;
            employeeCTCModel1.SalaryCTC = 40000;
            employeeCTCModel1.EffectiveForm = DateTime.Now;
            employeeCTCModel1.EndDate = DateTime.Now;
            employeeCTCModels.Add(employeeCTCModel1);   
            return employeeCTCModels;
        }
        
       






           






























        }


    }

