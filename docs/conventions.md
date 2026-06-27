# Development Conventions

## Naming Conventions

### Folders
| Stack | Convention | Example |
|---|---|---|
| Frontend | kebab-case | `user-profile/`, `shared/` |
| Backend | PascalCase | `Controllers/`, `Common/` |

### Files
| Stack | Convention | Example |
|---|---|---|
| TypeScript/TSX | kebab-case | `api-client.ts`, `page-header.tsx` |
| C# | PascalCase | `ApplicationDbContext.cs`, `HealthController.cs` |

### Components
| Type | Convention | Example |
|---|---|---|
| React Components | PascalCase export, kebab-case file | `export function PageHeader()` in `page-header.tsx` |
| C# Classes | PascalCase | `GlobalExceptionMiddleware` |

### Variables & Functions
| Stack | Convention | Example |
|---|---|---|
| TypeScript | camelCase | `const apiClient`, `function toggleTheme()` |
| C# | camelCase (local), PascalCase (public) | `var userId`, `public async Task GetByIdAsync()` |

---

## Git Conventions

### Commit Messages (Conventional Commits)

```
<type>(<scope>): <short description>

[optional body]

[optional footer(s)]
```

**Types:**
| Type | Usage |
|---|---|
| `feat` | New feature |
| `fix` | Bug fix |
| `docs` | Documentation only |
| `style` | Formatting, no logic change |
| `refactor` | Code restructuring |
| `test` | Adding or fixing tests |
| `chore` | Build, CI, dependencies |
| `perf` | Performance improvement |

**Examples:**
```
feat(auth): add JWT token generation
fix(wallet): correct balance calculation rounding
docs(api): update Swagger descriptions for v1 endpoints
chore(deps): upgrade Next.js to 16.3
```

### Branch Strategy

```
main                    ← Production-ready code
├── develop             ← Integration branch
│   ├── feature/auth-jwt        ← New features
│   ├── feature/wallet-ui
│   ├── bugfix/balance-calc     ← Bug fixes
│   └── hotfix/security-patch   ← Urgent production fixes
└── release/1.0.0               ← Release preparation
```

**Rules:**
- `main` is always deployable
- Feature branches merge into `develop` via PR
- Releases branch from `develop`, merge into `main` + `develop`
- Hotfixes branch from `main`, merge into `main` + `develop`

---

## Coding Standards

### TypeScript / React
- **Strict mode** enabled in `tsconfig.json`
- Explicit return types on exported functions
- Prefer `interface` over `type` for object shapes
- Use barrel exports (`index.ts`) for public APIs
- Component props defined with `interface`, not inline
- Prefer named exports over default exports (except pages)

### C# / .NET
- **Nullable reference types** enabled
- Follow Microsoft C# coding conventions
- SOLID principles enforced
- Async/await everywhere (no `.Result` or `.Wait()`)
- Use `CancellationToken` on all async methods
- XML documentation on all public APIs

---

## Error Handling Strategy

### Backend
- **Result Pattern**: Use `Result<T>` for expected business failures
- **Exceptions**: Only for truly exceptional/unexpected scenarios
- **Global Middleware**: `GlobalExceptionMiddleware` catches all unhandled exceptions
- **Custom Exceptions**: Map to specific HTTP status codes

### Frontend
- **Error Boundaries**: Next.js `error.tsx` for runtime errors
- **API Errors**: Intercepted by Axios response interceptor
- **User Feedback**: Toast notifications via Sonner for inline errors
- **Loading States**: Skeleton loaders prevent layout shifts

---

## Logging Strategy

### Backend (Serilog)
- **Structured logging** with semantic properties
- **Console sink** for development
- **File sink** with daily rolling for production
- **Log levels**: Debug (dev), Information (staging), Warning (prod)
- **Correlation IDs** via HTTP context (future Phase 2)

### Frontend
- `console.error` for development
- Error monitoring service integration (future Phase 10)

---

## Validation Strategy

### Backend (FluentValidation)
- Validators in `Application` layer
- One validator per request DTO
- Validated via MediatR pipeline behavior
- Returns structured error responses with field-level details

### Frontend (Zod + React Hook Form)
- Zod schemas define validation rules
- `@hookform/resolvers` bridges Zod → React Hook Form
- Real-time validation feedback in forms
- Schemas can be shared for client-side + server-side consistency
