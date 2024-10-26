using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace VezaVI.Light
{
    public class VezaDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>, IDBContextUserSaveChanges, IDBContextSeedable
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {

        public VezaDbContext(DbContextOptions options) : 
            base(options)
        {
        }
        
        protected VezaDbContext()
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public async Task<int> SaveChangesAsync(Guid? userID, CancellationToken cancellationToken = default)
        {
            var changes = ChangeTracker.Entries().ToList();
            for (int i = changes.Count() - 1; i >= 0; i--)
            {
                foreach (var prop in changes[i].Properties)
                {
                    if (CastToString(prop.CurrentValue) != CastToString(prop.OriginalValue))
                    {
                        AuditLog log = new AuditLog()
                        {
                            Column = prop.Metadata.Name,
                            NewValue = CastToString(prop.CurrentValue),
                            OldValue = CastToString(prop.OriginalValue),
                            TableName = changes[i].Metadata.Name,
                            ChangeType = changes[i].State == EntityState.Added ? ChangeType.Insert : (changes[i].State == EntityState.Deleted ? ChangeType.Delete : ChangeType.Update),
                            UserID = userID
                        };
                        AuditLogs.Add(log);
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        private string CastToString(object val)
        {
            if (val == null)
                return string.Empty;
            return val.ToString();
        }

        public virtual void Seed()
        {

        }

    }
}
