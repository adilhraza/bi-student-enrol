﻿using Autofac;
using StudentCourseApp.Data.Infrastructure;
using StudentCourseApp.Services.Impl;

namespace StudentCourseApp.Services.Infrastructure
{
    public class ServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>();
            
            builder.RegisterModule(new DataDiModule());
        }
    }
}
