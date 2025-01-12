using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal abstract class Question
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; }
        public Answers[]? AnswersList { get; set; }
        public int IndexOfRightAnswer { get; set; }

        public Question(string header0, string body, int mark)
        {
            Header = header0;
            Body = body;
            Mark = mark;
        }

        public abstract void ShowQ();

        public override string ToString()
        {
            return $"Header: {Header} & Body: {Body} & Mark: {Mark}";
        }
    }
}
