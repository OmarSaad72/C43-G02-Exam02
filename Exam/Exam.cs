using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumOfQuastions { get; set; }
        public Question[]? Question { get; set; }
        public Subject Subject { get; set; }

        public Exam(int time, int numOfQuastions, Subject subject)
        {
            TimeOfExam = time;
            NumOfQuastions = numOfQuastions;
            Subject = subject;
            //Question = new Question[numOfQuastions];
        }

        public abstract void ShowFun();
    }
}
