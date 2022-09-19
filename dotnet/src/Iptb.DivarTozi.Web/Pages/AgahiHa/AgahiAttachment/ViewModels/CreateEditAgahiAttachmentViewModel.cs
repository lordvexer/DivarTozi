using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.AgahiAttachment.ViewModels;

public class CreateEditAgahiAttachmentViewModel
{
    [Display(Name = "AgahiAttachmentAgahiId")]
    [HiddenInput]
    [Required]
    public Guid AgahiId { get; set; }

    [Display(Name = "AgahiAttachmentDescription")]
    [TextArea]
    public string Description { get; set; }
    
    [Required]
    [Display(Name = "File")]
    public IFormFile File { get; set; }
}
