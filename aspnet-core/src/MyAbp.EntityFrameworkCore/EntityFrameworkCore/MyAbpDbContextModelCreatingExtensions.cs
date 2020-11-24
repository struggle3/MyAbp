using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace MyAbp.EntityFrameworkCore
{
    public static class MyAbpDbContextModelCreatingExtensions
    {
        public static void ConfigureMyAbp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MyAbpConsts.DbTablePrefix + "YourEntities", MyAbpConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}