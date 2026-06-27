import { useState, useEffect } from 'react';

/**
 * Hook to detect if the component has mounted on the client.
 * Prevents hydration mismatches for components that depend on
 * browser-only APIs (localStorage, window, etc.).
 *
 * @example
 * const mounted = useMounted();
 * if (!mounted) return null;
 */
export function useMounted(): boolean {
  const [mounted, setMounted] = useState(false);

  useEffect(() => {
    setMounted(true);
  }, []);

  return mounted;
}
