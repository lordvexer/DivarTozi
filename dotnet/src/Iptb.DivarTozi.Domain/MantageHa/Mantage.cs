using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.MantageHa;

public class Mantage : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
        
    /* This constructor is for deserialization / ORM purpose */
    private Mantage()
    {
    }

    public Mantage(Guid id, [NotNull] string name)
        : base(id)
    {
        SetName(name);
    }

    public void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: MantageConsts.MaxNameLength
        );
    }
}
