using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.AgahiHa
{
    public class Agahi : FullAuditedAggregateRoot<Guid>
    {
        public Guid RegionId { get; set; }
        public string Title { get; set; }
        public string  OfficeName { get; set; }
        public string Brief { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid DastebandiId { get; set; }

    protected Agahi()
    {
    }

    public Agahi(
        Guid id,
        Guid regionId,
        string title,
        string officeName,
        string brief,
        DateTime releaseDate,
        Guid dastebandiId
    ) : base(id)
    {
        RegionId = regionId;
        Title = title;
        OfficeName = officeName;
        Brief = brief;
        ReleaseDate = releaseDate;
        DastebandiId = dastebandiId;
    }
    }
}
