using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.MantageHa;
using Iptb.DivarTozi.MantageHa.Dtos;
using Iptb.DivarTozi.Web.Pages.MantageHa.Mantage.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.MantageHa.Mantage;

public class EditModalModel : DivarToziPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditMantageViewModel ViewModel { get; set; }

    private readonly IMantageAppService _service;

    public EditModalModel(IMantageAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<MantageDto, CreateEditMantageViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditMantageViewModel, CreateUpdateMantageDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}