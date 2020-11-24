using System.Threading.Tasks;

namespace MyAbp.Data
{
    public interface IMyAbpDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
