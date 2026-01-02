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
        private static EMSDbContext _obj;
        public object employees;

        public string PhoneNumber { get; set; }

        public List<string> PhoneNumbersList { get; set; }
      


        //static EMSDbContext()
        //{ 
        //    _obj = new EMSDbContext();           
        //}
        

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

        public List<DepartmentModel> Departments
        {
            get
            {
                return Company.Departments;
            }
        }

        public List<EmployeeModel> Employees
        {
            get
            {
                var employees = new List<EmployeeModel>();
                foreach (var d in Company.Departments)
                {
                    employees.AddRange(d.Employees);
                }
                return employees;
            }
        }

        public List<EmployeeAddressModel> EmployeeAddresses
        {
            get
            {
                var addresses = new List<EmployeeAddressModel>();
                foreach (var d in Company.Departments)
                {
                    foreach (var e in d.Employees)
                    {
                        addresses.AddRange(e.Addresses);

                    }
                }
                return addresses;
            }
        }

        public List<QualificationLookupModel> QualificationLookups
        {
            get
            {
                return CreateQualificationLookupModels();
            }
        }

        private void   LoadDB()
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
                    AddressTypeIdFk= AddressTypes.CORP_OFFICE,
                    //Departments = [Departments[0], Departments[1], Departments[2], Departments[3]]
                },

                new() {
                    CompanyAddressIdPk=2,
                    CompanyIdFk=CompanyId,
                    AddressLine1="456, Market Road",
                    AddressLine2="Benz Circle",
                    City="Vijayawada",
                    State="AP",
                    Pincode="654321",
                    AddressTypeIdFk= AddressTypes.BRANCH_OFFICE,
                    //Departments = [Departments[0], Departments[4], Departments[2], Departments[3]]
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
                    AddressTypeIdFk= AddressTypes.BRANCH_OFFICE,
                    //Departments = [Departments[0], Departments[4]]
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
                    Employees = CreateSampleEmployeeData(1),
                    //CompanyAddresses = [CompanyAddresses[1], CompanyAddresses[2]]
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 2,
                    DepartmentCode = "DEV",
                    DepartmentName = "Development",
                    Location = "Tech Park",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(2),
                   // CompanyAddresses = [CompanyAddresses[0], CompanyAddresses[2]]
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 3,
                    DepartmentCode = "MKT",
                    DepartmentName = "Marketing",
                    Location = "Corporate Office",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(3),
                    //CompanyAddresses = [CompanyAddresses[1], CompanyAddresses[2]]
                },
                new DepartmentModel
                {
                    DepartmentIdPk = 4,
                    DepartmentCode = "FIN",
                    DepartmentName = "Finance",
                    Location = "Head Office",
                    CompanyIdFk = CompanyId,
                    IsActive = true,
                    Employees = CreateSampleEmployeeData(4),
                    //CompanyAddresses = [CompanyAddresses[0], CompanyAddresses[2]]

                },
                new DepartmentModel
                {
                    DepartmentIdPk = 5,
                    DepartmentCode = "OPS",
                    DepartmentName = "Operations",
                    Location = "Regional Office",
                    CompanyIdFk = CompanyId,
                    IsActive = false,
                    Employees = CreateSampleEmployeeData(5),
                    //CompanyAddresses = [CompanyAddresses[0], CompanyAddresses[1], CompanyAddresses[2]]
                }
            };
        }

        private List<EmployeeModel> CreateSampleEmployeeData(int DepartmentId)
        {
            //Similar to the employee addresses now we have to load sample designations for each employee.
            //an employee can have multiple designations but only one active designation at a time. which means enddate will be null for active designation.
            //at the same time the previous designations will have enddate filled.
            //the active designation id of EmployeeDesignationModel will be mapped to DesignationIdFk of EmployeeModel
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
                        DesignationIdFk = DesiginationTypes.HRManager,
                        EmailId = "rajesh.sharma@abc.com",
                        MobileNumber = "9876543210",
                        DepartmentIdFk = DepartmentId,
                        DateOfBirth = new DateTime(1985, 6, 15),
                        DateOfJoining = new DateTime(2015, 1, 10),
                        ExpInMonths = 120,
                        SalaryCtc = 600000,
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(1),
                        Designations = CreateSampleDesignations(1)

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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(2),
                        Designations = CreateSampleDesignations(2)
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(3),
                        Designations = CreateSampleDesignations(3)
                    });
                    break;

                case 2: // Development Department  
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 4,
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(4),
                        Designations = CreateSampleDesignations(4)
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 5,
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(5),
                        Designations = CreateSampleDesignations(5)
                    });
                    break;

                case 3: // Marketing Department  
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 6,
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(6),
                        Designations = CreateSampleDesignations(6)
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 7,
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(7),
                        Designations = CreateSampleDesignations(7)
                    });
                    break;

                case 4: // Finance Department  
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 8,
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(8),
                        Designations = CreateSampleDesignations(8)
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 9,
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
                        IsActive = true,
                        Addresses = CreateEmployeeSampleAddresses(9),
                        Designations = CreateSampleDesignations(9)
                    });
                    break;

                case 5: // Operations Department  
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 10,
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
                        IsActive = false,
                        Addresses = CreateEmployeeSampleAddresses(10),
                        Designations = CreateSampleDesignations(10)
                    });
                    employees.Add(new EmployeeModel
                    {
                        EmployeeIdPk = 11,
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
                        IsActive = false,
                        Addresses = CreateEmployeeSampleAddresses(11),
                        Designations = CreateSampleDesignations(11)
                    });
                    break;
            }

            return employees;
        }

        private List<EmployeeAddressModel> CreateEmployeeSampleAddresses(int employeeId)
        {
            var random = new Random();
            var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
            var states = new[] { "NY", "CA", "IL", "TX", "AZ" };
            var streets = new[] { "Main St", "Broadway", "1st Ave", "2nd Ave", "Park Ave" };

            return new List<EmployeeAddressModel>
            {
                new EmployeeAddressModel
                {
                    EmployeeAddressIdPk = employeeId * 10 + 1,
                    EmployeeIdFk = employeeId,
                    AddressLine1 = $"{random.Next(100, 999)} {streets[random.Next(streets.Length)]}",
                    AddressLine2 = $"Apt {random.Next(1, 100)}",
                    City = cities[random.Next(cities.Length)],
                    State = states[random.Next(states.Length)],
                    Pincode = $"{random.Next(10000, 99999)}",
                    AddressTypeIdFk = AddressTypes.PRESENT_ADDR,
                    isActive = true
                },
                new EmployeeAddressModel
                {
                    EmployeeAddressIdPk = employeeId * 10 + 2,
                    EmployeeIdFk = employeeId,
                    AddressLine1 = $"{random.Next(100, 999)} {streets[random.Next(streets.Length)]}",
                    AddressLine2 = $"Suite {random.Next(1, 100)}",
                    City = cities[random.Next(cities.Length)],
                    State = states[random.Next(states.Length)],
                    Pincode = $"{random.Next(10000, 99999)}",
                    AddressTypeIdFk = AddressTypes.PERM_ADDR,
                    isActive = true
                },
                new EmployeeAddressModel
                {
                    EmployeeAddressIdPk = employeeId * 10 + 3,
                    EmployeeIdFk = employeeId,
                    AddressLine1 = $"{random.Next(100, 999)} {streets[random.Next(streets.Length)]}",
                    AddressLine2 = $"Floor {random.Next(1, 10)}",
                    City = cities[random.Next(cities.Length)],
                    State = states[random.Next(states.Length)],
                    Pincode = $"{random.Next(10000, 99999)}",
                    AddressTypeIdFk = AddressTypes.PRESENT_ADDR,
                    isActive = false
                }
            };
        }

        private List<EmployeeDesignationModel> CreateSampleDesignations(int employeeId)
        {
            // Generates unique designations for each employee
            var random = new Random();
            var designations = new List<EmployeeDesignationModel>();

            // Generate a random number of designations (between 2 and 4) for each employee
            int designationCount = random.Next(2, 5);

            DateTime startDate = new DateTime(2015, 1, 1);
            for (int i = 0; i < designationCount; i++)
            {
                var designation = new EmployeeDesignationModel
                {
                    EmployeeDesignationIdPk = employeeId * 100 + i + 1,
                    EmployeeIdFk = employeeId,
                    DesignationIdFk = (DesiginationTypes)random.Next(1, Enum.GetValues(typeof(DesiginationTypes)).Length + 1),
                    EffectiveFrom = startDate,
                    EndDate = i == designationCount - 1 ? null : startDate.AddYears(2) // Last designation is active
                };

                if (designation.EndDate.HasValue)
                {
                    startDate = designation.EndDate.Value.AddDays(1);
                }

                designations.Add(designation);
            }

            return designations;
        }

        private List<QualificationLookupModel> CreateQualificationLookupModels()
        {
            return new List<QualificationLookupModel>
            {
                new QualificationLookupModel(1, "BSc", "Bachelor of Science"),
                new QualificationLookupModel(2, "BA", "Bachelor of Arts"),
                new QualificationLookupModel(3, "BCom", "Bachelor of Commerce"),
                new QualificationLookupModel(4, "MSc", "Master of Science"),
                new QualificationLookupModel(5, "MA", "Master of Arts"),
                new QualificationLookupModel(6, "MCom", "Master of Commerce"),
                new QualificationLookupModel(7, "PhD", "Doctor of Philosophy"),
                new QualificationLookupModel(8, "MBA", "Master of Business Administration"),
                new QualificationLookupModel(9, "BTech", "Bachelor of Technology"),
                new QualificationLookupModel(10, "MTech", "Master of Technology"),
                new(11, "Diploma", "Diploma in various fields")
            };
        }
    }
}
