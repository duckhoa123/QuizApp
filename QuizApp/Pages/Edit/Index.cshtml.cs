using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Edit
{
    public class IndexModel : PageModel
    {
		private readonly ApplicationDbContext _applicationDbContext;
		public List<QuizzModel> QuizzModels { get; set; }
		public IndexModel(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public void OnGet()
		{
			var pro = from m in _applicationDbContext.QuizzModels
					  select m;
			QuizzModels = pro.ToList();


		}
	}
}
