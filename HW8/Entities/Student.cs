using HW8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entities
{
    public class Student : User
    {
        public Student(string name, string lastname, string email) : base(name, lastname, email)
        {
            Status = StudentStatusEnum.Inactive;
        }
        public Student(string name,string lastname,string email,int age,GenderEnum gender) : this (name,lastname,email)
        {
            Gender = gender;
            Age = age;
            Role = RoleEnum.Student;
        }
        public List<UniversityCourse> Courses { get; set; } = new List<UniversityCourse>();
        public int Studentnum { get; private set; }
        public int Age { get; set; }
        public StudentStatusEnum Status { get; private set; }
        public GenderEnum Gender { get; set; }
        public bool IsExceptional { get; private set; }
        public bool IsCondtional { get; private set; }
        public override Result SetPassword(string currnetpass, string newpassword)
        {
            string result = "";
            if (!string.IsNullOrEmpty(newpassword) && !string.IsNullOrEmpty(currnetpass) && newpassword.Length>8)
            {
                if (currnetpass == newpassword)
                {
                    Password = newpassword;
                    return new Result(true, "Password has changed.");
                }
                else
                {
                    return new Result(false, "Incorrect password.");
                }
            }
            else
            {
                return new Result(false, "Invalid password.");
            }
        }
        public override Result SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password) && password.Length > 8)
            {
                Password = password;
                return new Result(true, null);
            }
           return new Result(false, "Incorrect password.");
        }
        public string Activate()
        {
            if (Status == StudentStatusEnum.Active)
            {
                return "Student is already active";
            }
            else if (Status == StudentStatusEnum.Suspend)
            {
                return "Student is suspended and can not be activated.";
            }
            Status = StudentStatusEnum.Active;
            return "Student Activated.";
        }
        public string SetConditional()
        {
            IsCondtional = true;
            return $"Student {Name} is Conditional now.";
        }
        public string SetExceptional()
        {
            IsExceptional = true;
            return $"{Name} is Excellent.";
        }
        public double UnitSum()
        {
            double unit = 0;
            foreach (var item in Courses)
            {
                unit += item.Unit;
                return unit;
            }
            return 0;
        }
        public override string ToString()
        {
            return $"{Name}-{Lastname}-{Email}- id: {Id}- Gender: {Gender}- Age: {Age}- Status: {Status}";
        }

    }
}
