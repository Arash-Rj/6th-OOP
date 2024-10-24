using HW8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Contract
{
    public interface ICourserepository
    {
        void AddCourse(UniversityCourse course);
        int LastCourseId();
        List<UniversityCourse> GetCourses();
        UniversityCourse GetCourse(int id);
    }
}
