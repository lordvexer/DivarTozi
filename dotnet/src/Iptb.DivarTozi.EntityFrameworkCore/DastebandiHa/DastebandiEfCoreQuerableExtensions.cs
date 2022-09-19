using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Iptb.DivarTozi.DastebandiHa;

public static class DastebandiEfCoreQueryableExtensions
{
    public static IQueryable<Dastebandi> IncludeDetails(this IQueryable<Dastebandi> queryable, bool include = true)
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
