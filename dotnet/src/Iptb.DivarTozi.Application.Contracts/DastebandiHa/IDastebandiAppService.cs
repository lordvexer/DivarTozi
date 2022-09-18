using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.DastebandiHa.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.DastebandiHa;

public interface IDastebandiAppService :
    ICrudAppService< 
        DastebandiDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateUpdateDastebandiDto,
        CreateUpdateDastebandiDto>
{
    Task<PagedResultDto<DastebandiDto>> DaryaftDastebandiHa(PagedAndSortedAndFilteredResultRequestDto input);
    Task<ListResultDto<DastebandiDto>> JostejooyeDastebandiHa(string filter);
}