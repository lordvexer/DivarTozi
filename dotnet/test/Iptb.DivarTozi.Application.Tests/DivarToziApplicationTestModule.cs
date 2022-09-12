using Volo.Abp.Modularity;

namespace Iptb.DivarTozi;

[DependsOn(
    typeof(DivarToziApplicationModule),
    typeof(DivarToziDomainTestModule)
    )]
public class DivarToziApplicationTestModule : AbpModule
{

}
