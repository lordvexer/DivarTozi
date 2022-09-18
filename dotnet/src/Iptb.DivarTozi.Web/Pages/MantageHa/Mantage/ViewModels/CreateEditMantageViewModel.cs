using System;
using System.ComponentModel.DataAnnotations;

namespace Iptb.DivarTozi.Web.Pages.MantageHa.Mantage.ViewModels;

public class CreateEditMantageViewModel
{
    [Display(Name = "MantageName")]
    public string Name { get; set; }
}
