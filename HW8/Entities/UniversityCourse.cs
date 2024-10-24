using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW8.Entities
{
    public class UniversityCourse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; private set; }
        public List<Teacher> Teachers{ get; private set; } = new List<Teacher>();
        public List<Student> students{ get; private set; } = new List<Student>();
        public int Capacity { get; private set; }
        public double Unit { get; set; }
        public DayOfWeek day{ get; set; } 
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }   
        //public string  Prerequistie { get; set; }
        public UniversityCourse(string title, int capacity,double unit,DayOfWeek dayOfWeek,TimeOnly stime,TimeOnly etime)
        {
            Title = title;
            Capacity = capacity;
            Unit = unit;
            day = dayOfWeek;
            StartTime = stime;
            EndTime = etime;
        }
        public void SetId(int id)
        {CourseId = id; }
        public override string ToString()
        {
            return $"{Title} - Capacuty: {Capacity} - Unit: {Unit} -  CourseId: {CourseId}, Day of week: {day}, StartTime : {StartTime}, End time : {EndTime}";
        }
        public void SetCourseCap(int number)
        {
            Capacity = number;
        }
    }
}
