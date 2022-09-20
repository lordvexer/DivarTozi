using System.Threading.Tasks;
using Iptb.DivarTozi.Permissions;
using Iptb.DivarTozi.Localization;
using Iptb.DivarTozi.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Iptb.DivarTozi.Web.Menus;

public class DivarToziMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<DivarToziResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                DivarToziMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        if (await context.IsGrantedAsync(DivarToziPermissions.Agahi.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DivarToziMenus.Agahi, l["Menu:Agahi"], "/AgahiHa/Agahi")
            );
        }
        if (await context.IsGrantedAsync(DivarToziPermissions.Dastebandi.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DivarToziMenus.Dastebandi, l["Menu:Dastebandi"], "/DastebandiHa/Dastebandi")
            );
        }
        if (await context.IsGrantedAsync(DivarToziPermissions.Mantage.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DivarToziMenus.Mantage, l["Menu:Mantage"], "/MantageHa/Mantage")
            );
        }
        if (await context.IsGrantedAsync(DivarToziPermissions.AgahiAttachment.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(DivarToziMenus.AgahiAttachment, l["Menu:AgahiAttachment"], "/AgahiHa/AgahiAttachment")
            );
        }
    }
}
