using HW8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        protected string Password { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; private set; }
        public RoleEnum Role { get; set; }

        public User(string name, string lastname, string email)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Username = email;
            IsActive = false;
        }
        public virtual Result SetPassword(string currnetpass, string newpassword)
        {
            if (!string.IsNullOrEmpty(newpassword) && !string.IsNullOrEmpty(currnetpass))
            {
                if(currnetpass==Password)
                {
                    Password = newpassword;
                    return new Result(true,"Password has changed.");
                }
                else
                {
                    return new Result(false,"Incorrect password.");
                }
            }
            else
            {
                return new Result(false,"Invalid password.");
            }
        }
        public virtual Result SetPassword(string password)
        {
            if(!string.IsNullOrEmpty(password) && password.Length>7)
            {
                Password = password;
                return new Result(true,null);
            }
            return new Result(false,"Incorrect password.");
        }
        public string ActivateUser()
        {
            IsActive = true;
            return "User Activated.";
        }
        public Result Checkpassword(string pass)
        {
            if(pass == Password)
            {
                return new Result(true,null);
            }
            return new Result(false,"Incorrect password.");
        }
        public override string ToString()
        {
            return $"{Name}-{Lastname}-{Password}-{Email}-[[Active: {IsActive}]]-((ID: {Id}))- Role: {Role}.";
        }
    }
}
