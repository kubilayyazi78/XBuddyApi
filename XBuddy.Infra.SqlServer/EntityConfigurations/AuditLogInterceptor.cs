using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;
using System.Text.Json;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{
    public class AuditLogInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync
            (DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var entries = eventData.Context.ChangeTracker.Entries().ToList();
            var auditLogs = eventData.Context.ChangeTracker.Entries()
                .Where(x => x.Entity is not AuditLogEntity)
                .Where(y => y.State == Microsoft.EntityFrameworkCore.EntityState.Added
                || y.State == Microsoft.EntityFrameworkCore.EntityState.Modified
                || y.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);


            var auditLogEntities = new List<AuditLogEntity>();
            foreach (var entry in auditLogs)
            {
                var log = new AuditLogEntity
                {
                    TableName = entry.Metadata.GetTableName(),
                    Operation = entry.State.ToString(),
                    CreatedDate = DateTime.UtcNow,
                };
                if (entry.State == EntityState.Modified)
                {
                    log.OldValue = JsonSerializer.Serialize(entry.OriginalValues.Properties.ToDictionary(p => p.Name, p => entry.OriginalValues[p]));
                    log.NewValue = JsonSerializer.Serialize(entry.CurrentValues.Properties.ToDictionary(p => p.Name, p => entry.CurrentValues[p]));
                }
                else if (entry.State == EntityState.Added)
                {
                    log.NewValue = JsonSerializer.Serialize(entry.CurrentValues.Properties.ToDictionary(p => p.Name, p => entry.CurrentValues[p]));
                }
                else if (entry.State == EntityState.Deleted)
                {
                    log.OldValue = JsonSerializer.Serialize(entry.OriginalValues.Properties.ToDictionary(p => p.Name, p => entry.OriginalValues[p]));
                }
                auditLogEntities.Add(log);
            }
            eventData.Context.Set<AuditLogEntity>().AddRange(auditLogEntities);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
