'use client';

import { useTheme } from 'next-themes';
import { Sun, Moon, Bell, Search, Menu } from 'lucide-react';
import { motion, AnimatePresence } from 'framer-motion';
import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { Avatar, AvatarFallback } from '@/components/ui/avatar';
import { Badge } from '@/components/ui/badge';
import {
  Tooltip,
  TooltipContent,
  TooltipTrigger,
} from '@/components/ui/tooltip';
import { Logo } from '@/components/shared/logo';
import { useMounted } from '@/hooks';

interface NavbarProps {
  onMenuClick: () => void;
}

/**
 * Top navigation bar with:
 * - Mobile menu toggle
 * - Logo (visible on mobile)
 * - Search placeholder
 * - Notifications badge
 * - Theme toggle
 * - User avatar dropdown
 */
export function Navbar({ onMenuClick }: NavbarProps) {
  const { resolvedTheme, setTheme } = useTheme();
  const mounted = useMounted();

  const toggleTheme = () => {
    setTheme(resolvedTheme === 'dark' ? 'light' : 'dark');
  };

  return (
    <header className="sticky top-0 z-40 w-full border-b border-border/50 bg-background/80 backdrop-blur-xl supports-backdrop-filter:bg-background/60">
      <div className="flex h-16 items-center gap-4 px-4 md:px-6">
        {/* Mobile menu toggle */}
        <Button
          variant="ghost"
          size="icon"
          className="shrink-0 lg:hidden"
          onClick={onMenuClick}
          aria-label="Toggle menu"
          id="mobile-menu-toggle"
        >
          <Menu className="h-5 w-5" />
        </Button>

        {/* Logo — visible on mobile only */}
        <div className="lg:hidden">
          <Logo />
        </div>

        {/* Search bar placeholder */}
        <div className="hidden md:flex flex-1 items-center">
          <div className="relative max-w-md w-full">
            <Search className="absolute left-3 top-1/2 h-4 w-4 -translate-y-1/2 text-muted-foreground" />
            <input
              type="text"
              placeholder="Search transactions, bills, reports..."
              className="h-9 w-full rounded-lg border border-input bg-muted/50 pl-9 pr-4 text-sm outline-none transition-colors placeholder:text-muted-foreground/70 focus:border-primary/50 focus:bg-background focus:ring-1 focus:ring-primary/20"
              id="global-search"
              disabled
            />
          </div>
        </div>

        {/* Spacer */}
        <div className="flex-1 md:hidden" />

        {/* Right section */}
        <div className="flex items-center gap-1">
          {/* Notifications */}
          <Tooltip>
            <TooltipTrigger
              className="relative inline-flex h-8 w-8 items-center justify-center rounded-lg hover:bg-muted transition-colors"
              aria-label="Notifications"
              id="notifications-button"
            >
              <Bell className="h-4.5 w-4.5" />
              <Badge
                variant="destructive"
                className="absolute -right-0.5 -top-0.5 h-4.5 min-w-4.5 rounded-full px-1 text-[10px] font-bold"
              >
                3
              </Badge>
            </TooltipTrigger>
            <TooltipContent>Notifications</TooltipContent>
          </Tooltip>

          {/* Theme toggle */}
          <Tooltip>
            <TooltipTrigger
              className="inline-flex h-8 w-8 items-center justify-center rounded-lg hover:bg-muted transition-colors"
              onClick={toggleTheme}
              aria-label="Toggle theme"
              id="theme-toggle"
            >
              <AnimatePresence mode="wait" initial={false}>
                {mounted && resolvedTheme === 'dark' ? (
                  <motion.div
                    key="sun"
                    initial={{ rotate: -90, scale: 0 }}
                    animate={{ rotate: 0, scale: 1 }}
                    exit={{ rotate: 90, scale: 0 }}
                    transition={{ duration: 0.2 }}
                  >
                    <Sun className="h-4.5 w-4.5" />
                  </motion.div>
                ) : (
                  <motion.div
                    key="moon"
                    initial={{ rotate: 90, scale: 0 }}
                    animate={{ rotate: 0, scale: 1 }}
                    exit={{ rotate: -90, scale: 0 }}
                    transition={{ duration: 0.2 }}
                  >
                    <Moon className="h-4.5 w-4.5" />
                  </motion.div>
                )}
              </AnimatePresence>
            </TooltipTrigger>
            <TooltipContent>
              {mounted && resolvedTheme === 'dark' ? 'Light mode' : 'Dark mode'}
            </TooltipContent>
          </Tooltip>

          {/* User menu */}
          <DropdownMenu>
            <DropdownMenuTrigger
              className="relative h-9 w-9 rounded-full flex items-center justify-center hover:bg-muted transition-colors"
              id="user-menu"
            >
              <Avatar className="h-8 w-8">
                <AvatarFallback className="gradient-primary text-xs font-semibold text-white">
                  FP
                </AvatarFallback>
              </Avatar>
            </DropdownMenuTrigger>
            <DropdownMenuContent className="w-56" align="end">
              <div className="flex items-center gap-2 px-2 py-1.5">
                <Avatar className="h-8 w-8">
                  <AvatarFallback className="gradient-primary text-xs font-semibold text-white">
                    FP
                  </AvatarFallback>
                </Avatar>
                <div className="flex flex-col space-y-0.5">
                  <p className="text-sm font-medium">FinPilot User</p>
                  <p className="text-xs text-muted-foreground">user@finpilot.ai</p>
                </div>
              </div>
              <DropdownMenuSeparator />
              <DropdownMenuItem id="menu-profile">Profile</DropdownMenuItem>
              <DropdownMenuItem id="menu-settings">Settings</DropdownMenuItem>
              <DropdownMenuItem id="menu-billing">Billing</DropdownMenuItem>
              <DropdownMenuSeparator />
              <DropdownMenuItem id="menu-logout" variant="destructive">
                Log out
              </DropdownMenuItem>
            </DropdownMenuContent>
          </DropdownMenu>
        </div>
      </div>
    </header>
  );
}
