using Autofac;
using StudentCourseApp.Data.Repository;
using StudentCourseApp.Data.Repository.Impl;

namespace StudentCourseApp.Data.Infrastructure
{
    public class DataDiModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<StudentRepository>().As<IStudentRepository>();
           builder.RegisterType<CourseRepository>().As<ICourseRepository>();
        }
    }
}
