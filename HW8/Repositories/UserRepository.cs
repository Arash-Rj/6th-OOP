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
    public class UserRepository : IUserRepository
    {
        public Result ActivateUser(int id)
        {
            foreach (var user in Storage.Users)
            {
                if(user.Id == id)
                {
                    string outcome = user.ActivateUser();
                    return new Result(true, outcome);   
                }
            }
            return new Result(false,"User id is incorrect.");
        }

        public List<User> GetInActiveUsers()
        {
           List<User> inactiveUsers = new List<User>();
            foreach (var user in Storage.Users)
            {
                if(user.IsActive==false)
                    inactiveUsers.Add(user);
            }
            return inactiveUsers;
        }

        public List<User> GetUsers()
        {
            return Storage.Users; 
        }

        public void Login(User user)
        {
            Storage.Onlineuser = user;
        }

        public void Register(User user)
        {
            Storage.Users.Add(user);
        }

        public void RemoveUser(int id)
        {
            foreach (var user in Storage.Users)
            {
                if (user.Id == id)
                {
                    Storage.Users.Remove(user);
                }
            }
        }
        public User GetCurrentUser()
        {
            return Storage.Onlineuser;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            foreach(Student st in Storage.Users)
            {
                students.Add(st);
                return students;
            }
            return null;
        }

        public int LastStudentId()
        {
            int id = 0; 
            foreach(var user in Storage.Users)
            {
                if(user is Student)
                {
                    id = user.Id;
                }
            }
            return id;
        }
    }
}
