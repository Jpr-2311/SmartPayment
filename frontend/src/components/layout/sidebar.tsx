'use client';

import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { motion } from 'framer-motion';
import {
  LayoutDashboard,
  ArrowLeftRight,
  Wallet,
  Receipt,
  BarChart3,
  Bot,
  FileText,
  Settings,
  ChevronLeft,
  ChevronRight,
  type LucideIcon,
} from 'lucide-react';
import { cn } from '@/lib/utils';
import { Button } from '@/components/ui/button';
import { ScrollArea } from '@/components/ui/scroll-area';
import { Separator } from '@/components/ui/separator';
import {
  Tooltip,
  TooltipContent,
  TooltipTrigger,
} from '@/components/ui/tooltip';
import { Logo } from '@/components/shared/logo';
import { NAV_ITEMS } from '@/lib/constants';

/** Map icon name strings to Lucide icon components */
const iconMap: Record<string, LucideIcon> = {
  LayoutDashboard,
  ArrowLeftRight,
  Wallet,
  Receipt,
  BarChart3,
  Bot,
  FileText,
  Settings,
};

interface SidebarProps {
  collapsed: boolean;
  onToggle: () => void;
}

/**
 * Collapsible sidebar navigation.
 * - Shows icon + label when expanded
 * - Shows icon-only with tooltips when collapsed
 * - Animated width transitions via Framer Motion
 * - Active state highlighting based on current path
 */
export function Sidebar({ collapsed, onToggle }: SidebarProps) {
  const pathname = usePathname();

  return (
    <motion.aside
      initial={false}
      animate={{ width: collapsed ? 72 : 256 }}
      transition={{ duration: 0.2, ease: 'easeInOut' }}
      className="hidden lg:flex flex-col border-r border-border/50 bg-sidebar"
    >
      {/* Logo + Collapse toggle */}
      <div className="flex h-16 items-center justify-between px-4 border-b border-border/50">
        <Logo collapsed={collapsed} />
        <Button
          variant="ghost"
          size="icon"
          className="h-7 w-7 shrink-0"
          onClick={onToggle}
          aria-label={collapsed ? 'Expand sidebar' : 'Collapse sidebar'}
          id="sidebar-toggle"
        >
          {collapsed ? (
            <ChevronRight className="h-4 w-4" />
          ) : (
            <ChevronLeft className="h-4 w-4" />
          )}
        </Button>
      </div>

      {/* Navigation links */}
      <ScrollArea className="flex-1 py-4">
        <nav className="flex flex-col gap-1 px-3">
          {NAV_ITEMS.map((item) => {
            const Icon = iconMap[item.icon] || LayoutDashboard;
            const isActive = pathname === item.href || pathname?.startsWith(`${item.href}/`);

            const linkContent = (
              <Link
                key={item.href}
                href={item.href}
                className={cn(
                  'group relative flex items-center gap-3 rounded-lg px-3 py-2.5 text-sm font-medium transition-all duration-200',
                  'hover:bg-sidebar-accent hover:text-sidebar-accent-foreground',
                  isActive
                    ? 'bg-primary/10 text-primary'
                    : 'text-sidebar-foreground/70',
                  collapsed && 'justify-center px-0'
                )}
                id={`nav-${item.href.replace('/', '')}`}
              >
                {/* Active indicator */}
                {isActive && (
                  <motion.div
                    layoutId="sidebar-active"
                    className="absolute left-0 top-1/2 h-6 w-1 -translate-y-1/2 rounded-r-full bg-primary"
                    transition={{ type: 'spring', stiffness: 300, damping: 30 }}
                  />
                )}

                <Icon
                  className={cn(
                    'h-4.5 w-4.5 shrink-0 transition-colors',
                    isActive ? 'text-primary' : 'text-muted-foreground group-hover:text-foreground'
                  )}
                />

                {!collapsed && (
                  <motion.span
                    initial={{ opacity: 0 }}
                    animate={{ opacity: 1 }}
                    exit={{ opacity: 0 }}
                    transition={{ duration: 0.15 }}
                    className="truncate"
                  >
                    {item.title}
                  </motion.span>
                )}
              </Link>
            );

            // Wrap in tooltip when collapsed
            if (collapsed) {
              return (
                <Tooltip key={item.href}>
                  <TooltipTrigger render={<div />}>
                    {linkContent}
                  </TooltipTrigger>
                  <TooltipContent side="right" className="font-medium">
                    {item.title}
                  </TooltipContent>
                </Tooltip>
              );
            }

            return <div key={item.href}>{linkContent}</div>;
          })}
        </nav>
      </ScrollArea>

      {/* Footer section */}
      <div className="border-t border-border/50 p-3">
        <Separator className="mb-3" />
        <div
          className={cn(
            'flex items-center gap-3 rounded-lg px-3 py-2 text-xs text-muted-foreground',
            collapsed && 'justify-center px-0'
          )}
        >
          <div className="h-2 w-2 rounded-full bg-emerald-500 animate-pulse" />
          {!collapsed && <span>System Online</span>}
        </div>
      </div>
    </motion.aside>
  );
}
