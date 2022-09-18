using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Iptb.DivarTozi.Web.Pages.AgahiHa.Agahi.ViewModels;

public class CreateEditAgahiViewModel
{
    [Display(Name = "AgahiRegionId")]
    public Guid RegionId { get; set; }

    [Display(Name = "AgahiTitle")]
    public string Title { get; set; }

    [Display(Name = "AgahiOfficeName")]
    public string OfficeName { get; set; }

    [Display(Name = "AgahiBrief")]
    [TextArea]
    public string Brief { get; set; }

    [Display(Name = "AgahiReleaseDate")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "AgahiDastebandiId")]
    public Guid DastebandiId { get; set; }
}
