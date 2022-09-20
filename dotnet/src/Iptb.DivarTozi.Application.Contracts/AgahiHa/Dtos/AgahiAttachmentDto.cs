using System;
using Volo.Abp.Application.Dtos;

namespace Iptb.DivarTozi.AgahiHa.Dtos;

[Serializable]
public class AgahiAttachmentDto : FullAuditedEntityDto<Guid>
{
    public Guid AgahiId { get; set; }

    public string ContainerFilePath { get; set; }

    public string FileName { get; set; }

    public string FileExtension { get; set; }

    public string Description { get; set; }
}