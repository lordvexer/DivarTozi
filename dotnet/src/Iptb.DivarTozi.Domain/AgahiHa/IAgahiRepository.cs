using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using System.Threading;

namespace Iptb.DivarTozi.AgahiHa
{
    public interface IAgahiRepository : IRepository<Agahi, Guid>
    {
        Task<List<AgahiBaJoziyat>> GetListAsync(
            string sorting,
            int skipCount,
            int maxResultCount,
            CancellationToken cancellationToken = default
        );

        Task<AgahiBaJoziyat> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}