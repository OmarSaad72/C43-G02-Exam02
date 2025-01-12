using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class FinalExam : Exam
    {
        public string? TrueOrFalse { get; }

        public FinalExam(int time, int numOfQuastions, Subject subject) : base(time, numOfQuastions, subject)
        {
        }

        public override void ShowFun()
        {
            if (Question is not null)
                foreach (var question in Question)
                {
                    question.ShowQ();
                    if (question.AnswersList is not null)
                        foreach (var Answer in question.AnswersList)
                            Console.WriteLine(Answer);
                    Console.WriteLine($"Grade: {question.Mark}");
                }
        }
    }
}
