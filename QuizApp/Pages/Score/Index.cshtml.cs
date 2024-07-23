using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizApp.Pages.Score
{
    public class IndexModel : PageModel
	{
		public int Score { get; set; }
		public int QuesNum { get; set; }
		public int Id { get; set; }
		public string QuizzName { get; set; }
        public void OnGet(int id,string quizzname,int score, int quesNum)
		{
			Score = score;
			QuesNum = quesNum;
			QuizzName = quizzname;
			Id = id;


        }
    }
}
