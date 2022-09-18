using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<WatchList> WatchList { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SentEmailsForUsers> SentEmailsForUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateDate = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeleteDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(token);
        }
    }
}
