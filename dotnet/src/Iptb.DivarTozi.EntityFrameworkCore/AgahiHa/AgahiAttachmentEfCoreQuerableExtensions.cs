using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Iptb.DivarTozi.AgahiHa;

public static class AgahiAttachmentEfCoreQueryableExtensions
{
    public static IQueryable<AgahiAttachment> IncludeDetails(this IQueryable<AgahiAttachment> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
