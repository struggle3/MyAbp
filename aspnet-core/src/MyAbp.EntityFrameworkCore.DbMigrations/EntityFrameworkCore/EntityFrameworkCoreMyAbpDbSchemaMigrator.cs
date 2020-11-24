using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAbp.Data;
using Volo.Abp.DependencyInjection;

namespace MyAbp.EntityFrameworkCore
{
    public class EntityFrameworkCoreMyAbpDbSchemaMigrator
        : IMyAbpDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMyAbpDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MyAbpMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MyAbpMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}