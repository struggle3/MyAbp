using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MyAbp.Data
{
    /* This is used if database provider does't define
     * IMyAbpDbSchemaMigrator implementation.
     */
    public class NullMyAbpDbSchemaMigrator : IMyAbpDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}