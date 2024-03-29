dotnet new sln -n Demo

# Creating Web project
dotnet new webapp -n Web -o .\src\Web
dotnet sln add .\src\Web\Web.csproj

# Creating Models project
dotnet new classlib -n Models -o .\src\Models
dotnet sln add .\src\Models\Models.csproj
dotnet add .\src\Web\Web.csproj reference .\src\Models\Models.csproj
dotnet add .\src\Models\Models.csproj package SkiaSharp

# Creating application project
dotnet new classlib -n Application -o .\src\Application
dotnet sln add .\src\Application\Application.csproj
dotnet add .\src\Application\Application.csproj reference .\src\Models\Models.csproj
dotnet add .\src\Web\Web.csproj reference .\src\Application\Application.csproj

# Creating persistence project
dotnet new classlib -n TestPersistence -o .\src\TestPersistence
dotnet sln add .\src\TestPersistence\TestPersistence.csproj
dotnet add .\src\TestPersistence\TestPersistence.csproj reference .\src\Models\Models.csproj
dotnet add .\src\TestPersistence\TestPersistence.csproj reference .\src\Application\Application.csproj
dotnet add .\src\Web\Web.csproj reference .\src\TestPersistence\TestPersistence.csproj

# Creating test projects
dotnet new xunit -o .\tests\UnitTests
dotnet sln add .\tests\UnitTests\UnitTests.csproj
dotnet add .\tests\UnitTests\UnitTests.csproj reference .\src\Models\Models.csproj
dotnet add .\tests\UnitTests\UnitTests.csproj reference .\src\Application\Application.csproj

dotnet new xunit -o .\tests\IntegrationTests
dotnet sln add .\tests\IntegrationTests\IntegrationTests.csproj

# Configurating to Trust Dev Certificates for https
dotnet dev-certs https --trust

# dotnet run --project .\Web\Web.csproj --launch-profile https