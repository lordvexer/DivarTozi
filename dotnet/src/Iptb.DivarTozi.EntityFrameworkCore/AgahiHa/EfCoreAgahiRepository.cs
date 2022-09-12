using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Iptb.DivarTozi.DastebandiHa;
using Iptb.DivarTozi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Iptb.DivarTozi.AgahiHa
{
    public class EfCoreAgahiRepository : EfCoreRepository<DivarToziDbContext, Agahi, Guid>, IAgahiRepository
    {
        public EfCoreAgahiRepository(IDbContextProvider<DivarToziDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<AgahiBaJoziyat>> GetListAsync(
            string sorting, 
            int skipCount, 
            int maxResultCount, 
            CancellationToken cancellationToken = default
        )
        {
            var query = await ApplyFilterAsync();
            
            return await query
                .OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(Agahi.Title))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<AgahiBaJoziyat> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = await ApplyFilterAsync();
            
            return await query
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        private async Task<IQueryable<AgahiBaJoziyat>> ApplyFilterAsync()
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync())
                .Include(x => x.DastebandiHa)
                .Join(dbContext.Set<Dastebandi>(), agahi => agahi.RegionId, author => author.Id,
                    (agahi, region) => new {agahi, region})
                .Select(x => new AgahiBaJoziyat
                {
                    Id = x.agahi.Id,
                    OfficeName = x.agahi.OfficeName,
                    Brief = x.agahi.Brief,
                    Title = x.agahi.Title,
                    CreationTime = x.agahi.CreationTime,
                    RegionName = x.region.Name,
                    DastebandiNames = (from agahiDastebandiHa in x.agahi.DastebandiHa
                        join dastebandi in dbContext.Set<Dastebandi>() on agahiDastebandiHa.DastebandiId equals dastebandi.Id
                        select dastebandi.Name).ToArray()
                });
        }

        public override Task<IQueryable<Agahi>> WithDetailsAsync()
        {
            return base.WithDetailsAsync(x => x.DastebandiHa);
        }
    }
}