using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exam02
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numOfQuastions, Subject subject) : base(time, numOfQuastions, subject)
        {
        }

        public override void ShowFun()
        {
            if (Question != null)
                foreach (var question in Question)
                    question.ShowQ();
        }

        public void ShowRightAnswers()
        {
            Console.WriteLine("Right Answer ==> ");
            if (Question != null)
                foreach (var question in Question)
                    Console.Write(question.IndexOfRightAnswer);
        }
    }
}
