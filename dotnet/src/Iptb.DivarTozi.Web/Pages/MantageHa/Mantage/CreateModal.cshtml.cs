using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.MantageHa;
using Iptb.DivarTozi.MantageHa.Dtos;
using Iptb.DivarTozi.Web.Pages.MantageHa.Mantage.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.MantageHa.Mantage;

public class CreateModalModel : DivarToziPageModel
{
    [BindProperty]
    public CreateEditMantageViewModel ViewModel { get; set; }

    private readonly IMantageAppService _service;

    public CreateModalModel(IMantageAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditMantageViewModel, CreateUpdateMantageDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}