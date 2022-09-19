using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.Agahi.ViewModels;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.Agahi;

public class EditModalModel : DivarToziPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditAgahiViewModel ViewModel { get; set; }

    private readonly IAgahiAppService _service;

    public EditModalModel(IAgahiAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<AgahiDto, CreateEditAgahiViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditAgahiViewModel, CreateUpdateAgahiDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}