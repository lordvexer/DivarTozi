using System;

namespace Iptb.DivarTozi.DastebandiHa.Dtos;

[Serializable]
public class CreateUpdateDastebandiDto
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}