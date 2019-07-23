using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using StudentCourseApp.Data.Entity;
using StudentCourseApp.Data.Repository;
using StudentCourseApp.Services.Impl;

namespace StudentCourseApp.Services.Test
{
    [TestFixture]
    public class StudentCourseServiceTests
    {
        private Mock<IStudentRepository> studentRepositoryMock;
        private Mock<ICourseRepository> courseRepositoryMock;

        [SetUp]
        public void Setup()
        {
            studentRepositoryMock = new Mock<IStudentRepository>();
            courseRepositoryMock = new Mock<ICourseRepository>();
        }

        [Test]
        public void AddCourseToStudent_NoCourseIdProvided_ThrowException()
        {
            var mock = new Mock<IStudentCourseService>();

            mock.Setup(m => m.AddCourseToStudent(0, It.IsAny<int>())).Throws<InvalidDataException>();
        }

        [Test]
        public void AddCourseToStudent_NoStudentIdProvided_ThrowException()
        {
            var mock = new Mock<IStudentCourseService>();

            mock.Setup(m => m.AddCourseToStudent(It.IsAny<int>(), 0)).Throws<InvalidDataException>();
        }

        [Test]
        public void AddCourseToStudent_StudentHasLessThan5Courses_AddNewCourse()
        {
            var student = new Student
            {
                StudentId = 1,
                Courses = new List<Course>
                {
                    new Course {CourseId = 1},
                    new Course {CourseId = 2},
                    new Course {CourseId = 3},
                    new Course {CourseId = 4}
                }
            };

            studentRepositoryMock.Setup(cr => cr.Get(1)).Returns(student);

            var service = new StudentCourseService(studentRepositoryMock.Object, courseRepositoryMock.Object);

            service.AddCourseToStudent(2, 1);

            studentRepositoryMock.Verify((m => m.Save()), Times.Once());
        }

        [Test]
        public void AddCourseToStudent_StudentHas5Courses_AddNewCourse()
        {
            var student = new Student
            {
                StudentId = 1,
                Courses = new List<Course>
                {
                    new Course {CourseId = 1},
                    new Course {CourseId = 2},
                    new Course {CourseId = 3},
                    new Course {CourseId = 4},
                    new Course {CourseId = 5}
                }
            };

            studentRepositoryMock.Setup(cr => cr.Get(1)).Returns(student);

            var service = new StudentCourseService(studentRepositoryMock.Object, courseRepositoryMock.Object);

            service.AddCourseToStudent(It.IsAny<int>(), It.IsAny<int>());

            studentRepositoryMock.Verify((m => m.Save()), Times.Never);
        }

    }
}
