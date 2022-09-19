using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment;

public class CreateModalModel : DivarToziPageModel
{
    [BindProperty]
    public CreateEditAgahiAttachmentViewModel ViewModel { get; set; }

    private readonly IAgahiAttachmentAppService _service;

    public CreateModalModel(IAgahiAttachmentAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditAgahiAttachmentViewModel, CreateUpdateAgahiAttachmentDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}