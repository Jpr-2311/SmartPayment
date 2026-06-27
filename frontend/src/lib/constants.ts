/**
 * Application-wide constants for FinPilot AI.
 */
export const APP_CONFIG = {
  name: process.env.NEXT_PUBLIC_APP_NAME || 'FinPilot AI',
  version: process.env.NEXT_PUBLIC_APP_VERSION || '0.1.0',
  description: 'AI-Powered Personal Finance & Smart Payment Platform',
  apiUrl: process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5000/api',
} as const;

/**
 * Navigation items for sidebar.
 * Icons are Lucide React icon names.
 */
export const NAV_ITEMS = [
  {
    title: 'Dashboard',
    href: '/dashboard',
    icon: 'LayoutDashboard',
    description: 'Overview of your finances',
  },
  {
    title: 'Transactions',
    href: '/transactions',
    icon: 'ArrowLeftRight',
    description: 'View all transactions',
  },
  {
    title: 'Wallet',
    href: '/wallet',
    icon: 'Wallet',
    description: 'Manage your wallets',
  },
  {
    title: 'Bills & Recharge',
    href: '/bills',
    icon: 'Receipt',
    description: 'Pay bills and recharge',
  },
  {
    title: 'Analytics',
    href: '/analytics',
    icon: 'BarChart3',
    description: 'Spending insights',
  },
  {
    title: 'AI Assistant',
    href: '/ai-assistant',
    icon: 'Bot',
    description: 'Get AI financial advice',
  },
  {
    title: 'Reports',
    href: '/reports',
    icon: 'FileText',
    description: 'Financial reports',
  },
  {
    title: 'Settings',
    href: '/settings',
    icon: 'Settings',
    description: 'App settings',
  },
] as const;

/**
 * Breakpoints matching Tailwind CSS defaults.
 */
export const BREAKPOINTS = {
  sm: 640,
  md: 768,
  lg: 1024,
  xl: 1280,
  '2xl': 1536,
} as const;
