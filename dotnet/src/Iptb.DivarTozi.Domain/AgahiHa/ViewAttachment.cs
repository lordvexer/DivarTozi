using System;

namespace Iptb.DivarTozi.AgahiHa;

public class ViewAttachment
{
    public Guid Id { get; set; }
    public Guid AgahiId { get; set; }
    public string ContainerFilePath { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public string Description { get; set; }
    public string CreatorName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationTime { get; set; }
}
