using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    public class SelectQuizzModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public List<QuizzModel> QuizzModels { get; set; }
        public SelectQuizzModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void OnGet()
        {
            var pro = from m in _applicationDbContext.QuizzModels
                      select m;
            QuizzModels= pro.ToList();


        }
    }
}
