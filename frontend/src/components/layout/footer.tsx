import { APP_CONFIG } from '@/lib/constants';

/**
 * Application footer with branding and placeholder links.
 * Stays at the bottom of the main content area.
 */
export function Footer() {
  const currentYear = new Date().getFullYear();

  return (
    <footer className="border-t border-border/50 bg-background/50 backdrop-blur-sm">
      <div className="flex flex-col items-center justify-between gap-2 px-6 py-4 md:flex-row">
        <p className="text-xs text-muted-foreground">
          &copy; {currentYear} {APP_CONFIG.name}. All rights reserved.
        </p>
        <div className="flex items-center gap-4">
          <span className="text-xs text-muted-foreground/60 hover:text-muted-foreground transition-colors cursor-pointer">
            Privacy Policy
          </span>
          <span className="text-xs text-muted-foreground/60 hover:text-muted-foreground transition-colors cursor-pointer">
            Terms of Service
          </span>
          <span className="text-xs text-muted-foreground/50">
            v{APP_CONFIG.version}
          </span>
        </div>
      </div>
    </footer>
  );
}
