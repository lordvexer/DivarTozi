using System;

namespace Iptb.DivarTozi.AgahiHa.Dtos;

[Serializable]
public class CreateUpdateAgahiAttachmentDto
{
    public Guid AgahiId { get; set; }

    public string ContainerFilePath { get; set; }

    public string FileName { get; set; }

    public string FileExtension { get; set; }

    public string Description { get; set; }
    public byte[] Content { get; set; }
}