using DMS.Services.Domain.Common;
using DMS.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Persistence
{
   public class DMSAppDbContext : DbContext
    {
        public DMSAppDbContext(DbContextOptions<DMSAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<SystemConfiguration> SystemConfiguration { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateTime = System.DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDateTime = System.DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
