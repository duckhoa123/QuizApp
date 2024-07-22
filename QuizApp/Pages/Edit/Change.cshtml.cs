using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Pages.Edit
{
    public class ChangeModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        [BindProperty]
        public List<char> ListQuizz { get; set; }
        [BindProperty]
        public List<Question> Questions { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public EditViewModel EditViewModel { get; set; }

        public List<SelectListItem> Options { get; set; }
        public ChangeModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void OnGet(int id)
        {
            if (id == 0) { RedirectToAction("./Index"); }
            Id = id;
            ViewData["id"]= Id;
           Questions = _applicationDbContext.Questions.Where(c => c.QuizzId == id).ToList();
            Options = new List<SelectListItem>
        {
            new SelectListItem { Value = "A", Text = "A" },
            new SelectListItem { Value = "B", Text = "B" },
            new SelectListItem { Value = "C", Text = "C" },
            new SelectListItem { Value = "D", Text = "D" }
        };

        }
        public IActionResult OnPost()
        {if(EditViewModel!=null)
            {
                var editques = _applicationDbContext.Questions.Find(EditViewModel.Id);
                if(editques!=null)
                {
                    editques.Content=EditViewModel.Content;
                    editques.ChoiceA=EditViewModel.ChoiceA;
                    editques.ChoiceB = EditViewModel.ChoiceB;
                    editques.ChoiceC = EditViewModel.ChoiceC;
                    editques.ChoiceD = EditViewModel.ChoiceD;
                    editques.CorrectAnswer=EditViewModel.CorrectAnswer;
                    _applicationDbContext.SaveChanges();
                   


                }
            }
            return RedirectToPage("./Change", new { id = Id }); 


        }
    }
}
