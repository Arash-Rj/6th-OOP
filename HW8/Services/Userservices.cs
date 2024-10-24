using HW8.Contract;
using HW8.Database;
using HW8.Entities;
using HW8.Enums;
using HW8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HW8.Services
{
    public class Userservices
    {
        IUserRepository userRep = new UserRepository();
        ITeacherRepository teacherRep = new TeacherRepository();
        ICourserepository courseRep = new CourseRepository();
        public Userservices()
        {
            userRep = new UserRepository();
        }
        public Result Login(string email,string password,out User? user1)
        {
            var users = userRep.GetUsers();
            bool DoesExist1 = false;
            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    DoesExist1 = true;
                    var res = user.Checkpassword(password);
                    if (res.IsDone)
                    {
                        if (user.IsActive)
                        {
                            userRep.Login(user);
                            user1 = user;
                            return new Result(true);
                        }
                        else
                        {
                            user1 = null;
                            return new Result(false, "User is inactive.");
                        }
                    }
                    else
                    {
                        user1 = null;
                        return res;
                    }
                }
            }
            user1 = null;
            return new Result(false,"User not found!");
        }
        public Result Register(User user,string pass)
        {
            var Res = user.SetPassword(pass);
            if (!Res.IsDone)
            {
                userRep.Register(user);
                return new Result(true,"Registration successful.");
            }
            else
            {
                return Res;
            }
        }
        public Result ListOfTeachers()
        {
            var t = teacherRep.GetTeachers();
            if (t != null)
            {
                foreach (var te in t)
                {
                    Console.WriteLine(te.ToString());
                    return new Result(true);
                }
            }
            return new Result(false, "No teacher found");
        }
        public Teacher GetTeacher(int id)
        { 
           Teacher teacher= teacherRep.GetTeacher(id);
           return teacher;
        }
        public void ListOfUsers()
        {
            var users = userRep.GetUsers();
            foreach (var item in users)
            {
                Console.WriteLine("================");
                Console.WriteLine(item.ToString());
            }
        }
        public void RemoveUser(int id)
        {
            userRep.RemoveUser(id);
        }
        public Result ListOfInActiveUsers()
        {
            List<User> inactiveusers = userRep.GetInActiveUsers();
            if(inactiveusers != null)
            {
                foreach(var user in inactiveusers)
                {
                    Console.WriteLine("===================");
                    Console.WriteLine(user.ToString());
                }
                return new Result(true);
            }
            return new Result(false, "No inactive user found.");
        }
        public string Activateuser(int id)
        {
            var res = userRep.ActivateUser(id);
            return res.Message;
        }
        public User GetCurrentUser()
        {
            return userRep.GetCurrentUser();
        }
        public Result EntekhabVahed(int idcourse, Student user)
        {
            UniversityCourse course = courseRep.GetCourse(idcourse);
            foreach (var Course in user.Courses)
            {
                if (idcourse == Course.CourseId)
                {
                    return new Result(false, "You Already take this course!");
                }
            }
            foreach(var Course in user.Courses)
            {
                if(Course.day == course.day)
                {
                    if(course.EndTime<Course.EndTime && course.EndTime>Course.StartTime)
                    {
                        return new Result(false,"Interference time!");
                    }
                    if (course.StartTime < Course.EndTime && course.StartTime> Course.StartTime)
                    {
                        return new Result(false, "Interference time!");
                    }
                }
            }
            foreach (var item in Storage.Courses)
            {
                if (item.CourseId == idcourse)
                {
                    double a = item.Unit + user.UnitSum();
                    if (a < 20 || a > 12)
                    {
                        user.Courses.Add(item);
                        item.students.Add(user);
                        return new Result(true);
                    }
                    else
                    {
                        return new Result(false, "you Can not! it is more than capacity!");
                    }
                }
            }
            return new Result(false, "incorrect id.");
        }
        public void ListofStudentCourse(Student student)
        {
            if(student.Courses != null)
            {
                foreach (var course in student.Courses)
                {
                    Console.WriteLine(course.ToString());
                }
            }
            else
            {
                Console.WriteLine("You have not selected any course yet.");
            }
        }
        public void ListOfStudentds(Teacher teacher)
        {
            foreach(var course in teacher.Course)
            {
                foreach(Student item in course.students)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void SetStuId(Student St)
        {
            int id = userRep.LastStudentId();
            St.Id = id +1;
        }
        public void SetTeachId(Teacher Th)
        {
            int id = teacherRep.GetTeacherId();
            Th.Id = id + 1;
        }
    }
}
