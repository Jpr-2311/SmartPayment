#!/usr/bin/env bash
# FinPilot AI - Linux/macOS Setup Script
# Run: chmod +x scripts/setup.sh && ./scripts/setup.sh

set -e

echo ""
echo "========================================"
echo "  FinPilot AI - Project Setup"
echo "========================================"
echo ""

# Check prerequisites
echo "Checking prerequisites..."

if ! command -v node &> /dev/null; then
    echo "  [X] Node.js not found. Install from https://nodejs.org/"
    exit 1
else
    echo "  [OK] Node.js $(node --version)"
fi

if ! command -v dotnet &> /dev/null; then
    echo "  [X] .NET SDK not found. Install from https://dotnet.microsoft.com/"
    exit 1
else
    echo "  [OK] .NET SDK $(dotnet --version)"
fi

if command -v docker &> /dev/null; then
    echo "  [OK] Docker $(docker --version)"
else
    echo "  [!] Docker not found (optional)"
fi

# Frontend setup
echo ""
echo "Setting up Frontend..."
cd frontend
if [ ! -d "node_modules" ]; then
    npm install
else
    echo "  Dependencies already installed"
fi
if [ ! -f ".env.local" ]; then
    cp .env.example .env.local
    echo "  Created .env.local from template"
fi
cd ..

# Backend setup
echo ""
echo "Setting up Backend..."
cd backend
dotnet restore FinPilot.sln
dotnet build FinPilot.sln --no-restore
cd ..

echo ""
echo "========================================"
echo "  Setup Complete!"
echo "========================================"
echo ""
echo "Next steps:"
echo "  1. Start PostgreSQL (Docker or local)"
echo "  2. cd frontend && npm run dev"
echo "  3. cd backend && dotnet run --project src/FinPilot.API"
echo ""
