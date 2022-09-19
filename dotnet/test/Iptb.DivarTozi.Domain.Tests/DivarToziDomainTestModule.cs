using Iptb.DivarTozi.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Iptb.DivarTozi;

[DependsOn(
    typeof(DivarToziEntityFrameworkCoreTestModule)
    )]
public class DivarToziDomainTestModule : AbpModule
{

}
