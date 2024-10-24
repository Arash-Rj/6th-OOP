using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entities
{
    public class Result
    {
        public bool IsDone { get; set; }
        public string? Message { get; set; }
        public Result(bool isDone, string? message=null) 
        {
            IsDone = isDone;
            Message = message;
        }
    }
}
