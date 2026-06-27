'use client';

import { useState, useCallback, type ReactNode } from 'react';
import { TooltipProvider } from '@/components/ui/tooltip';
import { Navbar } from './navbar';
import { Sidebar } from './sidebar';
import { MobileNav } from './mobile-nav';
import { Footer } from './footer';

interface MainLayoutProps {
  children: ReactNode;
}

/**
 * Main application layout that orchestrates:
 * - Sidebar (desktop, collapsible)
 * - MobileNav (mobile drawer)
 * - Navbar (top bar)
 * - Content area
 * - Footer
 *
 * Manages sidebar collapse and mobile menu state.
 */
export function MainLayout({ children }: MainLayoutProps) {
  const [sidebarCollapsed, setSidebarCollapsed] = useState(false);
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  const toggleSidebar = useCallback(() => {
    setSidebarCollapsed((prev) => !prev);
  }, []);

  const toggleMobileMenu = useCallback(() => {
    setMobileMenuOpen((prev) => !prev);
  }, []);

  const closeMobileMenu = useCallback(() => {
    setMobileMenuOpen(false);
  }, []);

  return (
    <TooltipProvider delay={300}>
      <div className="flex h-screen overflow-hidden bg-background">
        {/* Desktop Sidebar */}
        <Sidebar collapsed={sidebarCollapsed} onToggle={toggleSidebar} />

        {/* Mobile Navigation Drawer */}
        <MobileNav open={mobileMenuOpen} onClose={closeMobileMenu} />

        {/* Main content area */}
        <div className="flex flex-1 flex-col overflow-hidden">
          {/* Top Navbar */}
          <Navbar onMenuClick={toggleMobileMenu} />

          {/* Page content */}
          <main className="flex-1 overflow-y-auto">
            <div className="container mx-auto px-4 py-6 md:px-6 lg:px-8">
              {children}
            </div>
          </main>

          {/* Footer */}
          <Footer />
        </div>
      </div>
    </TooltipProvider>
  );
}
