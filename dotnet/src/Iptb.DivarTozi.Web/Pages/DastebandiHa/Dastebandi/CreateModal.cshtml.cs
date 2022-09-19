using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.DastebandiHa;
using Iptb.DivarTozi.DastebandiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.DastebandiHa.Dastebandi.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.DastebandiHa.Dastebandi;

public class CreateModalModel : DivarToziPageModel
{
    [BindProperty]
    public CreateEditDastebandiViewModel ViewModel { get; set; }

    private readonly IDastebandiAppService _service;

    public CreateModalModel(IDastebandiAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditDastebandiViewModel, CreateUpdateDastebandiDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}