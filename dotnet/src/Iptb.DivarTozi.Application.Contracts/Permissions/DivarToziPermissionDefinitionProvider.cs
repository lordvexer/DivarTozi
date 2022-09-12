using Iptb.DivarTozi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Iptb.DivarTozi.Permissions;

public class DivarToziPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DivarToziPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DivarToziPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DivarToziResource>(name);
    }
}
