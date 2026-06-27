import { cn } from '@/lib/utils';
import { Skeleton } from '@/components/ui/skeleton';

interface SkeletonCardProps {
  className?: string;
  lines?: number;
}

/**
 * Skeleton loading card component.
 * Mimics a typical data card layout during loading states.
 */
export function SkeletonCard({ className, lines = 3 }: SkeletonCardProps) {
  return (
    <div
      className={cn(
        'rounded-xl border border-border/50 bg-card p-6 space-y-4',
        className
      )}
    >
      {/* Header skeleton */}
      <div className="flex items-center gap-3">
        <Skeleton className="h-10 w-10 rounded-lg" />
        <div className="flex-1 space-y-2">
          <Skeleton className="h-4 w-1/3" />
          <Skeleton className="h-3 w-1/2" />
        </div>
      </div>

      {/* Content lines skeleton */}
      <div className="space-y-2.5">
        {Array.from({ length: lines }).map((_, i) => (
          <Skeleton
            key={i}
            className="h-3"
            style={{ width: `${85 - i * 15}%` }}
          />
        ))}
      </div>

      {/* Footer skeleton */}
      <div className="flex items-center justify-between pt-2">
        <Skeleton className="h-8 w-20 rounded-md" />
        <Skeleton className="h-3 w-16" />
      </div>
    </div>
  );
}
