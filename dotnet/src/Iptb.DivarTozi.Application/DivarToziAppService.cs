using System;
using System.Collections.Generic;
using System.Text;
using Iptb.DivarTozi.Localization;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi;

/* Inherit your application services from this class.
 */
public abstract class DivarToziAppService : ApplicationService
{
    protected DivarToziAppService()
    {
        LocalizationResource = typeof(DivarToziResource);
    }
}
