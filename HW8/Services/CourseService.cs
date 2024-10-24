using HW8.Contract;
using HW8.Entities;
using HW8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Services
{
    public class CourseService
    {
        ICourserepository courseRep;
        ITeacherRepository teacherRep;
        public CourseService()
        {
            courseRep = new CourseRepository();
        }
        public void AddCourse(UniversityCourse course,Teacher teacher)
        {
            AddCourseTeacher(teacher, course);
            SetCourseId(course);
            courseRep.AddCourse(course);
        }
        public void SetCourseId(UniversityCourse course)
        {
            int lastid=courseRep.LastCourseId();
            course.SetId(lastid++);
        }
        public void AddCourseTeacher(Teacher teacher,UniversityCourse course)
        {
            course.Teachers.Add(teacher);
            teacher.Course.Add(course);
        }
        public void ListOfcourses()
        {
            courseRep.GetCourses().ToList().ForEach(course => { Console.WriteLine("---------------------"); Console.WriteLine(course.ToString()); });
        }
        public Result ChangeCoursecap(int newcap,int courseid)
        {
            var course = courseRep.GetCourse(courseid);
            if (course == null)
            {
                return new Result(false, "Course not found!");
            }
            course.SetCourseCap(newcap);
            return new Result(true,"Course capacity changed.");
        }
    }
}
