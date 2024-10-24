using HW8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Contract
{
    public interface ITeacherRepository
    {
        List<Teacher> GetTeachers();
        public Teacher GetTeacher(int id);
        int GetTeacherId();
    }
}
