using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class Subject
    {
        public Exam? Exam { get; set; }
        public int Id { get; }
        public string? Name { get; }

        public Subject(int id, string names)
        {
            Id = id;
            Name = names;
        }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
        }

        public override string ToString()
        {
            return $"SubjectID: {Id} & SubjectName: {Name}";
        }
    }
}
