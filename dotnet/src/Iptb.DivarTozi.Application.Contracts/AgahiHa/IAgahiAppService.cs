using System;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.AgahiHa;

public interface IAgahiAppService :
    ICrudAppService< 
        AgahiDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateUpdateAgahiDto,
        CreateUpdateAgahiDto>
{

}