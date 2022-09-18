using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.DastebandiHa
{
    public class Dastebandi : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }

    protected Dastebandi()
    {
    }

    public Dastebandi(
        Guid id,
        string name
    ) : base(id)
    {
        Name = name;
    }
    }
}
