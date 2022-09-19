using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iptb.DivarTozi.Permissions;
using Iptb.DivarTozi.DastebandiHa.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.DastebandiHa;

public class DastebandiAppService : CrudAppService<Dastebandi, DastebandiDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDastebandiDto, CreateUpdateDastebandiDto>,
    IDastebandiAppService
{
    protected override string GetPolicyName { get; set; } = DivarToziPermissions.Dastebandi.Default;
    protected override string GetListPolicyName { get; set; } = DivarToziPermissions.Dastebandi.Default;
    protected override string CreatePolicyName { get; set; } = DivarToziPermissions.Dastebandi.Create;
    protected override string UpdatePolicyName { get; set; } = DivarToziPermissions.Dastebandi.Update;
    protected override string DeletePolicyName { get; set; } = DivarToziPermissions.Dastebandi.Delete;

    private readonly IDastebandiRepository _repository;

    public DastebandiAppService(IDastebandiRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<PagedResultDto<DastebandiDto>> DaryaftDastebandiHa(
        PagedAndSortedAndFilteredResultRequestDto input 
        )
    {
        var totalCount = await _repository.GetCountAsync();
        var dastebandiHa = await _repository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting
        );
        return new PagedResultDto<DastebandiDto>(
            totalCount, 
            ObjectMapper.Map<List<Dastebandi>, List<DastebandiDto>>(dastebandiHa)
        );
    }

    [HttpGet]
    public async Task<ListResultDto<DastebandiDto>> JostejooyeDastebandiHa(string filter)
    {
        var dastebandiHa = await _repository
            .GetListAsync(x => 
                filter.IsNullOrWhiteSpace() ? true :
                x.Name.Contains(filter));
        return new ListResultDto<DastebandiDto>(
            ObjectMapper.Map<List<Dastebandi>, List<DastebandiDto>>(dastebandiHa)
        );
    }
    
}
