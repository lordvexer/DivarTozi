using System;
using Volo.Abp.Application.Dtos;

namespace Iptb.DivarTozi.AgahiHa.Dtos;

[Serializable]
public class AgahiDto : FullAuditedEntityDto<Guid>
{
    public Guid RegionId { get; set; }

    public string Title { get; set; }

    public string OfficeName { get; set; }

    public string Brief { get; set; }

    public DateTime ReleaseDate { get; set; }

    public Guid DastebandiId { get; set; }
}