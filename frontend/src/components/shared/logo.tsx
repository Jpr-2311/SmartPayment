'use client';

import { cn } from '@/lib/utils';

interface LogoProps {
  collapsed?: boolean;
  className?: string;
}

/**
 * FinPilot AI brand logo component.
 * Displays icon + text, or just the icon when collapsed (sidebar).
 */
export function Logo({ collapsed = false, className }: LogoProps) {
  return (
    <div className={cn('flex items-center gap-2.5', className)}>
      {/* Logo Icon */}
      <div className="relative flex h-9 w-9 shrink-0 items-center justify-center rounded-lg gradient-primary shadow-md shadow-primary/25">
        <svg
          viewBox="0 0 24 24"
          fill="none"
          className="h-5 w-5 text-white"
          stroke="currentColor"
          strokeWidth="2"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <path d="M12 2L2 7l10 5 10-5-10-5z" />
          <path d="M2 17l10 5 10-5" />
          <path d="M2 12l10 5 10-5" />
        </svg>
        <div className="absolute inset-0 rounded-lg bg-white/10" />
      </div>

      {/* Logo Text */}
      {!collapsed && (
        <div className="flex flex-col">
          <span className="text-lg font-bold leading-tight tracking-tight">
            Fin<span className="gradient-text">Pilot</span>
          </span>
          <span className="text-[10px] font-medium uppercase tracking-widest text-muted-foreground">
            AI Platform
          </span>
        </div>
      )}
    </div>
  );
}
