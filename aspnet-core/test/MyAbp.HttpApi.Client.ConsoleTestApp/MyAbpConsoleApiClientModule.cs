using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MyAbp.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MyAbpHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MyAbpConsoleApiClientModule : AbpModule
    {
        
    }
}
