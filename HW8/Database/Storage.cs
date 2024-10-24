using HW8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Database
{
    public static class Storage
    {
       public static User? Onlineuser {  get; set; }
       public static List<User> Users { get; set; } = new List<User>();
        public static List<UniversityCourse> Courses { get; set; } = new List<UniversityCourse>();
        //public static List<Operator> Operators { get; set; } = new List<Operator>();
        //public static List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
