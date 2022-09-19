using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.MantageHa.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.MantageHa;

public interface IMantageAppService :
    ICrudAppService< 
        MantageDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateUpdateMantageDto,
        CreateUpdateMantageDto>
{
    Task<PagedResultDto<MantageDto>> DaryaftMantageHa(PagedAndSortedAndFilteredResultRequestDto input);
    Task<ListResultDto<MantageDto>> JostejooyeMantageHa(string filter);
}