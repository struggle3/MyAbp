using MyAbp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyAbp
{
    [DependsOn(
        typeof(MyAbpEntityFrameworkCoreTestModule)
        )]
    public class MyAbpDomainTestModule : AbpModule
    {

    }
}