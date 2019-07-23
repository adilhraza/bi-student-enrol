using Autofac;
using StudentCourseApp.Data.Infrastructure;
using StudentCourseApp.Services.Impl;

namespace StudentCourseApp.Services.Infrastructure
{
    public class ServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<StudentCourseService>().As<IStudentCourseService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            
            builder.RegisterModule(new DataDiModule());
        }
    }
}
