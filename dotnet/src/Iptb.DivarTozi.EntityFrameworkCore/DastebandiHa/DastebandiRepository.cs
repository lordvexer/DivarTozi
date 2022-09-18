using System;
using System.Linq;
using System.Threading.Tasks;
using Iptb.DivarTozi.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Iptb.DivarTozi.DastebandiHa;

public class DastebandiRepository : EfCoreRepository<DivarToziDbContext, Dastebandi, Guid>, IDastebandiRepository
{
    public DastebandiRepository(IDbContextProvider<DivarToziDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Dastebandi>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}