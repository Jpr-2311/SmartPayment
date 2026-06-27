/**
 * Global TypeScript type definitions for FinPilot AI.
 * Feature-specific types should live within their feature folders.
 */

/** Generic API response wrapper */
export interface ApiResponse<T> {
  data: T;
  success: boolean;
  message: string;
  errors?: string[];
}

/** Paginated API response */
export interface PaginatedResponse<T> {
  data: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}

/** Navigation item shape */
export interface NavItem {
  title: string;
  href: string;
  icon: string;
  description?: string;
  badge?: string;
  disabled?: boolean;
}

/** Common component props */
export interface PageHeaderProps {
  title: string;
  description?: string;
  children?: React.ReactNode;
}

/** Theme options */
export type Theme = 'light' | 'dark' | 'system';
