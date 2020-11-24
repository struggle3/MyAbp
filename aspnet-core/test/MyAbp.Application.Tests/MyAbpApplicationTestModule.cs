using Volo.Abp.Modularity;

namespace MyAbp
{
    [DependsOn(
        typeof(MyAbpApplicationModule),
        typeof(MyAbpDomainTestModule)
        )]
    public class MyAbpApplicationTestModule : AbpModule
    {

    }
}