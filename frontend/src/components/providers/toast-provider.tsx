'use client';

import { Toaster } from 'sonner';
import { useTheme } from 'next-themes';
import type { ReactNode } from 'react';

interface ToastProviderProps {
  children: ReactNode;
}

/**
 * Toast notification provider using Sonner.
 * Automatically adapts to the current theme (dark/light).
 */
export function ToastProvider({ children }: ToastProviderProps) {
  const { resolvedTheme } = useTheme();

  return (
    <>
      {children}
      <Toaster
        theme={resolvedTheme as 'dark' | 'light' | undefined}
        position="bottom-right"
        richColors
        closeButton
        toastOptions={{
          duration: 4000,
          classNames: {
            toast: 'font-sans',
          },
        }}
      />
    </>
  );
}
