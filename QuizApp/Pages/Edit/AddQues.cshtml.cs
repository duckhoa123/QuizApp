using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Pages.Edit
{
    public class AddQuesModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public List<QuizzModel> QuizzModels { get; set; }
        public List<Question> Questions { get; set; }
        [BindProperty]
        public QuestionViewModel QuestionViewModel { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public AddQuesModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<SelectListItem> Options { get; set; }
        public void OnGet(int id)
        {
            if (id == 0) { RedirectToAction("./Index"); }
            Id = id;

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
        {
            var quesmodel = new Question
            {
                Content = QuestionViewModel.Content,
                ChoiceA = QuestionViewModel.ChoiceA,
                ChoiceB = QuestionViewModel.ChoiceB,
                ChoiceC = QuestionViewModel.ChoiceC,
                ChoiceD = QuestionViewModel.ChoiceD,
                CorrectAnswer = QuestionViewModel.CorrectAnswer,
                QuizzId = Id
            };
            _applicationDbContext.Questions.Add(quesmodel);
            _applicationDbContext.SaveChanges();
            TempData["success"] = "Add Question Successfully";
            return RedirectToPage("./Change", new { id = Id });
        }
    }
}
