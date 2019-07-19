using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentCourseApp.MVC.Startup))]
namespace StudentCourseApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
