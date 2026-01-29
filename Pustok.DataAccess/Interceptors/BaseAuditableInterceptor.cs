using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pustok.Core.Entities.Common;
using Pustok.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Interceptors
{
    internal class BaseAuditableInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditColumns(eventData);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditColumns(eventData);
            return base.SavingChanges(eventData, result);
        }

        private static void UpdateAuditColumns(DbContextEventData eventData)
        {
            if (eventData.Context is AppDbContext appDbContext)
            {
                var entries = appDbContext.ChangeTracker.Entries<BaseAuditableEntity>().ToList();

                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            entry.Entity.CreatedBy = "Fatima";
                            break;
                        case EntityState.Modified:
                            entry.Entity.UpdatedAt = DateTime.UtcNow;
                            entry.Entity.UpdatedBy = "Fatima";
                            break;
                        case EntityState.Deleted:
                            entry.Entity.DeletedAt = DateTime.UtcNow;
                            entry.Entity.DeletedBy = "Fatima";
                            entry.Entity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }
    }
}
            
        

