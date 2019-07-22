using Autofac;

namespace StudentCourseApp.Data.Infrastructure
{
    public class DataDiModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
//            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
//            builder.RegisterType<AppDbContext>().As<IDatabaseContext>();
        }
    }
}
