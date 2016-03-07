using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
  
    public class Student
    {
        
        public string StudentId { get; set; }
     
        public string StudentName { get; set; }
        public Address[] Address { get; set; }

        public Student(string studentId, string studentName, params Address[] address)
        {
            StudentId = studentId;
            StudentName = studentName;
            Address = address;
        }
    }
}
