using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;
using EMS.Models.Enums;

namespace EMS.DataAccess
{
    public class EMSDbContext
    {
        public EMSDbContext()
        {
            LoadDB();
        }



        //Table Names as Public Properties
        public CompanyModel Company { get; set; }
        public List<CompanyAddressModel> CompanyAddresses
        {
            get
            {
                return Company.Addresses;
            }
        }

        public List<DepartmentModel> Departments
        {
            get
            {
                return Company.Departments;
            }
        }

        public List<EmployeeModel> Employees
        {
            return null;
        }



        private void LoadDB()
        {
            Company = GetCompany();
        }



        private CompanyModel GetCompany()
        {
            var company = new CompanyModel
            {
                CompanyIdPk = 1,
                CompanyName = "ABC Pvt Ltd",
                PhoneNumber = "1234567890",
                BankAccountNumber = "9876543210",
                Website = "www.abc.com",
                Email = "abc.pvt.ltd@gmail.com",
                PAN = "ABCDE1234F",
                TIN = "12ABCDE3456F7Z8",
                RegistrationDate = new DateTime(2010, 5, 15),

                Addresses = GetCompanyAddresses(1),
                Departments = CreateSampleDepartments(1)
            };


            return company;
        }
        private List<CompanyAddressModel> GetCompanyAddresses(int CompanyId)
        {
            return new List<CompanyAddressModel>
            {
                new CompanyAddressModel
                {
                    CompanyAddressIdPk=1,
                    CompanyIdFk=CompanyId,
                    AddressLine1="123, Main Street",
                    AddressLine2="Ameerpet",
                    City="Hyd",
                    State="Telangana",
                    Pincode="123456",
                    AddressTypeIdFk= AddressTypes.CORP_OFFICE
                },
                new() {
                    CompanyAddressIdPk=2,
                    CompanyIdFk=CompanyId,
                    AddressLine1="456, Market Road",
                    AddressLine2="Benz Circle",
                    City="Vijayawada",
                    State="AP",
                    Pincode="654321",
                    AddressTypeIdFk= AddressTypes.BRANCH_OFFICE
                },
                new CompanyAddressModel
                {
                    CompanyAddressIdPk=3,
                    CompanyIdFk=CompanyId,
                    AddressLine1="789, Lake View",
                    AddressLine2="MG Road",
                    City="Chennai",
                    State="Tamil Nadu",
                    Pincode="789123",
                    AddressTypeIdFk= AddressTypes.BRANCH_OFFICE
                }
            };
        }

        private List<DepartmentModel> CreateSampleDepartments(int CompanyId)
        {
            return new List<DepartmentModel>
            {
                new DepartmentModel
                {
                    DepartmentIdPk = 1,
                    DepartmentCode = "HR",
                    DepartmentName = "Human Resources",
                    Location = "Head Office",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(1)
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 2,
                    DepartmentCode = "DEV",
                    DepartmentName = "Development",
                    Location = "Tech Park",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(2)
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 3,
                    DepartmentCode = "MKT",
                    DepartmentName = "Marketing",
                    Location = "Corporate Office",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(3)
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 4,
                    DepartmentCode = "FIN",
                    DepartmentName = "Finance",
                    Location = "Head Office",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(4)
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 5,
                    DepartmentCode = "OPS",
                    DepartmentName = "Operations",
                    Location = "Regional Office",
                    CompanyIdFk = CompanyId,
                    IsActive = false,
                    Employees = CreateSampleEmployeeData(5)
                }
            };
        }

