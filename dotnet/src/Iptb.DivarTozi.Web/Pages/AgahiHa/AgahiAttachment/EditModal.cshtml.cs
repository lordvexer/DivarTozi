using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment;

public class EditModalModel : DivarToziPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditAgahiAttachmentViewModel ViewModel { get; set; }

    private readonly IAgahiAttachmentAppService _service;

    public EditModalModel(IAgahiAttachmentAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<AgahiAttachmentDto, CreateEditAgahiAttachmentViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditAgahiAttachmentViewModel, CreateUpdateAgahiAttachmentDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}