
/*

Package Manager Console Commands:
Tools> NuGet Package Manager > Package Manager Console
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.0

Step-I


*Since you are on .NET 8, you must install the version that matches your framework (Version 8.x.x). 
1. Install for EMS.EFCore.DBFirst:

PowerShell Commands:
dotnet add EMS.EFCore.DBFirst package Microsoft.EntityFrameworkCore.SqlServer -v 8.0.0
dotnet add EMS.EFCore.DBFirst package Microsoft.EntityFrameworkCore.Tools -v 8.0.0


2. Install for EMS.Web (Required for Scaffolding): The tooling needs the "Design" package in your startup project to bridge the gap between your database and your code.
PowerShell Commands:
    dotnet add EMS.Web package Microsoft.EntityFrameworkCore.Design -v 8.0.0


Step II: The Scaffolding Command
Now that the packages are compatible, you can generate your models.

Make sure you replace the placeholders (like YOUR_SERVER_NAME and YOUR_DATABASE_NAME) with your actual SQL Server details. If you are using a local SQL instance, the server is often . or (localdb)\mssqllocaldb.

command:
Scaffold-DbContext "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context EMSDbContext -Project EMS.EFCore.DBFirst -StartupProject EMS.Web


Now you should see the generated models inside the "Models" folder of your EMS.EFCore.DBFirst project.
sCaffold:
============
PM> Scaffold-DbContext "Server=.;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context EMSDbContext -Project EMS.EFCore.DBFirst -StartupProject EMS.Web

RE- sCaffold when database changes:
========================================
Scaffold-DbContext "Server=.;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context EMSDbContext -Project EMS.EFCore.DBFirst -StartupProject EMS.Web -Force

*/