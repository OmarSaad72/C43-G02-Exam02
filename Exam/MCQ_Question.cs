using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class MCQ_Question : Question
    {
        public MCQ_Question(string header, string body, int mark, Answers[] answers, int indexOfrightAnswer) : base(header, body, mark)
        {
            AnswersList = answers;
            IndexOfRightAnswer = indexOfrightAnswer;
        }

        public override void ShowQ()
        {
            Console.WriteLine($"Header: {Header}\nBody: {Body} ==> Multiple Choices");
            if (AnswersList != null)
                foreach (var answer in AnswersList)
                    Console.WriteLine(answer);
        }
    }
}
