using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Pages.Quizzes
{
    public class TakeQuizzModel : PageModel
    {
		private readonly ApplicationDbContext _applicationDbContext;
        [BindProperty]
        public List<char> ListQuizz { get; set; }
        [BindProperty]
        public List<Question> Questions { get; set; }

     
        

        public TakeQuizzModel(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public void OnGet(int id)
        {
            if (id == 0) { RedirectToAction("./SelectQuizz"); }
            
            
            
            Questions =  _applicationDbContext.Questions.Where(c => c.QuizzId == id).ToList();
            List<Quizz> quizzes = HttpContext.Session.GetJson<List<Quizz>>("Quizzes");
          
                quizzes= new List<Quizz>();
                foreach (var item in Questions)
                {
                    quizzes.Add(new Quizz(item));

                }
                HttpContext.Session.SetJson("Quizzes", quizzes);

            
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
            HttpContext.Session.Remove("Quizzes");

            int TotalScore = quizzes.Sum(x => x.Score);
          

            return RedirectToPage("/Score/Index", new { score = TotalScore, quesNum = quizzes.Count });
        }
    }
}
