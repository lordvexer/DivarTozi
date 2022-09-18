using System;
using Volo.Abp.Application.Dtos;

namespace Iptb.DivarTozi.MantageHa.Dtos;

[Serializable]
public class MantageDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
}