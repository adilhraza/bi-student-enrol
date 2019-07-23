using System;
using System.Collections.Generic;
using StudentCourseApp.Data.Entity;
using StudentCourseApp.Data.Repository;
using StudentCourseApp.Services.Mappers;
using StudentCourseApp.Shared.Models;

namespace StudentCourseApp.Services.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentModel Get(int id)
        {
            return _studentRepository.Get(id).ToModel();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return _studentRepository.GetAll().ToModels();
        }

        public void RemoveStudent(int id)
        {
            var student = _studentRepository.Get(id);

            if (student == null) return;

            _studentRepository.Remove(student);
        }

        public void UpdateStudent(StudentModel studentModel)
        {
            var student = _studentRepository.Get(studentModel.Id);
            student.FirstName = studentModel.FirstName;
            student.LastName = studentModel.LastName;
            student.Gender = studentModel.Gender;
            student.DateOfBirth = studentModel.DateOfBirth;
            student.AddressLine1 = studentModel.AddressLine1;
            student.AddressLine2 = studentModel.AddressLine2;
            student.AddressLine3 = studentModel.AddressLine3;

            _studentRepository.Update(student);
            _studentRepository.Save();
        }

        public int AddNew(StudentModel studentModel)
        {
            var student = new Student
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Gender = studentModel.Gender,
                DateOfBirth = studentModel.DateOfBirth,
                AddressLine1 = studentModel.AddressLine1,
                AddressLine2 = studentModel.AddressLine2,
                AddressLine3 = studentModel.AddressLine3,
                Courses = new List<Course>()
            };

            _studentRepository.Add(student);
            _studentRepository.Save();

            return student.StudentId;
        }
    }
}
