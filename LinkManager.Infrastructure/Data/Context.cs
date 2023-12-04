using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinkManager.Domain;

namespace LinkManager.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 

        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentKind> AgentKinds { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }
        public DbSet<LinkEnd> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Agent>()
           .HasOne(l => l.AgentType)
           .WithMany(a => a.Agents)
           .IsRequired(false);
            */
            modelBuilder.Entity<Agent>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<LinkEnd>().Property(e => e.Id).ValueGeneratedNever();
            //.ValueGeneratedNever()

            modelBuilder.Entity<LinkEnd>().HasKey(k => k.Id);
            modelBuilder.Entity<AgentKind>().HasKey(k => k.Code);

            modelBuilder.Entity<LinkEnd>()
            .HasOne(i => i.In)
            .WithOne(o => o.Out)
            .HasForeignKey<LinkEnd>(i => i.LinkOutId).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
