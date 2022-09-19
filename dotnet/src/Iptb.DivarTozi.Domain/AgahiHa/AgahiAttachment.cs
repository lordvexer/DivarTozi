using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiAttachment : FullAuditedEntity<Guid>
{
    public Guid AgahiId { get; set; }
    public string ContainerFilePath { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public string Description { get; set; }

    protected AgahiAttachment()
    {
    }

    public AgahiAttachment(
        Guid id,
        Guid agahiId,
        string containerFilePath,
        string fileName,
        string fileExtension,
        string description
    ) : base(id)
    {
        AgahiId = agahiId;
        ContainerFilePath = containerFilePath;
        FileName = fileName;
        FileExtension = fileExtension;
        Description = description;
    }
}
