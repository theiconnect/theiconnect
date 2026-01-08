# EF Core Database First - Package Manager Console Guide

This guide explains how to use Entity Framework Core Database First approach using **Visual Studio's Package Manager Console (PMC)**.

## Prerequisites

1. **Visual Studio 2022** (or Visual Studio 2019)
2. **Required NuGet Packages** (already installed in this project):
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`
   - `Microsoft.EntityFrameworkCore.Design`

## Connection String

```
Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True
```

---

## Initial Setup - Scaffolding Database

### Step 1: Open Package Manager Console

In Visual Studio:
- Go to **Tools** → **NuGet Package Manager** → **Package Manager Console**
- Make sure the **Default project** dropdown shows: `EMS.DataAccess`

### Step 2: Run Scaffold Command

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -Force
```

**Parameters Explained:**
- `Scaffold-DbContext` - The PMC command (note: capital **C** in DbContext)
- Connection string - Your database connection
- `Microsoft.EntityFrameworkCore.SqlServer` - The database provider
- `-OutputDir Entities` - Folder for entity classes
- `-Context EMSDbContext` - Name of the DbContext class
- `-Force` - Overwrites existing files

### Step 3: Verify Generated Files

After successful scaffolding, you should see:
```
EMS.DataAccess/
├── EMSDbContext.cs          ← DbContext class
└── Entities/                ← Entity classes folder
    ├── Department.cs
    ├── Test.cs
    └── AllTable.cs
```

---

## Refreshing When Database Changes

When you make changes to your database (add/modify tables, columns, etc.), you need to regenerate the entities.

### Option 1: Regenerate Everything (Recommended)

Use the `-Force` flag to overwrite all files:

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -Force
```

⚠️ **Warning:** This will **overwrite** all entity classes and the DbContext. Any manual changes will be lost!

### Option 2: Scaffold Specific Tables

If you only want to regenerate specific tables:

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -Tables Department,Employee -Force
```

**Parameters:**
- `-Tables Department,Employee` - Comma-separated list of table names

### Option 3: Keep Manual Changes (Partial Classes)

To preserve custom code when regenerating:

1. **Use partial classes** - All generated classes are `partial`
2. **Create companion partial class files** for your custom code

Example:
```csharp
// Entities/Department.Custom.cs (your custom file)
namespace EMS.DataAccess.Entities
{
    public partial class Department
    {
        // Your custom properties or methods
        public string DisplayName => $"{DepartmentCode} - {DepartmentName}";
    }
}
```

When you regenerate, `Department.cs` gets overwritten, but `Department.Custom.cs` remains untouched.

---

## Advanced Scaffolding Options

### Include Only Specific Schemas

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -Schemas dbo -Force
```

### No Pluralization

Prevent EF from pluralizing DbSet names:

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -NoPluralize -Force
```

### Use Data Annotations Instead of Fluent API

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -DataAnnotations -Force
```

### Separate Context Directory

```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -ContextDir . -Context EMSDbContext -Force
```

---

## Best Practices for Database Changes

### 🔄 Workflow When Database Schema Changes

1. **Make database changes** (add tables, modify columns, etc.)
2. **Backup custom code** (if you have any manual modifications)
3. **Run scaffold command** with `-Force` flag
4. **Review changes** in source control (Git diff)
5. **Re-apply custom code** if needed (or use partial classes)
6. **Test the application**

### ✅ Recommended Approach

**Use partial classes for custom logic:**

```csharp
// Generated: Entities/Department.cs (gets overwritten)
public partial class Department
{
    public int DepartmentIdPk { get; set; }
    public string DepartmentName { get; set; }
    // ... other generated properties
}

// Custom: Entities/Department.Custom.cs (never touched by scaffold)
public partial class Department
{
    public string FullDescription => $"{DepartmentCode}: {DepartmentName} ({Location})";
    
    public bool IsLocationSet => !string.IsNullOrEmpty(DeptLocation);
}
```

### 🚫 What NOT to Do

❌ Don't modify generated files directly (they'll be overwritten)  
❌ Don't forget the `-Force` flag (it will fail if files exist)  
❌ Don't scaffold without source control (use Git to track changes)  
❌ Don't scaffold in production (only in development environment)

---

## Common Errors & Solutions

### Error 1: "Unable to find provider assembly"
```
Add-Migration : Unable to resolve service for type 'Microsoft.EntityFrameworkCore.Migrations.IMigrator'
```
**Solution:** Make sure `Microsoft.EntityFrameworkCore.Design` is installed

### Error 2: "The term 'Scaffold-DbContext' is not recognized"
**Solution:** 
- You're not in Visual Studio's Package Manager Console
- Or `Microsoft.EntityFrameworkCore.Tools` package is not installed

### Error 3: "Build failed"
**Solution:** Build the project first before running scaffold commands
```powershell
# Build first
dotnet build

# Then scaffold
Scaffold-DbContext "..." ...
```

### Error 4: Connection fails
```
A network-related or instance-specific error occurred while establishing a connection to SQL Server
```
**Solution:** 
- Verify SQL Server is running
- Test connection string in SSMS first
- Check firewall settings

---

## PMC vs .NET CLI Comparison

| Feature | Package Manager Console | .NET CLI |
|---------|------------------------|----------|
| **Command** | `Scaffold-DbContext` | `dotnet ef dbcontext scaffold` |
| **Where** | Visual Studio only | Any terminal |
| **Syntax** | `-OutputDir` (single dash) | `--output-dir` (double dash) |
| **Project Selection** | Dropdown in PMC | Must navigate to folder |
| **Best For** | Visual Studio users | VS Code, CI/CD, automation |

**Example Comparison:**

```powershell
# Package Manager Console (Visual Studio)
Scaffold-DbContext "..." Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Force

# .NET CLI (Any terminal)
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities --force
```

---

## Quick Reference

### Full Command Template
```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" `
    Microsoft.EntityFrameworkCore.SqlServer `
    -OutputDir Entities `
    -Context EMSDbContext `
    -Force `
    -DataAnnotations `
    -NoPluralize
```

### Regenerate After DB Changes
```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -Force
```

### Scaffold Specific Tables Only
```powershell
Scaffold-DbContext "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EMSDbContext -Tables Department,Employee,Company -Force
```

---

## Additional Resources

- [Microsoft Docs - Scaffolding](https://docs.microsoft.com/ef/core/managing-schemas/scaffolding)
- [EF Core Database First Tutorial](https://docs.microsoft.com/ef/core/get-started/overview/first-app?tabs=visual-studio)
- [Package Manager Console Reference](https://docs.microsoft.com/nuget/consume-packages/install-use-packages-powershell)

---

## See Also

- [README_EFCore.md](README_EFCore.md) - General EF Core usage guide
- [README.md](README.md) - Project documentation
