import type { Metadata, Viewport } from 'next';
import { Inter } from 'next/font/google';
import { ThemeProvider, QueryProvider, ToastProvider } from '@/components/providers';
import './globals.css';

const inter = Inter({
  subsets: ['latin'],
  variable: '--font-sans',
  display: 'swap',
});

export const metadata: Metadata = {
  title: {
    default: 'FinPilot AI — Smart Finance Platform',
    template: '%s | FinPilot AI',
  },
  description:
    'AI-powered personal finance management and smart payment platform. Track expenses, manage wallets, pay bills, and get intelligent financial insights.',
  keywords: [
    'finance',
    'AI',
    'expense tracker',
    'wallet',
    'bill payment',
    'budget',
    'analytics',
  ],
  authors: [{ name: 'FinPilot AI Team' }],
  creator: 'FinPilot AI',
  metadataBase: new URL('http://localhost:3000'),
  openGraph: {
    type: 'website',
    locale: 'en_US',
    siteName: 'FinPilot AI',
    title: 'FinPilot AI — Smart Finance Platform',
    description:
      'AI-powered personal finance management and smart payment platform.',
  },
};

export const viewport: Viewport = {
  themeColor: [
    { media: '(prefers-color-scheme: light)', color: '#f8fafc' },
    { media: '(prefers-color-scheme: dark)', color: '#0f172a' },
  ],
  width: 'device-width',
  initialScale: 1,
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en" suppressHydrationWarning className={`${inter.variable} h-full`}>
      <body className="min-h-full font-sans antialiased">
        <ThemeProvider>
          <QueryProvider>
            <ToastProvider>{children}</ToastProvider>
          </QueryProvider>
        </ThemeProvider>
      </body>
    </html>
  );
}
