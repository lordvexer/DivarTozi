using System;
using System.ComponentModel.DataAnnotations;

namespace Iptb.DivarTozi.Web.Pages.DastebandiHa.Dastebandi.ViewModels;

public class CreateEditDastebandiViewModel
{
    [Display(Name = "DastebandiName")]
    public string Name { get; set; }

    [Display(Name = "Dastebandi")]
    public Guid? ParentId { get; set; }
}
