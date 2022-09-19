using System;

namespace Iptb.DivarTozi.AgahiHa.Dtos;

public class GetAgahiAttachmentDto : PagedAndSortedAndFilteredResultRequestDto
{
    public Guid Id { get; set; }
}