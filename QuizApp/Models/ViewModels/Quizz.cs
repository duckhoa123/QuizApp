using static System.Net.Mime.MediaTypeNames;

namespace QuizApp.Models.ViewModels
{
    public class Quizz
    {
        public int QuestionId  { get; set; }
        public char Choice { get; set; } = 'O';
        public char CorrectAnswer { get; set; }
        public int Score
        {
            get
            {
                if (Choice != CorrectAnswer)
                    return 0;
                else return 1;
            }
        }
        public Quizz() { }
        public Quizz(Question question)
        {
            QuestionId = question.Id;
            CorrectAnswer = question.CorrectAnswer;
           
           
        }
    }
}
