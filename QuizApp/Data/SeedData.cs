using Microsoft.EntityFrameworkCore;
using QuizApp.Migrations;
using QuizApp.Models;

namespace QuizApp.Data
{
    public class SeedData
    {
        public static void SeedingData(ApplicationDbContext _context)
        {
            _context.Database.Migrate();
            if (!_context.Questions.Any())
            {
               
                _context.Questions.AddRange(
                    new Question { Content = "What is the longest that an elephant has ever lived? (That we know of)", ChoiceA = "17 years", ChoiceB = "49 years", ChoiceC = "86 years", ChoiceD = "142 years", CorrectAnswer = 'C', QuizzId = 1 },
                    new Question { Content = "Who wrote the novel \"1984\"?", ChoiceA = "George Orwell", ChoiceB = "J.K. Rowling", ChoiceC = "F. Scott Fitzgerald", ChoiceD = "Ernest Hemingway", CorrectAnswer = 'A', QuizzId = 1 },
                    new Question { Content = "What is the capital city of Australia?", ChoiceA = "Sydney", ChoiceB = "Melbourne", ChoiceC = "Canberra", ChoiceD = "Brisbane", CorrectAnswer = 'C', QuizzId = 1 },
                    new Question { Content = "What is the chemical symbol for Gold?", ChoiceA = "Gd", ChoiceB = "Go", ChoiceC = " Ag", ChoiceD = "Au", CorrectAnswer = 'D', QuizzId = 1 },
                    new Question { Content = "In what year was the first iPhone released?", ChoiceA = "2005", ChoiceB = "2007 ", ChoiceC = "2008", ChoiceD = "2010", CorrectAnswer = 'B', QuizzId = 1 },
                    new Question { Content = "What is the national bird of the United States?", ChoiceA = "Eagle", ChoiceB = "Bald Eagle", ChoiceC = "Condor", ChoiceD = "Pigeon", CorrectAnswer = 'A', QuizzId = 2 },
                    new Question { Content = "Who directed the movie \"Jurassic Park\"?", ChoiceA = "Steven Spielberg", ChoiceB = "George Lucas", ChoiceC = "Michael Bay", ChoiceD = "Stanley Kubrick", CorrectAnswer = 'A', QuizzId = 2 },
                   new Question { Content = "What language is spoken in Brazil?", ChoiceA = "Spanish", ChoiceB = "Portuguese", ChoiceC = "English", ChoiceD = "French", CorrectAnswer = 'B', QuizzId = 2 },
                   new Question { Content = "What is sushi traditionally wrapped in?", ChoiceA = "Rice Paper", ChoiceB = "Seaweed", ChoiceC = "Bamboo", ChoiceD = "Lettuce", CorrectAnswer = 'B', QuizzId = 2 },
                   new Question { Content = "What is the main ingredient in hummus?", ChoiceA = "Potatoes", ChoiceB = "Lentils", ChoiceC = "Chickpeas", ChoiceD = "White Beans", CorrectAnswer = 'C', QuizzId = 2 }
                    );
                _context.QuizzModels.AddRange(
                    new QuizzModel {Name= "General Questions #1" },
                    new QuizzModel { Name = "General Questions #2" }

                    );
               _context.SaveChanges();
            }
        }
    }
}
