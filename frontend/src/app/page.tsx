'use client';

import { motion } from 'framer-motion';
import {
  TrendingUp,
  Wallet,
  ArrowLeftRight,
  Bot,
  ArrowRight,
  Shield,
  Zap,
  BarChart3,
} from 'lucide-react';
import { Button } from '@/components/ui/button';
import { MainLayout } from '@/components/layout';
import { PageHeader } from '@/components/shared';
import { SkeletonCard } from '@/components/shared';
import Link from 'next/link';

const features = [
  {
    icon: Wallet,
    title: 'Smart Wallet',
    description: 'Manage multiple wallets with real-time balance tracking and instant transfers.',
    color: 'from-blue-500/20 to-indigo-500/20',
    iconColor: 'text-blue-500',
  },
  {
    icon: ArrowLeftRight,
    title: 'Transaction Tracking',
    description: 'Automatically categorize and track every transaction across all your accounts.',
    color: 'from-emerald-500/20 to-teal-500/20',
    iconColor: 'text-emerald-500',
  },
  {
    icon: BarChart3,
    title: 'Analytics Dashboard',
    description: 'Beautiful visualizations of your spending patterns and financial health.',
    color: 'from-violet-500/20 to-purple-500/20',
    iconColor: 'text-violet-500',
  },
  {
    icon: Bot,
    title: 'AI Assistant',
    description: 'Get personalized financial advice powered by advanced AI models.',
    color: 'from-amber-500/20 to-orange-500/20',
    iconColor: 'text-amber-500',
  },
  {
    icon: Shield,
    title: 'Bank-Grade Security',
    description: 'Enterprise-level encryption and security for all your financial data.',
    color: 'from-rose-500/20 to-pink-500/20',
    iconColor: 'text-rose-500',
  },
  {
    icon: Zap,
    title: 'Instant Payments',
    description: 'Pay bills, recharge phones, and transfer money instantly.',
    color: 'from-cyan-500/20 to-sky-500/20',
    iconColor: 'text-cyan-500',
  },
];

const containerVariants = {
  hidden: { opacity: 0 },
  visible: {
    opacity: 1,
    transition: {
      staggerChildren: 0.08,
    },
  },
};

const itemVariants = {
  hidden: { opacity: 0, y: 20 },
  visible: {
    opacity: 1,
    y: 0,
    transition: { duration: 0.4, ease: 'easeOut' as const },
  },
};

/**
 * Home page — dashboard overview with feature cards.
 * This is a placeholder that demonstrates the layout system.
 * Real dashboard content will be built in Phase 4.
 */
export default function HomePage() {
  return (
    <MainLayout>
      {/* Welcome header */}
      <PageHeader
        title="Welcome to FinPilot AI"
        description="Your AI-powered personal finance command center. Track expenses, manage wallets, and get intelligent financial insights."
      >
        <Button className="gradient-primary text-white shadow-lg shadow-primary/25" id="get-started-btn">
          Get Started
          <ArrowRight className="ml-2 h-4 w-4" />
        </Button>
      </PageHeader>

      {/* Quick stats placeholder */}
      <motion.div
        variants={containerVariants}
        initial="hidden"
        animate="visible"
        className="mb-8 grid gap-4 sm:grid-cols-2 lg:grid-cols-4"
      >
        {[
          { label: 'Total Balance', value: '—', icon: Wallet, trend: '+0%' },
          { label: 'Monthly Spending', value: '—', icon: TrendingUp, trend: '0%' },
          { label: 'Transactions', value: '—', icon: ArrowLeftRight, trend: '0' },
          { label: 'Savings Goal', value: '—', icon: BarChart3, trend: '0%' },
        ].map((stat, i) => (
          <motion.div
            key={stat.label}
            variants={itemVariants}
            className="group relative overflow-hidden rounded-xl border border-border/50 bg-card p-5 transition-all duration-300 hover:border-primary/20 hover:shadow-lg hover:shadow-primary/5"
          >
            <div className="flex items-center justify-between">
              <div>
                <p className="text-xs font-medium text-muted-foreground uppercase tracking-wider">
                  {stat.label}
                </p>
                <p className="mt-2 text-2xl font-bold">{stat.value}</p>
              </div>
              <div className="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                <stat.icon className="h-5 w-5 text-primary" />
              </div>
            </div>
            <p className="mt-2 text-xs text-muted-foreground">{stat.trend} from last month</p>

            {/* Hover gradient effect */}
            <div className="absolute inset-0 -z-10 bg-gradient-to-br from-primary/5 via-transparent to-transparent opacity-0 transition-opacity group-hover:opacity-100" />
          </motion.div>
        ))}
      </motion.div>

      {/* Feature cards */}
      <div className="mb-6">
        <h2 className="text-lg font-semibold mb-4">Platform Features</h2>
        <motion.div
          variants={containerVariants}
          initial="hidden"
          animate="visible"
          className="grid gap-4 sm:grid-cols-2 lg:grid-cols-3"
        >
          {features.map((feature) => (
            <motion.div
              key={feature.title}
              variants={itemVariants}
              whileHover={{ y: -4, transition: { duration: 0.2 } }}
              className="group cursor-pointer rounded-xl border border-border/50 bg-card p-6 transition-all duration-300 hover:border-primary/20 hover:shadow-xl hover:shadow-primary/5"
            >
              <div
                className={`mb-4 inline-flex h-11 w-11 items-center justify-center rounded-xl bg-gradient-to-br ${feature.color}`}
              >
                <feature.icon className={`h-5 w-5 ${feature.iconColor}`} />
              </div>
              <h3 className="mb-1.5 font-semibold">{feature.title}</h3>
              <p className="text-sm text-muted-foreground leading-relaxed">
                {feature.description}
              </p>
            </motion.div>
          ))}
        </motion.div>
      </div>

      {/* Loading state demo */}
      <div className="mb-6">
        <h2 className="text-lg font-semibold mb-4">Recent Activity</h2>
        <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-3">
          <SkeletonCard />
          <SkeletonCard lines={2} />
          <SkeletonCard lines={4} />
        </div>
        <p className="mt-3 text-center text-xs text-muted-foreground">
          Activity data will appear here once you start using the platform.
        </p>
      </div>
    </MainLayout>
  );
}
