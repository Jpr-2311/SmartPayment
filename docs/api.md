# API Documentation

## Base URL

```
Development: http://localhost:5000/api/v1
Staging:     https://staging-api.finpilot.ai/api/v1
Production:  https://api.finpilot.ai/api/v1
```

## API Versioning

The API supports versioning through URL segments:

```
/api/v1/health      ← Version 1
/api/v2/health      ← Version 2 (future)
```

Alternatively, version can be specified via header:
```
X-API-Version: 1.0
```

## Response Format

### Success Response
```json
{
  "data": { ... },
  "success": true,
  "message": "Operation completed successfully"
}
```

### Error Response
```json
{
  "status": 422,
  "message": "One or more validation errors occurred.",
  "errors": [
    "Email is required",
    "Password must be at least 8 characters"
  ],
  "traceId": "00-abc123...",
  "timestamp": "2026-06-26T12:00:00Z"
}
```

## Available Endpoints (Phase 1)

### Health Check

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/v1/health` | Basic health status |
| GET | `/api/v1/health/detailed` | Detailed health with database check |

### Swagger UI

Interactive API documentation is available at `/swagger` in Development and Staging environments.

## Authentication (Phase 2)

Authentication will use JWT Bearer tokens:

```
Authorization: Bearer <token>
```

## Rate Limiting (Phase 10)

Rate limiting will be implemented in the deployment phase.
