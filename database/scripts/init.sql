-- FinPilot AI - PostgreSQL Initialization Script
-- This script runs when the PostgreSQL container is first created.
-- It sets up the database with required extensions.

-- Enable useful extensions
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";       -- UUID generation
CREATE EXTENSION IF NOT EXISTS "pgcrypto";         -- Cryptographic functions
CREATE EXTENSION IF NOT EXISTS "citext";           -- Case-insensitive text

-- Log initialization
DO $$
BEGIN
    RAISE NOTICE 'FinPilot AI database initialized successfully at %', NOW();
END $$;
