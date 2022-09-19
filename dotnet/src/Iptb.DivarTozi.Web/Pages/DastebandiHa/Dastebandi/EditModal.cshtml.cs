using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.DastebandiHa;
using Iptb.DivarTozi.DastebandiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.DastebandiHa.Dastebandi.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.DastebandiHa.Dastebandi;

public class EditModalModel : DivarToziPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditDastebandiViewModel ViewModel { get; set; }

    private readonly IDastebandiAppService _service;

    public EditModalModel(IDastebandiAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<DastebandiDto, CreateEditDastebandiViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditDastebandiViewModel, CreateUpdateDastebandiDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}