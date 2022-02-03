using OnlineExamSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OnlineExamSystem.Permissions
{
    public class OnlineExamSystemPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var myGroup = context.AddGroup("StudentMangment");
            //myGroup.AddPermission("Add_Student");
            var myGroup = context.AddGroup(OnlineExamSystemPermissions.GroupName, L("Online Exam System")); ;

            var studentManagement = myGroup.AddPermission(OnlineExamSystemPermissions.Student.Default, L("Student Management"));
            studentManagement.AddChild(OnlineExamSystemPermissions.Student.Create, L("Add "));
            studentManagement.AddChild(OnlineExamSystemPermissions.Student.Edit, L("Edit "));
            studentManagement.AddChild(OnlineExamSystemPermissions.Student.Delete, L("Delete"));



           
            //Define your own permissions here. Example:
            var classManagement= myGroup.AddPermission(OnlineExamSystemPermissions.Class.Default, L("Class Management"));
           // var classManagement = myGroup.AddPermission("Class_Management");
            classManagement.AddChild(OnlineExamSystemPermissions.Class.Create,L("Add "));
            classManagement.AddChild(OnlineExamSystemPermissions.Class.Edit, L("Edit "));
            classManagement.AddChild(OnlineExamSystemPermissions.Class.Delete, L("Delete "));


           
            //Define your own permissions here. Example:
            var testManagement = myGroup.AddPermission(OnlineExamSystemPermissions.Test.Default, L("Test Management"));
            // var classManagement = myGroup.AddPermission("Class_Management");
            testManagement.AddChild(OnlineExamSystemPermissions.Test.Create, L("Add "));
            testManagement.AddChild(OnlineExamSystemPermissions.Test.Edit, L("Edit"));
            testManagement.AddChild(OnlineExamSystemPermissions.Test.Delete, L("Delete"));
            testManagement.AddChild(OnlineExamSystemPermissions.Test.GetTest, L("Get"));
            testManagement.AddChild(OnlineExamSystemPermissions.Test.ViewQuestion, L("View Questions"));

         
            //Define your own permissions here. Example:
            var questionManagement = myGroup.AddPermission(OnlineExamSystemPermissions.Question.Default, L("Question Management"));
            // var classManagement = myGroup.AddPermission("Class_Management");
            questionManagement.AddChild(OnlineExamSystemPermissions.Question.Create, L("Add"));
            questionManagement.AddChild(OnlineExamSystemPermissions.Question.Edit, L("Edit"));
            questionManagement.AddChild(OnlineExamSystemPermissions.Question.Delete, L("Delete"));
          
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<StudentResource>(name);
        }
    }
}
