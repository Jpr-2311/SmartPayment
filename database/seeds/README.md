# Database Seeds

This directory contains seed data files for the FinPilot AI database.

## Structure

Seed files will be organized by entity:

```
seeds/
├── users.json          (Phase 2)
├── categories.json     (Phase 3)
├── sample-data.json    (Phase 4)
└── README.md
```

## Guidelines

- **Development seeds**: Sample data for local development and testing
- **Production seeds**: Only essential lookup/reference data (categories, roles, etc.)
- **Format**: JSON files that are loaded by the seed infrastructure in EF Core
- **Never include**: Real user data, passwords, or sensitive information
