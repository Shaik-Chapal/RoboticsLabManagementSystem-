
namespace RoboticsLabManagementSystem.Infrastructure.EmailTemplates
{
    public partial class PasswordResetEmailTemplate
    {
        private string Name { get; set; }
        private string Link { get; set; }

        public PasswordResetEmailTemplate(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}