using HW8.Entities;
using HW8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Database
{
    public class SeedData
    {
        public static void Seed()
        {
            Operator op = new Operator("Arash", "Rajabi", "rajabiarash36@gmail.com") {Id=1};
            op.SetPassword("password");
            op.ActivateUser();
            Storage.Users.Add(op);

            Teacher teacher = new Teacher("Hossein", "Haghir", "Haghir@gmail.com") {Id=2};
            teacher.SetPassword("HosseinPass");
            teacher.ActivateUser();
            Storage.Users.Add(teacher);

            Student student = new Student("Mahmood","Moharrery","Mahmood@gmail.com",21,GenderEnum.Male) { Id=3 };
            student.SetPassword("Mahmood11");
            student.ActivateUser();
            Storage.Users.Add(student);

            UniversityCourse course = new UniversityCourse("Parasitology",60,1.5,DayOfWeek.Tuesday,TimeOnly.Parse("10:00:00"),TimeOnly.Parse("12:00"));
            course.SetId(1);
            Storage.Courses.Add(course);
            UniversityCourse course1 = new UniversityCourse("NeuroAnatomy", 70,2, DayOfWeek.Monday, TimeOnly.Parse("10:00"), TimeOnly.Parse("12:00"));
            course1.SetId(2);
            course1.Teachers.Add(teacher);
            teacher.Course.Add(course1);
            Storage.Courses.Add(course1);
            UniversityCourse course2 = new UniversityCourse("HeartPhysiology",70,1.4, DayOfWeek.Tuesday, TimeOnly.Parse("8:00"), TimeOnly.Parse("10:00"));
            course2.SetId(3);
            Storage.Courses.Add(course2);
        }
    }
}
