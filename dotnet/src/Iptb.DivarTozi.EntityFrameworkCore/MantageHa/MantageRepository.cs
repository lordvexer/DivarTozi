using System;
using System.Linq;
using System.Threading.Tasks;
using Iptb.DivarTozi.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Iptb.DivarTozi.MantageHa;

public class MantageRepository : EfCoreRepository<DivarToziDbContext, Mantage, Guid>, IMantageRepository
{
    public MantageRepository(IDbContextProvider<DivarToziDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Mantage>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}