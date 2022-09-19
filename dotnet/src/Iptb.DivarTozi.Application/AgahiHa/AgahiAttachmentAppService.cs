using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Iptb.DivarTozi.Permissions;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Iptb.DivarTozi.AgahiHa;

public class AgahiAttachmentAppService : CrudAppService<AgahiAttachment, AgahiAttachmentDto, Guid,
        PagedAndSortedResultRequestDto, CreateUpdateAgahiAttachmentDto, CreateUpdateAgahiAttachmentDto>,
    IAgahiAttachmentAppService
{
    protected override string GetPolicyName { get; set; } = DivarToziPermissions.AgahiAttachment.Default;
    protected override string GetListPolicyName { get; set; } = DivarToziPermissions.AgahiAttachment.Default;
    protected override string CreatePolicyName { get; set; } = DivarToziPermissions.AgahiAttachment.Create;
    protected override string UpdatePolicyName { get; set; } = DivarToziPermissions.AgahiAttachment.Update;
    protected override string DeletePolicyName { get; set; } = DivarToziPermissions.AgahiAttachment.Delete;

    private readonly IAgahiAttachmentRepository _repository;
    private readonly IBlobContainer<AgahiContainer> _fileContainer;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IAuthorizationService _authorizationService;
    private readonly IAgahiRepository _agahiRepository;

    public AgahiAttachmentAppService(
        IAgahiAttachmentRepository repository,
        IBlobContainer<AgahiContainer> fileContainer,
        IGuidGenerator guidGenerator,
        IAuthorizationService authorizationService,
        IAgahiRepository agahiRepository
    ) : base(repository)
    {
        this._repository = repository;
        this._fileContainer = fileContainer;
        this._guidGenerator = guidGenerator;
        this._authorizationService = authorizationService;
        this._agahiRepository = agahiRepository;
    }

    public override async Task DeleteAsync(Guid id)
    {
        var factor = await _repository.GetAsync(id);
        var agahi = await _agahiRepository.GetAsync(factor.AgahiId);

        await base.DeleteAsync(id);
    }

    public async Task<PagedResultDto<AgahiAttachmentDto>> GetListByIdAsync(GetAgahiAttachmentDto input)
    {
        var list = await _repository.GetListAsync(
            input.Sorting,
            input.Filter,
            input.Id,
            input.SkipCount,
            input.MaxResultCount
        );
        var totalCount = await _repository.CountAsync(
            p =>
                (p.Description.Contains(input.Filter)
                 || p.FileName.Contains(input.Filter))
                && p.AgahiId == input.Id
        );

        return new PagedResultDto<AgahiAttachmentDto>(
            totalCount,
            ObjectMapper.Map<List<ViewAttachment>,
                List<AgahiAttachmentDto>>(list)
        );
    }

    public async Task SaveBlobAsync(CreateUpdateAgahiAttachmentDto input)
    {
        var id = _guidGenerator.Create();
        var fileName = $"{PersianDate.Standard.ConvertDate.ToFa(DateTime.Now, "YYYY/MM/dd")}/{id}";
        var melkDetailAttachment =
            await _repository.InsertAsync(
                new AgahiAttachment(
                    id,
                    input.AgahiId,
                    fileName,
                    input.FileName,
                    input.FileExtension,
                    input.Description
                )
                , true);
        await _fileContainer.SaveAsync(fileName, input.Content, true);
    }

    public async Task<AttachmentDto> GetBlobAsync(GetAttachmentRequestDto input)
    {
        var attachment = await _repository.GetAsync(p => p.Id == input.Id);
        var blob = await _fileContainer.GetAllBytesAsync(attachment.ContainerFilePath);

        return new AttachmentDto
        {
            Name = attachment.FileName,
            Content = blob,
            Extension = attachment.FileExtension
        };
    }
}

