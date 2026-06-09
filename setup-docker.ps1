# Before running this script, ensure you have allowed the execution of PowerShell scripts on your system:
# > Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
# Then run:
# > .\setup-docker.ps1



# 1. Ensure the user has the required directories
$certDir = "$env:USERPROFILE\.aspnet\https"
if (!(Test-Path $certDir)) {
    Write-Host "Creating certificate directory at $certDir..." -ForegroundColor Cyan
    New-Item -ItemType Directory -Force -Path $certDir | Out-Null
}

# 2. Export the certificate if it doesn't already exist
$certPath = "$certDir\aspnetapp.pfx"
if (!(Test-Path $certPath)) {
    Write-Host "Exporting new dev certificate..." -ForegroundColor Cyan
    dotnet dev-certs https -ep $certPath -p yourpassword123 --trust
} else {
    Write-Host "Certificate already exists at $certPath." -ForegroundColor Green
}

# 3. Set the environment variable for the current session
# Note: Docker Compose uses the shell's environment variables
$env:SSL_PATH = $certDir
Write-Host "SSL_PATH set to: $env:SSL_PATH" -ForegroundColor Green

# 4. Run Docker commands
Write-Host "Cleaning up existing containers..." -ForegroundColor Yellow
docker compose down

Write-Host "Starting services..." -ForegroundColor Yellow
docker compose up --build -d

Write-Host "Done! Services should be starting up." -ForegroundColor Green