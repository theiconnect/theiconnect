# EMS.DataAccess - Entity Framework Core (Database First)

This project contains the Entity Framework Core setup for the EMS database using the Database First approach.

## Database Connection

**Connection String:**
```
Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True
```

## Project Structure

- **Entities/** - Contains all entity classes generated from the database
- **Extensions/** - Contains service collection extensions for dependency injection
- **EMSDbContext.cs** - Main DbContext class

## Usage

### Option 1: Using appsettings.json (Recommended)

Add the connection string to your `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "EMSConnection": "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

Register in `Program.cs`:

```csharp
using EMS.DataAccess.Extensions;

builder.Services.AddEMSDataAccess(builder.Configuration);
```

### Option 2: Direct Connection String

```csharp
using EMS.DataAccess.Extensions;

builder.Services.AddEMSDataAccess("Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True");
```

### Option 3: Manual Configuration

```csharp
using EMS.DataAccess;
using Microsoft.EntityFrameworkCore;

builder.Services.AddDbContext<EMSDbContext>(options =>
    options.UseSqlServer("Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True"));
```

## Using in Controllers/Services

Inject the DbContext:

```csharp
public class MyService
{
    private readonly EMSDbContext _context;

    public MyService(EMSDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        return await _context.Departments
            .Where(d => d.IsActive)
            .OrderByDescending(d => d.LastUpdatedOn)
            .ToListAsync();
    }
}
```

## Regenerating Entities (When Database Changes)

Run this command from the `EMS.DataAccess` project directory:

```bash
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=EMS;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities --context-dir . --context EMSDbContext --force
```

**Note:** The `--force` flag will overwrite existing files.

## Available DbSets

- `AllTables` - View
- `Departments` - Department table
- `Tests` - Test table

## Important Notes

1. The DbContext is configured to support both dependency injection and direct instantiation
2. Connection string is embedded as fallback, but should be moved to configuration in production
3. Use async methods (.ToListAsync(), .FirstOrDefaultAsync(), etc.) for better performance
4. Always use `using` statements or dependency injection to ensure proper disposal of DbContext
