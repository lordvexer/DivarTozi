using Volo.Abp.Application.Dtos;

namespace Iptb.DivarTozi;

public class PagedAndSortedAndFilteredResultRequestDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}