using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Iptb.DivarTozi.Web;

[Dependency(ReplaceServices = true)]
public class DivarToziBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DivarTozi";
}
