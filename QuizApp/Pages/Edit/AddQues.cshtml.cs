using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Edit
{
    public class AddQuesModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public List<QuizzModel> QuizzModels { get; set; }
        public Question Questions { get; set; }
        public AddQuesModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void OnGet()
        {
           
        }
    }
}
