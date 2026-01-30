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

    public virtual DbSet<AllTable> AllTables { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTypeLookup>(entity =>
        {
            entity.HasKey(e => e.AddressTypeIdPk).HasName("PK__AddressT__C1CF6F303BAE905B");

            entity.ToTable("AddressTypeLookup");

            entity.Property(e => e.AddressTypeIdPk).ValueGeneratedNever();
            entity.Property(e => e.AddressTypeCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddressTypeDescription)
                .HasMaxLength(512)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AllTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("allTables");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DataRetentionPeriod).HasColumnName("data_retention_period");
            entity.Property(e => e.DataRetentionPeriodUnit).HasColumnName("data_retention_period_unit");
            entity.Property(e => e.DataRetentionPeriodUnitDesc)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("data_retention_period_unit_desc");
            entity.Property(e => e.Durability).HasColumnName("durability");
            entity.Property(e => e.DurabilityDesc)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("durability_desc");
            entity.Property(e => e.FilestreamDataSpaceId).HasColumnName("filestream_data_space_id");
            entity.Property(e => e.HasReplicationFilter).HasColumnName("has_replication_filter");
            entity.Property(e => e.HasUncheckedAssemblyData).HasColumnName("has_unchecked_assembly_data");
            entity.Property(e => e.HistoryRetentionPeriod).HasColumnName("history_retention_period");
            entity.Property(e => e.HistoryRetentionPeriodUnit).HasColumnName("history_retention_period_unit");
            entity.Property(e => e.HistoryRetentionPeriodUnitDesc)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("history_retention_period_unit_desc");
            entity.Property(e => e.HistoryTableId).HasColumnName("history_table_id");
            entity.Property(e => e.IsDroppedLedgerTable).HasColumnName("is_dropped_ledger_table");
            entity.Property(e => e.IsEdge).HasColumnName("is_edge");
            entity.Property(e => e.IsExternal).HasColumnName("is_external");
            entity.Property(e => e.IsFiletable).HasColumnName("is_filetable");
            entity.Property(e => e.IsMemoryOptimized).HasColumnName("is_memory_optimized");
            entity.Property(e => e.IsMergePublished).HasColumnName("is_merge_published");
            entity.Property(e => e.IsMsShipped).HasColumnName("is_ms_shipped");
            entity.Property(e => e.IsNode).HasColumnName("is_node");
            entity.Property(e => e.IsPublished).HasColumnName("is_published");
            entity.Property(e => e.IsRemoteDataArchiveEnabled).HasColumnName("is_remote_data_archive_enabled");
            entity.Property(e => e.IsReplicated).HasColumnName("is_replicated");
            entity.Property(e => e.IsSchemaPublished).HasColumnName("is_schema_published");
            entity.Property(e => e.IsSyncTranSubscribed).HasColumnName("is_sync_tran_subscribed");
            entity.Property(e => e.IsTrackedByCdc).HasColumnName("is_tracked_by_cdc");
            entity.Property(e => e.LargeValueTypesOutOfRow).HasColumnName("large_value_types_out_of_row");
            entity.Property(e => e.LedgerType).HasColumnName("ledger_type");
            entity.Property(e => e.LedgerTypeDesc)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("ledger_type_desc");
            entity.Property(e => e.LedgerViewId).HasColumnName("ledger_view_id");
            entity.Property(e => e.LobDataSpaceId).HasColumnName("lob_data_space_id");
            entity.Property(e => e.LockEscalation).HasColumnName("lock_escalation");
            entity.Property(e => e.LockEscalationDesc)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("lock_escalation_desc");
            entity.Property(e => e.LockOnBulkLoad).HasColumnName("lock_on_bulk_load");
            entity.Property(e => e.MaxColumnIdUsed).HasColumnName("max_column_id_used");
            entity.Property(e => e.ModifyDate)
                .HasColumnType("datetime")
                .HasColumnName("modify_date");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ParentObjectId).HasColumnName("parent_object_id");
            entity.Property(e => e.PrincipalId).HasColumnName("principal_id");
            entity.Property(e => e.SchemaId).HasColumnName("schema_id");
            entity.Property(e => e.Script)
                .HasMaxLength(142)
                .HasColumnName("script");
            entity.Property(e => e.TemporalType).HasColumnName("temporal_type");
            entity.Property(e => e.TemporalTypeDesc)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("temporal_type_desc");
            entity.Property(e => e.TextInRowLimit).HasColumnName("text_in_row_limit");
            entity.Property(e => e.Type)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("type");
            entity.Property(e => e.TypeDesc)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS_KS_WS")
                .HasColumnName("type_desc");
            entity.Property(e => e.UsesAnsiNulls).HasColumnName("uses_ansi_nulls");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyIdPk).HasName("PK__Company__660E842F32A22B8A");

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
            entity.HasKey(e => e.CompanyAddressIdPk).HasName("PK__CompanyA__566845344A8067C8");

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
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PinCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.CompanyIdFkNavigation).WithMany(p => p.CompanyAddresses)
                .HasForeignKey(d => d.CompanyIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyAddress_Company");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentIdPk).HasName("PK__tmp_ms_x__B32AAA327D12A67B");

            entity.ToTable("Department");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(500)
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

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeIdPk).HasName("PK__Employee__0EEEF62952B5E3AA");

            entity.ToTable("Employee");

            entity.Property(e => e.AlternateMobileNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PersonalEmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SalaryCtc).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<EmployeeAddress>(entity =>
        {
            entity.HasKey(e => e.EmployeeAddressIdPk).HasName("PK__tmp_ms_x__5F6CA74EE98A0313");

            entity.ToTable("EmployeeAddress");

            entity.Property(e => e.AddressLine1)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeIdfk).HasColumnName("EmployeeIDFk");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Pincode)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("PINCode");
            entity.Property(e => e.State)
                .HasMaxLength(512)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEST");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
