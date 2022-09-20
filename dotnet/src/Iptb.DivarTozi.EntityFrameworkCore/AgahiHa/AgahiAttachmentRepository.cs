using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Iptb.DivarTozi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiAttachmentRepository : EfCoreRepository<DivarToziDbContext, AgahiAttachment, Guid>, IAgahiAttachmentRepository
{
    public AgahiAttachmentRepository(IDbContextProvider<DivarToziDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<AgahiAttachment>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    public async Task<List<ViewAttachment>> GetListAsync(string sorting, string filter, Guid agahiId, int skipCount, int maxResultCount,
        CancellationToken token = default)
    {
        var dbSet = await GetDbSetAsync();
        var dbContext = await GetDbContextAsync();
        return await (from a in dbSet
                    .Where(p => p.AgahiId == agahiId)
                    .WhereIf(!String.IsNullOrEmpty(filter), 
                        p => p.Description.Contains(filter)
                             || p.FileName.Contains(filter)
                    )
                    .OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(AgahiAttachment.CreationTime))
                    .PageBy(skipCount, maxResultCount)
                from u in dbContext.Users.Where(u1 => u1.Id == a.CreatorId).DefaultIfEmpty()
                select  new ViewAttachment
                {
                    Description = a.Description,
                    Id = a.Id,
                    CreatorName = 
                        String.Concat(u.Name, " ", u.Surname).Length > 1 ? 
                            String.Concat(u.Name, " ", u.Surname) : u.UserName,
                    FileExtension = a.FileExtension,
                    FileName = a.FileName,
                    IsDeleted = a.IsDeleted,
                    ContainerFilePath = a.ContainerFilePath,
                    AgahiId = a.AgahiId,
                    CreationTime = a.CreationTime,
                })
            .ToListAsync(token);
    }
}