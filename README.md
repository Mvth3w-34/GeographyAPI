**Purpose**: 
The goal of this project is to provide read only data on countries, the languages they speak, and the difficulty to learn those languages

**Pre-reqs**:
- .NET 9 SDK
- SQL Server Management Studio (optional)
  
**Tech Stack**:
- Framework: .NET 9 (C#)
- ORM: EF Core
- Database: SQL Server
- Testing: xUnit & NSubstitute
- Security: JWT Bearer Authentication

**Configuration**:
- dotnet user-secrets init --project "C:\Path\To\YourAPIProject.csproj"
- dotnet user-secrets set "ConnectionStrings:DefaultConnection" "ConnectionString" --project "C:\Path\To\YourAPIProject.csproj" 
- dotnet user-secrets set "Jwt:Secret" "YourSecret" --project "C:\Path\To\YourAPIProject.csproj"
- dotnet user-secrets set "Jwt:Issuer" "YourIssuer" --project "C:\Path\To\YourAPIProject.csproj"
- dotnet user-secrets set "Jwt:Audience" "YourAudience" --project "C:\Path\To\YourAPIProject.csproj"
- dotnet user-secrets set "Jwt:Expiry" "ExpiryTimeInMinutes" --project "C:\Path\To\YourAPIProject.csproj"
  
**Future things to Implement**:
- Containerization: Implement Docker and Docker Compose for local database management.
- Cloud Deployment: CI/CD pipeline integration with GitHub Actions.
- Performance: Introduce Redis caching for read-heavy endpoints.
