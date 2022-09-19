using Iptb.DivarTozi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Iptb.DivarTozi.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class DivarToziPageModel : AbpPageModel
{
    protected DivarToziPageModel()
    {
        LocalizationResourceType = typeof(DivarToziResource);
    }
}
