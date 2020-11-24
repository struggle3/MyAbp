using MyAbp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MyAbp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MyAbpEntityFrameworkCoreDbMigrationsModule),
        typeof(MyAbpApplicationContractsModule)
        )]
    public class MyAbpDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
