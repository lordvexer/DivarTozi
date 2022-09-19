using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.Agahi.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.Agahi;

public class CreateModalModel : DivarToziPageModel
{
    [BindProperty]
    public CreateEditAgahiViewModel ViewModel { get; set; }

    private readonly IAgahiAppService _service;

    public CreateModalModel(IAgahiAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditAgahiViewModel, CreateUpdateAgahiDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}