namespace Iptb.DivarTozi.Permissions;

public static class DivarToziPermissions
{
    public const string GroupName = "DivarTozi";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Agahi
    {
        public const string Default = GroupName + ".Agahi";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Dastebandi
    {
        public const string Default = GroupName + ".Dastebandi";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public class Mantage
    {
        public const string Default = GroupName + ".Mantage";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
