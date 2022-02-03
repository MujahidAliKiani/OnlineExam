namespace OnlineExamSystem.Permissions
{
    public static class OnlineExamSystemPermissions
    {
        public const string GroupName = "OnlineExamSystem";

        //Add your own permission names. Example:
        public static class Class
        {
            public const string Default = GroupName + ".Class";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Student
        {
            public const string Default = GroupName + ".Student";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Test
        {
            public const string Default = GroupName + ".Test";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ViewQuestion = Default + ".ViewQuestion";
            public const string GetTest = Default + ".GetTest";
        }
        public static class Question
        {
            public const string Default = GroupName + ".Question";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
      
    }
}