# FinPilot AI - Windows Setup Script
# Run: .\scripts\setup.ps1

$ErrorActionPreference = "Stop"

Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "  FinPilot AI - Project Setup (Windows)" -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

# Check prerequisites
function Test-Command($cmd) {
    return [bool](Get-Command $cmd -ErrorAction SilentlyContinue)
}

Write-Host "Checking prerequisites..." -ForegroundColor Yellow

if (-not (Test-Command "node")) {
    Write-Host "  [X] Node.js not found. Install from https://nodejs.org/" -ForegroundColor Red
    exit 1
} else {
    $nodeVersion = node --version
    Write-Host "  [OK] Node.js $nodeVersion" -ForegroundColor Green
}

if (-not (Test-Command "dotnet")) {
    Write-Host "  [X] .NET SDK not found. Install from https://dotnet.microsoft.com/" -ForegroundColor Red
    exit 1
} else {
    $dotnetVersion = dotnet --version
    Write-Host "  [OK] .NET SDK $dotnetVersion" -ForegroundColor Green
}

if (Test-Command "docker") {
    $dockerVersion = docker --version
    Write-Host "  [OK] Docker $dockerVersion" -ForegroundColor Green
} else {
    Write-Host "  [!] Docker not found (optional)" -ForegroundColor Yellow
}

# Frontend setup
Write-Host "`nSetting up Frontend..." -ForegroundColor Yellow
Push-Location frontend
if (-not (Test-Path "node_modules")) {
    npm install
} else {
    Write-Host "  Dependencies already installed" -ForegroundColor Gray
}
if (-not (Test-Path ".env.local")) {
    Copy-Item ".env.example" ".env.local"
    Write-Host "  Created .env.local from template" -ForegroundColor Green
}
Pop-Location

# Backend setup
Write-Host "`nSetting up Backend..." -ForegroundColor Yellow
Push-Location backend
dotnet restore FinPilot.sln
dotnet build FinPilot.sln --no-restore
Pop-Location

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "  Setup Complete!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host "`nNext steps:"
Write-Host "  1. Start PostgreSQL (Docker or local)"
Write-Host "  2. cd frontend && npm run dev"
Write-Host "  3. cd backend && dotnet run --project src/FinPilot.API"
Write-Host ""
