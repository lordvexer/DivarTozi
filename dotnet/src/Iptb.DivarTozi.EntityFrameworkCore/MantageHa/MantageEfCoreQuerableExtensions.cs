using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Iptb.DivarTozi.MantageHa;

public static class MantageEfCoreQueryableExtensions
{
    public static IQueryable<Mantage> IncludeDetails(this IQueryable<Mantage> queryable, bool include = true)
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
