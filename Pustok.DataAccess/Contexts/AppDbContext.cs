using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities;
using Pustok.Core.Entities.Common;
using Pustok.DataAccess.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Contexts
{
    internal class AppDbContext(BaseAuditableInterceptor _interceptor,DbContextOptions options) : DbContext(options)
    {
        
     /*   public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ChangeTracker.Entries<BaseAuditableEntity>().ToList().ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                       entry.Entity.CreatedAt = DateTime.UtcNow;
                       entry.Entity.CreatedBy = "Sirxan"; //TODO: set current user
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = "Sirxan"; 
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        entry.Entity.DeletedBy = "Sirxan";
                        entry.State= EntityState.Modified;
                        break;
                }
            });
            return base.SaveChangesAsync( cancellationToken);
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
