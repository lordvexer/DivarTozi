using System;

namespace Iptb.DivarTozi.AgahiHa.Dtos;

[Serializable]
public class CreateUpdateAgahiDto
{
    public Guid RegionId { get; set; }

    public string Title { get; set; }

    public string OfficeName { get; set; }

    public string Brief { get; set; }

    public DateTime ReleaseDate { get; set; }

    public Guid DastebandiId { get; set; }
}