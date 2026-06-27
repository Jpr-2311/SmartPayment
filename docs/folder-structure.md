# Folder Structure Explained

## Root Directory

```
finpilot-ai/
├── frontend/       → Next.js frontend application
├── backend/        → ASP.NET Core backend solution
├── database/       → Database scripts, migrations, seeds
├── docker/         → Docker configurations
├── docs/           → Project documentation
├── scripts/        → Automation and utility scripts
├── .github/        → GitHub-specific configurations
├── .gitignore      → Git ignore rules for all stacks
├── .editorconfig   → Cross-IDE formatting consistency
├── LICENSE          → MIT License
└── README.md       → Project overview and quick start
```

### Why each folder exists:

| Folder | Purpose |
|---|---|
| `frontend/` | Isolates the Next.js app with its own `package.json`, enabling independent deployment |
| `backend/` | Contains the .NET solution with Clean Architecture layers as separate projects |
| `database/` | Centralizes all database-related assets — migrations, seeds, and SQL scripts |
| `docker/` | Keeps Docker configs separate from source code for clean CI/CD integration |
| `docs/` | Provides a single documentation hub for architecture, conventions, and setup |
| `scripts/` | Houses automation scripts that don't belong in source code |
| `.github/` | GitHub Actions workflows, PR/issue templates, and CODEOWNERS |

---

## Frontend Structure

```
frontend/src/
├── app/                    → Next.js App Router
│   ├── layout.tsx          → Root layout (providers, fonts, metadata)
│   ├── page.tsx            → Home page
│   ├── loading.tsx         → Global loading UI
│   ├── error.tsx           → Error boundary
│   ├── not-found.tsx       → 404 page
│   └── globals.css         → Global styles + Tailwind + theme tokens
├── components/
│   ├── layout/             → Page structure components
│   │   ├── navbar.tsx      → Top navigation bar
│   │   ├── sidebar.tsx     → Collapsible side navigation
│   │   ├── footer.tsx      → Page footer
│   │   ├── mobile-nav.tsx  → Mobile navigation drawer
│   │   └── main-layout.tsx → Orchestrator for all layout pieces
│   ├── ui/                 → shadcn/ui primitive components
│   ├── shared/             → Reusable custom components
│   │   ├── logo.tsx        → Brand logo
│   │   ├── empty-state.tsx → No-data placeholder
│   │   ├── skeleton-card.tsx → Loading skeleton
│   │   ├── page-header.tsx → Consistent page headers
│   │   └── loading-screen.tsx → Full-screen loader
│   └── providers/          → React context providers
│       ├── theme-provider.tsx → Dark/light mode
│       ├── query-provider.tsx → TanStack Query
│       └── toast-provider.tsx → Sonner toasts
├── hooks/                  → Custom React hooks
├── lib/                    → Utility functions
│   ├── utils.ts            → cn() helper
│   ├── api-client.ts       → Axios instance
│   └── constants.ts        → App configuration
└── types/                  → Global TypeScript types
```

---

## Backend Structure

```
backend/
├── FinPilot.sln            → Solution file
├── src/
│   ├── FinPilot.API/       → Presentation layer (entry point)
│   │   ├── Controllers/    → API endpoints
│   │   ├── Middleware/      → Request pipeline middleware
│   │   ├── Extensions/     → Service registration helpers
│   │   ├── Program.cs      → Application bootstrap
│   │   └── appsettings.*   → Environment-specific configuration
│   ├── FinPilot.Application/  → Business logic layer
│   │   └── Common/
│   │       ├── Interfaces/  → Repository & UoW contracts
│   │       ├── Models/      → Result pattern, DTOs
│   │       └── Exceptions/  → Custom exception types
│   ├── FinPilot.Domain/    → Core entities layer
│   │   └── Common/
│   │       ├── BaseEntity.cs
│   │       ├── BaseAuditableEntity.cs
│   │       └── IDomainEvent.cs
│   ├── FinPilot.Infrastructure/  → External concerns
│   │   ├── Persistence/    → EF Core DbContext
│   │   ├── Logging/        → Serilog configuration
│   │   └── Extensions/     → DI registration
│   └── FinPilot.Shared/    → Cross-cutting concerns
│       └── Constants/      → App-wide constants
└── tests/                  → Test projects (structure only)
```
