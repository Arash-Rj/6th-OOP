using HW8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Contract
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void Login(User user);
        void Register(User user);
        void RemoveUser(int id); 
        List<User> GetInActiveUsers();
        Result ActivateUser(int id);
        User GetCurrentUser();
        List<Student> GetStudents();
        int LastStudentId();
    }
}
