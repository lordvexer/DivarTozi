using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Iptb.DivarTozi.AgahiHa;

public static class AgahiEfCoreQueryableExtensions
{
    public static IQueryable<Agahi> IncludeDetails(this IQueryable<Agahi> queryable, bool include = true)
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
