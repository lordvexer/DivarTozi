using System;
using System.Linq;
using System.Threading.Tasks;
using Iptb.DivarTozi.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiRepository : EfCoreRepository<DivarToziDbContext, Agahi, Guid>, IAgahiRepository
{
    public AgahiRepository(IDbContextProvider<DivarToziDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Agahi>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}