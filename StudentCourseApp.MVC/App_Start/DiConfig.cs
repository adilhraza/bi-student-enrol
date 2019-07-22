using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using StudentCourseApp.Services.Infrastructure;

namespace StudentCourseApp.MVC
{
    public static class DiConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterFilterProvider();

            // register services module
            builder.RegisterModule(new ServicesDiModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}