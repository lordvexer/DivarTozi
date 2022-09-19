using Iptb.DivarTozi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Iptb.DivarTozi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DivarToziController : AbpControllerBase
{
    protected DivarToziController()
    {
        LocalizationResource = typeof(DivarToziResource);
    }
}
