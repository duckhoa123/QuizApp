using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Pages.Quizzes
{
    public class IndexModel : PageModel
    {
		private readonly ApplicationDbContext _applicationDbContext;
		public ListQuizz ListQuizz { get; set; }
        public List<Question> Questions { get; set; }

		public IndexModel(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public void OnGet()
        {
            List<Quizz> quizzes =  new List<Quizz>();
            var data = from m in _applicationDbContext.Questions
                       select m;
            Questions=data.ToList();
            foreach (var item in data)
            {
                quizzes.Add(new Quizz(item));

            }
            HttpContext.Session.SetJson("Quizzes", quizzes);
            ListQuizz = new()
            {
                Quizz = quizzes,
                TotalScore = quizzes.Sum(x => x.Score)
            };
            

        }
        public async Task<IActionResult> OnPostAnsAsync(int id,char choice)
        {
            Console.WriteLine("khoa");
            List<Quizz> quizzes = HttpContext.Session.GetJson<List<Quizz>>("Quizzes") ?? new List<Quizz>();
            Quizz quizz = quizzes.Where(c => c.QuestionId == id).FirstOrDefault();
            quizz.Choice = choice;
            HttpContext.Session.SetJson("Quizzes", quizzes);
            ListQuizz = new()
            {
                Quizz = quizzes,
                TotalScore = quizzes.Sum(x => x.Score)
            };
            return RedirectToPage("./Index");
        }
    }
}
