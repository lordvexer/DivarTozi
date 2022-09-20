using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Iptb.DivarTozi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

    public async Task<List<Dastebandi>> GetListAsync(
        string sorting, 
        string filter, 
        int skipCount, 
        int maxResultCount,
        bool isRoot,
        CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();
        var list = await dbContext.Dastebandis
            .WhereIf(isRoot, p => !p.ParentId.HasValue)
            .WhereIf(!isRoot, p => p.ParentId.HasValue)
            .PageBy(skipCount, maxResultCount)
            .OrderBy(String.IsNullOrEmpty(sorting) ? nameof(Dastebandi.Name) : sorting)
            .ToListAsync(cancellationToken);

        return list;
    }
    
    
    public async Task<List<Dastebandi>> GetListAsync(
        string filter, 
        bool isRoot,
        CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();
        var list = await dbContext.Dastebandis
            .Where(p => isRoot ? !p.ParentId.HasValue: p.ParentId.HasValue)
            .WhereIf(!String.IsNullOrWhiteSpace(filter), p => p.Name.Contains(filter))
            .ToListAsync(cancellationToken);

        return list;
    }
}