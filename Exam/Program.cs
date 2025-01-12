using Exam02;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Exam02
{
    internal class Program
    {
        static void Main()
        {
            int subjectId;
            do
            {
                Console.WriteLine("Enter Subject Id: ");
            } while (!int.TryParse(Console.ReadLine(), out subjectId) || subjectId <= 0);

            Console.WriteLine("Enter Subject Name: ");
            string subjectName = Utility.StringsVAlidation();

            Subject subject = new Subject(subjectId, subjectName);
            Console.Clear();

            string typeofexam;
            do
            {
                Console.WriteLine("Select Type Of Exam: Practical Exam Or Final Exam?");
                typeofexam = Utility.StringsVAlidation();
            } while (typeofexam != "Practical" & typeofexam != "Final");

            int timeOfExam;
            do
            {
                Console.WriteLine("Enter Time of Exam: ");
            } while (!int.TryParse(Console.ReadLine(), out timeOfExam) || timeOfExam <= 0);


            int NumberOfQuestions;
            do
            {
                Console.WriteLine("Enter Number of Questions: ");

            } while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions) || NumberOfQuestions <= 0);

            Console.Clear();

            Exam exam;
            Question[] questions = new Question[NumberOfQuestions];
            int[] user = new int[NumberOfQuestions];
            int TotalofMarks = 0;
            if (typeofexam == "Practical")
            {
                exam = new PracticalExam(timeOfExam, NumberOfQuestions, subject);
                Console.WriteLine("MCQ Exam: ");
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    Answers[] answers = new Answers[4];
                    Console.WriteLine($"Enter the Header for Question{i + 1}: ");
                    string header = Utility.StringsVAlidation();

                    Console.WriteLine($"Enter the Body for Question{i + 1}: ");
                    string body = Utility.StringsVAlidation();

                    int mark;
                    do
                    {
                        Console.WriteLine($"Enter the Mark for Question{i + 1}: ");
                    } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                    TotalofMarks += mark;
                    for (int j = 0; j < answers.Length; j++)
                    {
                        Console.WriteLine($"Enter Answer Text{j + 1}: ");
                        string text = Utility.StringsVAlidation();
                        answers[j] = new Answers(j + 1, text);
                    }

                    int correctanswer;
                    do
                    {
                        Console.WriteLine("Enter Number of the Correct Answer: ");
                    } while (!int.TryParse(Console.ReadLine(), out correctanswer) || correctanswer < 1 || correctanswer > answers.Length);

                    questions[i] = new MCQ_Question(header, body, mark, answers, correctanswer);
                }
            }
            else
            {
                exam = new FinalExam(timeOfExam, NumberOfQuestions, subject);

                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    int TypeOfQuestion;
                    do
                    {
                        Console.WriteLine("Select Type of Question: 1 ==> True Or False & 2 ==> MCQ");
                    } while (!int.TryParse(Console.ReadLine(), out TypeOfQuestion) || (TypeOfQuestion != 1 && TypeOfQuestion != 2));

                    Console.WriteLine($"Enter the Header for Question{i + 1}: ");
                    string header = Utility.StringsVAlidation();

                    Console.WriteLine($"Enter the Body for Question{i + 1}: ");
                    string body = Utility.StringsVAlidation();

                    int mark;
                    do
                    {
                        Console.WriteLine($"Enter the Mark for Question{i + 1}: ");
                    } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                    TotalofMarks += mark;

                    if (TypeOfQuestion == 1)
                    {
                        questions[i] = new True_FalseQuestion(header, body, mark);

                        int CorrectNum;
                        do
                        {
                            Console.WriteLine("Enter Number of the Correct Answer 1 ==> True Or 2 ==> False");
                        } while (!int.TryParse(Console.ReadLine(), out CorrectNum) || CorrectNum < 1 || CorrectNum > 2);

                        bool RightAnswer = CorrectNum == 1;
                        ((True_FalseQuestion)questions[i]).CorrectAnswers = RightAnswer;
                    }
                    else
                    {
                        Answers[] answers = new Answers[4];
                        Console.WriteLine("MCQ Exam: ");
                        for (int j = 0; j < 4; j++)
                        {
                            Console.WriteLine($"Enter Answer Text{j + 1}: ");
                            string text = Utility.StringsVAlidation();
                            answers[j] = new Answers(j + 1, text);
                        }

                        int correctNum;
                        do
                        {
                            Console.WriteLine("Enter the Number of the Correct Answer: ");
                        } while (!int.TryParse(Console.ReadLine(), out correctNum) || correctNum < 1 || correctNum > 4);
                        questions[i] = new MCQ_Question(header, body, mark, answers, correctNum);
                    }
                }
            }

            Console.Clear();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Start The Exam!");
            Console.WriteLine("Subject Details: ");
            Console.WriteLine(subject);
            Console.WriteLine();
            Console.WriteLine("Exam Details: ");
            exam.ShowFun();

            Console.WriteLine($"Questions & Answers:");
            int TotalScore = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].ShowQ();
                int UsersAnswer;
                do
                {
                    Console.WriteLine("Enter your answer: ");
                } while (!int.TryParse(Console.ReadLine(), out UsersAnswer));

                user[i] = UsersAnswer;

                if (questions[i] is True_FalseQuestion trueFalseQuestion)
                {
                    if ((trueFalseQuestion.CorrectAnswers && UsersAnswer == 1) || (!trueFalseQuestion.CorrectAnswers && UsersAnswer == 2))
                        TotalScore += trueFalseQuestion.Mark;
                }
                else if (questions[i] is MCQ_Question mcqQuestion)
                {
                    if (UsersAnswer == mcqQuestion.IndexOfRightAnswer)
                        TotalScore += mcqQuestion.Mark;
                }
            }
            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;
            Console.Beep();
            Console.Clear();

            Console.WriteLine("Exam Results:");
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question{i + 1}: ");
                questions[i].ShowQ();
                Console.WriteLine($"Your Answer: {user[i]}");

                if (questions[i] is True_FalseQuestion trueFalseQuestion)
                    Console.WriteLine($"Correct Answer: {(trueFalseQuestion.CorrectAnswers ? 1 : 2)}");
                else if (questions[i] is MCQ_Question mcqQuestion)
                    Console.WriteLine($"Correct Answer: {mcqQuestion.IndexOfRightAnswer}");
            }
            Console.WriteLine();
            Console.WriteLine($"Time taken: {timeTaken.Hours}h {timeTaken.Minutes}m {timeTaken.Seconds}s");
            Console.WriteLine($"Your Get Scored {TotalScore} out of {TotalofMarks}");

            double percentage = (double)TotalScore / TotalofMarks * 100;
            Console.WriteLine($"Your Grade: {percentage:F2}%");
        }
    }
}