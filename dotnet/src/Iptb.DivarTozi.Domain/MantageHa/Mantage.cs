using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.MantageHa;

public class Mantage : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }

    protected Mantage()
    {
    }

    public Mantage(
        Guid id,
        string name
    ) : base(id)
    {
        Name = name;
    }
}
