using HW8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entities
{
    public class Operator : User
    {
        public Operator(string name, string lastname, string email) : base(name, lastname, email)
        {
            Role =RoleEnum.Operator;
        }

    }
}
