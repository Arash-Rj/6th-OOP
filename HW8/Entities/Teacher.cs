using HW8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entities
{
    public class Teacher : User
    {
        public Teacher(string name, string lastname, string email) : base(name, lastname, email)
        {
            Role =RoleEnum.Teacher;
        }
        public string Speciality { get; set; }
        public List<UniversityCourse> Course { get; set; } = new List<UniversityCourse>();
        public override string ToString()
        {
            return $"{Name}-{Lastname}-{Email}- id: {Id} -Speciality: {Speciality}";
        }
    }
}
