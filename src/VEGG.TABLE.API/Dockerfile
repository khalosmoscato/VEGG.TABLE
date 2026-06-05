# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY VEGG.TABLE.slnx .
COPY src/VEGG.TABLE.API/*.csproj src/VEGG.TABLE.API/
COPY src/VEGG.TABLE.Client/*.csproj src/VEGG.TABLE.Client/
COPY src/VEGG.TABLE.Core/*.csproj src/VEGG.TABLE.Core/
COPY src/VEGG.TABLE.Infrastructure/*.csproj src/VEGG.TABLE.Infrastructure/
RUN dotnet restore src/VEGG.TABLE.API/VEGG.TABLE.API.csproj
COPY src/ src/
RUN dotnet publish src/VEGG.TABLE.API/VEGG.TABLE.API.csproj -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 5167
ENV ASPNETCORE_URLS=http://+:5167
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "VEGG.TABLE.API.dll"]
