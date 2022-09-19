using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Iptb.DivarTozi.DastebandiHa;

public interface IDastebandiRepository : IRepository<Dastebandi, Guid>
{
    Task<List<Dastebandi>> GetListAsync(
        string sorting,
        string filter,
        int skipCount,
        int maxResultCount,
        bool isRoot,
        CancellationToken cancellationToken = default
    );
    
    Task<List<Dastebandi>> GetListAsync(
        string filter,
        bool isRoot,
        CancellationToken cancellationToken = default
    );
}
