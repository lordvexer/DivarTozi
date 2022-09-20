using System;
using System.Threading.Tasks;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.AgahiHa;

public interface IAgahiAttachmentAppService :
    ICrudAppService< 
        AgahiAttachmentDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateUpdateAgahiAttachmentDto,
        CreateUpdateAgahiAttachmentDto>
{
    Task<PagedResultDto<AgahiAttachmentDto>> GetListByIdAsync(
        GetAgahiAttachmentDto input);
    Task SaveBlobAsync(CreateUpdateAgahiAttachmentDto input);
    Task<AttachmentDto> GetBlobAsync(GetAttachmentRequestDto input);

}