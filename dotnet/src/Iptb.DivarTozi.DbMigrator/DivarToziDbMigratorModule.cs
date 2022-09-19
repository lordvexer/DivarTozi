using Iptb.DivarTozi.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Iptb.DivarTozi.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DivarToziEntityFrameworkCoreModule),
    typeof(DivarToziApplicationContractsModule)
    )]
public class DivarToziDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
