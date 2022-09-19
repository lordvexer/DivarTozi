using System;
using System.IO;
using System.Threading.Tasks;
using Iptb.DivarTozi.AgahiHa;
using Iptb.DivarTozi.AgahiHa.Dtos;
using Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment;

public class IndexModel : DivarToziPageModel
{
    private readonly IAgahiAttachmentAppService _service;

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid AgahiId { get; set; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid AttachmentId { get; set; }

    [BindProperty]
    public CreateEditAgahiAttachmentViewModel ViewModel { get; set; }

    public IndexModel(IAgahiAttachmentAppService service)
    {
        _service = service;
    }
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
    
    public virtual async Task<IActionResult> OnPostUpload()
    {
        using (var memoryStream = new MemoryStream())
        {
            await ViewModel.File.CopyToAsync(memoryStream);

            await _service.SaveBlobAsync(
                new CreateUpdateAgahiAttachmentDto()
                {
                    Description = ViewModel.Description,
                    FileName = ViewModel.File.FileName,
                    FileExtension = Path.GetExtension(ViewModel.File.FileName),
                    AgahiId = ViewModel.AgahiId,
                    Content = memoryStream.ToArray()
                }
            );
        }
        return NoContent();
    }

}
