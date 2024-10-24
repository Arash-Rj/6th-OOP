using HW8.Contract;
using HW8.Database;
using HW8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Repositories
{
    public class CourseRepository : ICourserepository
    {
        public void AddCourse(UniversityCourse course)
        {
            Storage.Courses.Add(course);
        }

        public UniversityCourse GetCourse(int id)
        {
           foreach(var course in Storage.Courses)
            {
                if(course.CourseId == id)
                {
                    return course;
                }
            }
            return null;
        }

        public List<UniversityCourse> GetCourses()
        {
            return Storage.Courses;
        }

        public int LastCourseId()
        {
           UniversityCourse course = Storage.Courses.Last();
            return course.CourseId;
        }
    }
}
