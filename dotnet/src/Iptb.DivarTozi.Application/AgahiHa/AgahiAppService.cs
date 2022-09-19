using System;
using Iptb.DivarTozi.Permissions;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiAppService : CrudAppService<Agahi, AgahiDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAgahiDto, CreateUpdateAgahiDto>,
    IAgahiAppService
{
    protected override string GetPolicyName { get; set; } = DivarToziPermissions.Agahi.Default;
    protected override string GetListPolicyName { get; set; } = DivarToziPermissions.Agahi.Default;
    protected override string CreatePolicyName { get; set; } = DivarToziPermissions.Agahi.Create;
    protected override string UpdatePolicyName { get; set; } = DivarToziPermissions.Agahi.Update;
    protected override string DeletePolicyName { get; set; } = DivarToziPermissions.Agahi.Delete;

    private readonly IAgahiRepository _repository;

    public AgahiAppService(IAgahiRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
