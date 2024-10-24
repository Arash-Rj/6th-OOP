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
    public class TeacherRepository : ITeacherRepository
    {
        public List<Teacher> GetTeachers()
        {
           List<Teacher> teachers = new List<Teacher>();
            foreach (var user in Storage.Users)
            {
                if(user is Teacher)
                {
                    teachers.Add((Teacher)user);
                }
            }
            return teachers;
        }
        public Teacher GetTeacher(int id)
        {
            foreach (var user in Storage.Users)
            {
                if (user is Teacher && user.Id == id)
                {
                    return (Teacher)user;
                }
            }
            return null;
        }

        public int GetTeacherId()
        {
            int id = 0;
            foreach (var user in Storage.Users)
            {
                if (user is Teacher)
                {
                    id = user.Id;
                }
            }
            return id;
        }
    }
}
