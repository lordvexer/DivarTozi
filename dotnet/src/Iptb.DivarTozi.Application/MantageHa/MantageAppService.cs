using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Iptb.DivarTozi.Permissions;
using Iptb.DivarTozi.MantageHa.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.MantageHa;

public class MantageAppService : CrudAppService<Mantage, MantageDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateMantageDto, CreateUpdateMantageDto>,
    IMantageAppService
{
    protected override string GetPolicyName { get; set; } = DivarToziPermissions.Mantage.Default;
    protected override string GetListPolicyName { get; set; } = DivarToziPermissions.Mantage.Default;
    protected override string CreatePolicyName { get; set; } = DivarToziPermissions.Mantage.Create;
    protected override string UpdatePolicyName { get; set; } = DivarToziPermissions.Mantage.Update;
    protected override string DeletePolicyName { get; set; } = DivarToziPermissions.Mantage.Delete;

    private readonly IMantageRepository _repository;

    public MantageAppService(IMantageRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<PagedResultDto<MantageDto>> DaryaftMantageHa(PagedAndSortedAndFilteredResultRequestDto input)
    {
        var totalCount = await _repository.GetCountAsync();
        var mantageHa = await _repository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting
        );
        return new PagedResultDto<MantageDto>(
            totalCount, 
            ObjectMapper.Map<List<Mantage>, List<MantageDto>>(mantageHa)
        );
    }

    [HttpGet]
    public async Task<ListResultDto<MantageDto>> JostejooyeMantageHa(string filter)
    {
        var mantageHa = await _repository
            .GetListAsync(x => 
                filter.IsNullOrWhiteSpace() ? true :
                    x.Name.Contains(filter));
        return new ListResultDto<MantageDto>(
            ObjectMapper.Map<List<Mantage>, List<MantageDto>>(mantageHa)
        );
    }
}
