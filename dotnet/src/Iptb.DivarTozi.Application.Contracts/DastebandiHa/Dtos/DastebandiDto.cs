using System;
using Volo.Abp.Application.Dtos;

namespace Iptb.DivarTozi.DastebandiHa.Dtos;

[Serializable]
public class DastebandiDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
}