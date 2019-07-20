using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentCourseApp.Data.Enums;

namespace StudentCourseApp.Data.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Index]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        // navigational prop
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