        private List<EmployeeModel> CreateSampleEmployeeData(int DepartmentId)
        {
            var employees = new List<EmployeeModel>();

            switch (DepartmentId)
            {
                case 1: // HR Department
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 1,
                        Employeecode = "HR001",
                        FirstName = "Rajesh",
                        LastName = "Sharma",
                        Gender = Genders.Male,
                        BloodGroup = BloodGroups.O_Positive,
                        EmailId = "rajesh.sharma@abc.com",
                        MobileNumber = "9876543210",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1985, 6, 15),
                        DateOfJoining = new DateTime(2015, 1, 10),
                        ExpInMonths = 120,
                        SalaryCtc = 600000,
                        IsActive = true
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 2,
                        Employeecode = "HR002",
                        FirstName = "Priya",
                        LastName = "Kumar",
                        Gender = Genders.Female,
                        BloodGroup = BloodGroups.A_Positive,
                        EmailId = "priya.kumar@abc.com",
                        MobileNumber = "9876543211",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1990, 8, 20),
                        DateOfJoining = new DateTime(2018, 3, 5),
                        ExpInMonths = 60,
                        SalaryCtc = 450000,
                        IsActive = true
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 3,
                        Employeecode = "HR003",
                        FirstName = "Karan",
                        LastName = "Kumari",
                        Gender = Genders.Female,
                        BloodGroup = BloodGroups.A_Positive,
                        EmailId = "Karan.Kumari@gmail.com",
                        MobileNumber = "9876543222",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1991, 9, 25),
                        DateOfJoining = new DateTime(2019, 4, 15),
                        SalaryCtc = 480000,
                        IsActive = true
                    });
                    break;

                case 2: // Development Department
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 3,
                        Employeecode = "DEV001",
                        FirstName = "Anil",
                        LastName = "Reddy",
                        Gender = Genders.Male,
                        BloodGroup = BloodGroups.B_Positive,
                        EmailId = "anil.reddy@abc.com",
                        MobileNumber = "9876543212",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1992, 4, 10),
                        DateOfJoining = new DateTime(2017, 7, 15),
                        ExpInMonths = 72,
                        SalaryCtc = 800000,
                        IsActive = true
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 4,
                        Employeecode = "DEV002",
                        FirstName = "Sneha",
                        LastName = "Patil",
                        Gender = Genders.Female,
                        BloodGroup = BloodGroups.AB_Positive,
                        EmailId = "sneha.patil@abc.com",
                        MobileNumber = "9876543213",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1995, 12, 5),
                        DateOfJoining = new DateTime(2020, 2, 1),
                        ExpInMonths = 36,
                        SalaryCtc = 500000,
                        IsActive = true
                    });
                    break;

                case 3: // Marketing Department
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 5,
                        Employeecode = "MKT001",
                        FirstName = "Vikram",
                        LastName = "Singh",
                        Gender = Genders.Male,
                        BloodGroup = BloodGroups.O_Negative,
                        EmailId = "vikram.singh@abc.com",
                        MobileNumber = "9876543214",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1988, 11, 25),
                        DateOfJoining = new DateTime(2016, 6, 10),
                        ExpInMonths = 84,
                        SalaryCtc = 700000,
                        IsActive = true
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 6,
                        Employeecode = "MKT002",
                        FirstName = "Anjali",
                        LastName = "Mehta",
                        Gender = Genders.Female,
                        BloodGroup = BloodGroups.B_Negative,
                        EmailId = "anjali.mehta@abc.com",
                        MobileNumber = "9876543215",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1993, 3, 18),
                        DateOfJoining = new DateTime(2019, 9, 20),
                        ExpInMonths = 48,
                        SalaryCtc = 550000,
                        IsActive = true
                    });
                    break;

                case 4: // Finance Department
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 7,
                        Employeecode = "FIN001",
                        FirstName = "Manoj",
                        LastName = "Gupta",
                        Gender = Genders.Male,
                        BloodGroup = BloodGroups.A_Positive,
                        EmailId = "manoj.gupta@abc.com",
                        MobileNumber = "9876543216",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1987, 9, 30),
                        DateOfJoining = new DateTime(2014, 4, 25),
                        ExpInMonths = 108,
                        SalaryCtc = 750000,
                        IsActive = true
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 8,
                        Employeecode = "FIN002",
                        FirstName = "Kavita",
                        LastName = "Joshi",
                        Gender = Genders.Female,
                        BloodGroup = BloodGroups.AB_Negative,
                        EmailId = "kavita.joshi@abc.com",
                        MobileNumber = "9876543217",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1991, 7, 22),
                        DateOfJoining = new DateTime(2018, 11, 10),
                        ExpInMonths = 60,
                        SalaryCtc = 600000,
                        IsActive = true
                    });
                    break;

                case 5: // Operations Department
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 9,
                        Employeecode = "OPS001",
                        FirstName = "Suresh",
                        LastName = "Naidu",
                        Gender = Genders.Male,
                        BloodGroup = BloodGroups.B_Positive,
                        EmailId = "suresh.naidu@abc.com",
                        MobileNumber = "9876543218",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1989, 5, 14),
                        DateOfJoining = new DateTime(2015, 8, 5),
                        ExpInMonths = 96,
                        SalaryCtc = 650000,
                        IsActive = false
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 10,
                        Employeecode = "OPS002",
                        FirstName = "Meena",
                        LastName = "Rao",
                        Gender = Genders.Female,
                        BloodGroup = BloodGroups.O_Positive,
                        EmailId = "meena.rao@abc.com",
                        MobileNumber = "9876543219",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1994, 2, 28),
                        DateOfJoining = new DateTime(2020, 1, 15),
                        ExpInMonths = 36,
                        SalaryCtc = 500000,
                        IsActive = false
                    });
                    break;
            }

            return employees;
        }
    }
}
