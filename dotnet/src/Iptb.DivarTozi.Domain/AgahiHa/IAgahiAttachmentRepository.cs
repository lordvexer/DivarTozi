using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Iptb.DivarTozi.AgahiHa;

public interface IAgahiAttachmentRepository : IRepository<AgahiAttachment, Guid>
{
    Task<List<ViewAttachment>> GetListAsync(
        string sorting,
        string filter,
        Guid agahiId,
        int skipCount,
        int maxResultCount,
        CancellationToken token = default
    );
}
