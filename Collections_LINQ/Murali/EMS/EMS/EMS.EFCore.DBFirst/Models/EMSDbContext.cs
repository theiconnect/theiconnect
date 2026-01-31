using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMS.EFCore.DBFirst.Models;

public partial class EMSDbContext : DbContext
{
    public EMSDbContext()
    {
    }

    public EMSDbContext(DbContextOptions<EMSDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressTypeLookup> AddressTypeLookups { get; set; }

    public virtual DbSet<BloodGroup> BloodGroups { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentAddress> DepartmentAddresses { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

    public virtual DbSet<EmployeeCtc> EmployeeCtcs { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTypeLookup>(entity =>
        {
            entity.HasKey(e => e.AddressTypeIdPk).HasName("PK__AddressT__C1CF6F3030699EC0");

            entity.ToTable("AddressTypeLookup");

            entity.Property(e => e.AddressTypeIdPk).ValueGeneratedNever();
            entity.Property(e => e.AddressTypeCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddressTypeDescription)
                .HasMaxLength(512)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BloodGroup>(entity =>
        {
            entity.HasKey(e => e.BloodGroupIdPk).HasName("PK__BloodGro__9C20C86653297B46");

            entity.ToTable("BloodGroup");

            entity.HasIndex(e => e.BloodGroupName, "UQ__BloodGro__C45CCC5DE2F858F9").IsUnique();

            entity.Property(e => e.BloodGroupName)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyIdPk).HasName("PK__Company__660E842F20F8351B");

            entity.ToTable("Company");

            entity.Property(e => e.BankAccountNumber)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Pan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PAN");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.Tin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TIN");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CompanyAddress>(entity =>
        {
            entity.HasKey(e => e.CompanyAddressIdPk).HasName("PK__CompanyA__5668453437033E73");

            entity.ToTable("CompanyAddress");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PinCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.AddressTypeIdFkNavigation).WithMany(p => p.CompanyAddresses)
                .HasForeignKey(d => d.AddressTypeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_AddressTypeIdFk");

            entity.HasOne(d => d.CompanyIdFkNavigation).WithMany(p => p.CompanyAddresses)
                .HasForeignKey(d => d.CompanyIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_CompanyId");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentIdPk).HasName("PK__tmp_ms_x__B32AAA32323403BD");

            entity.ToTable("Department");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepartmentAddress>(entity =>
        {
            entity.HasKey(e => e.DepartmentAddressIdPk).HasName("PK__Departme__BA30214A09BE7A97");

            entity.ToTable("DepartmentAddress");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PinCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.AddressTypeIdFkNavigation).WithMany(p => p.DepartmentAddresses)
                .HasForeignKey(d => d.AddressTypeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentAddress_AddressType");
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.DesignationIdPk).HasName("PK__Designat__6CE01620841EBDE0");

            entity.ToTable("Designation");

            entity.HasIndex(e => e.DesignationName, "UQ__Designat__372CDC235EBD3391").IsUnique();

            entity.Property(e => e.DesignationName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeIdPk).HasName("PK__EMPLOYEE__0EEEF62924499FCC");

            entity.ToTable("EMPLOYEE");

            entity.HasIndex(e => e.EmployeeCode, "UQ__EMPLOYEE__1F64254828D86C7C").IsUnique();

            entity.Property(e => e.AlternateMobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Lwd).HasColumnName("LWD");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PersonalEmailId)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.SalaryCtc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SalaryCTc");

            entity.HasOne(d => d.BloodGroupIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BloodGroupIdFk)
                .HasConstraintName("fk_BloodGroupIdFk");

            entity.HasOne(d => d.DepartmentIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentIdFk)
                .HasConstraintName("fk_DepartmentIdFk");

            entity.HasOne(d => d.DesignationIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DesignationIdFk)
                .HasConstraintName("fk_DesignationIdFk");

            entity.HasOne(d => d.GenderIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderIdFk)
                .HasConstraintName("fk_GenderIdFk");

            entity.HasOne(d => d.QualificationIdFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.QualificationIdFk)
                .HasConstraintName("fk_QualificationIdFk");
        });

        modelBuilder.Entity<EmployeeAddress>(entity =>
        {
            entity.HasKey(e => e.EmployeeAddressIdPk).HasName("PK__Employee__5F6CA74E5349113F");

            entity.ToTable("EmployeeAddress");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PinCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.AddressTypeIdFkNavigation).WithMany(p => p.EmployeeAddresses)
                .HasForeignKey(d => d.AddressTypeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAddress_AddressType");
        });

        modelBuilder.Entity<EmployeeCtc>(entity =>
        {
            entity.HasKey(e => e.EmployeeCtcpk).HasName("PK__Employee__AB07400D7AB1BF7E");

            entity.ToTable("EmployeeCTC");

            entity.Property(e => e.EmployeeCtcpk).HasColumnName("EmployeeCTCPk");
            entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.SalaryCtc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SalaryCTC");

            entity.HasOne(d => d.EmployeeIdFkNavigation).WithMany(p => p.EmployeeCtcs)
                .HasForeignKey(d => d.EmployeeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeCTC_Employee");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderIdPk).HasName("PK__Gender__5DE25793747D178D");

            entity.ToTable("Gender");

            entity.HasIndex(e => e.GenderName, "UQ__Gender__F7C177151D908589").IsUnique();

            entity.Property(e => e.GenderName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.QualificationIdPk).HasName("PK__Qualific__4E1AEE3745C24A74");

            entity.ToTable("Qualification");

            entity.HasIndex(e => e.QualificationName, "UQ__Qualific__49C0FCDBA70BFA3E").IsUnique();

            entity.Property(e => e.QualificationName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
