'use client';

import { motion } from 'framer-motion';
import { cn } from '@/lib/utils';
import { Separator } from '@/components/ui/separator';
import type { ReactNode } from 'react';

interface PageHeaderProps {
  title: string;
  description?: string;
  children?: ReactNode;
  className?: string;
}

/**
 * Consistent page header with title, description, and optional actions slot.
 * Used at the top of every major page for visual consistency.
 */
export function PageHeader({ title, description, children, className }: PageHeaderProps) {
  return (
    <motion.div
      initial={{ opacity: 0, y: -10 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.3 }}
      className={cn('mb-8', className)}
    >
      <div className="flex flex-col gap-4 sm:flex-row sm:items-center sm:justify-between">
        <div>
          <h1 className="text-2xl font-bold tracking-tight md:text-3xl">{title}</h1>
          {description && (
            <p className="mt-1.5 text-sm text-muted-foreground md:text-base">{description}</p>
          )}
        </div>

        {/* Action buttons slot */}
        {children && <div className="flex items-center gap-2">{children}</div>}
      </div>
      <Separator className="mt-6" />
    </motion.div>
  );
}
