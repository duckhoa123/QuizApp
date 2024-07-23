using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Models.ViewModels;
using System.Linq;

namespace QuizApp.Pages.Quizzes
{
    public class TakeQuizzModel : PageModel
    {
		private readonly ApplicationDbContext _applicationDbContext;
        [BindProperty]
        public List<char> ListQuizz { get; set; }
        [BindProperty]
        public List<Question> Questions { get; set; }
        public string Quizzname { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        public TakeQuizzModel(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public void OnGet(int id)
        {
            if (id == 0) { RedirectToAction("./SelectQuizz"); }

            Id = id;
             Quizzname = _applicationDbContext.QuizzModels.Where(c => c.Id == Id).First().Name;
            List<Quizz> quizzes = HttpContext.Session.GetJson<List<Quizz>>("Quizzes"+Id.ToString());
            //Questions =  _applicationDbContext.Questions.Where(c => c.QuizzId == id).ToList();
            if (quizzes == null)
            {

                var questions = _applicationDbContext.Questions.Where(c => c.QuizzId == id).ToList();
                var random = new Random();

                for (int i = questions.Count - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    var temp = questions[i];
                    questions[i] = questions[j];
                    questions[j] = temp;
                }

                
                HttpContext.Session.SetJson("Questions"+Id.ToString(), questions);

                quizzes = new List<Quizz>();
                foreach (var item in questions)
                {
                    quizzes.Add(new Quizz(item));

                }
                HttpContext.Session.SetJson("Quizzes" + Id.ToString(), quizzes);
            }
            Questions = HttpContext.Session.GetJson<List<Question>>("Questions" + Id.ToString());


            ListQuizz = new List<char>(quizzes.Count);
            
            ViewData["Id"] = id.ToString();
       }
        public async Task<IActionResult> OnPost()
        {
            List<Quizz> quizzes = HttpContext.Session.GetJson<List<Quizz>>("Quizzes" + Id.ToString());
            for(int i=0;i<quizzes.Count;i++)
            {
                quizzes[i].Choice = ListQuizz[i];
            }
          
            HttpContext.Session.Remove("Quizzes" + Id.ToString());

            int TotalScore = quizzes.Sum(x => x.Score);
            string Quizzname = _applicationDbContext.QuizzModels.Where(c => c.Id == Id).First().Name;



            return RedirectToPage("/Score/Index", new {id=Id, quizzname=Quizzname, score = TotalScore, quesNum = quizzes.Count });
        }
    }
}
