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

        var agahiPermission = myGroup.AddPermission(DivarToziPermissions.Agahi.Default, L("Permission:Agahi"));
        agahiPermission.AddChild(DivarToziPermissions.Agahi.Create, L("Permission:Create"));
        agahiPermission.AddChild(DivarToziPermissions.Agahi.Update, L("Permission:Update"));
        agahiPermission.AddChild(DivarToziPermissions.Agahi.Delete, L("Permission:Delete"));

        var dastebandiPermission = myGroup.AddPermission(DivarToziPermissions.Dastebandi.Default, L("Permission:Dastebandi"));
        dastebandiPermission.AddChild(DivarToziPermissions.Dastebandi.Create, L("Permission:Create"));
        dastebandiPermission.AddChild(DivarToziPermissions.Dastebandi.Update, L("Permission:Update"));
        dastebandiPermission.AddChild(DivarToziPermissions.Dastebandi.Delete, L("Permission:Delete"));

        var mantagePermission = myGroup.AddPermission(DivarToziPermissions.Mantage.Default, L("Permission:Mantage"));
        mantagePermission.AddChild(DivarToziPermissions.Mantage.Create, L("Permission:Create"));
        mantagePermission.AddChild(DivarToziPermissions.Mantage.Update, L("Permission:Update"));
        mantagePermission.AddChild(DivarToziPermissions.Mantage.Delete, L("Permission:Delete"));

        var agahiAttachmentPermission = myGroup.AddPermission(DivarToziPermissions.AgahiAttachment.Default, L("Permission:AgahiAttachment"));
        agahiAttachmentPermission.AddChild(DivarToziPermissions.AgahiAttachment.Create, L("Permission:Create"));
        agahiAttachmentPermission.AddChild(DivarToziPermissions.AgahiAttachment.Update, L("Permission:Update"));
        agahiAttachmentPermission.AddChild(DivarToziPermissions.AgahiAttachment.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DivarToziResource>(name);
    }
}
