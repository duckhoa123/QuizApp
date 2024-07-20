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
        [BindProperty]
        public List<char> ListQuizz { get; set; }
        [BindProperty]
        public List<Question> Questions { get; set; }

		public IndexModel(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public void OnGet()
        {
            var data = from m in _applicationDbContext.Questions
                       select m;
            Questions = data.ToList();
            List<Quizz> quizzes = HttpContext.Session.GetJson<List<Quizz>>("Quizzes");
            if (quizzes==null)
            {
                quizzes= new List<Quizz>();
                foreach (var item in data)
                {
                    quizzes.Add(new Quizz(item));

                }
                HttpContext.Session.SetJson("Quizzes", quizzes);

            }
            ListQuizz= new List<char>(quizzes.Count);
            int TotalScore = quizzes.Sum(x => x.Score);
            ViewData["Score"] = TotalScore.ToString();



        }
        public async Task<IActionResult> OnPost()
        {
            List<Quizz> quizzes = HttpContext.Session.GetJson<List<Quizz>>("Quizzes");
            for(int i=0;i<quizzes.Count;i++)
            {
                quizzes[i].Choice = ListQuizz[i];
            }
            HttpContext.Session.SetJson("Quizzes", quizzes);


           int TotalScore = quizzes.Sum(x => x.Score);
            ViewData["Score"] = TotalScore.ToString();







            return RedirectToPage("./Index");
        }
    }
}
