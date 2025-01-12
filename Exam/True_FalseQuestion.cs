using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class True_FalseQuestion : Question
    {
        public bool CorrectAnswers { get; set; }
        public True_FalseQuestion(string header, string body, int mark) : base(header, body, mark)
        {
            AnswersList = new Answers[]
            {
                new Answers (1 , "True"),
                new Answers (2 , "False")
            };
        }

        public True_FalseQuestion(string header, string body, int mark, bool correcanswers) : base(header, body, mark)
        {
            CorrectAnswers = correcanswers;
        }
        public override void ShowQ()
        {
            Console.WriteLine($"Header: {Header}\nBody: {Body} ==> True: 1 Or False: 2 ");
        }
    }
}
