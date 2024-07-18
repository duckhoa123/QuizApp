using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
	public class Question
	{
		[Key]
		public int Id { get; set; }
		[Required, MinLength(4, ErrorMessage = "Please provide question")]
		public string Content { get; set; }

		[Required(ErrorMessage = "Please provide choice A")]
		public string ChoiceA { get; set; }
		[Required(ErrorMessage = "Please provide choice B")]
		public string ChoiceB { get; set; }
		[Required(ErrorMessage = "Please provide choice C")]
		public string ChoiceC { get; set; }
		[Required(ErrorMessage = "Please provide choice D")]
		public string ChoiceD { get; set; }
		[Required(ErrorMessage = "Please provide correct result")]
		public char CorrectAnswer {  get; set; }

	}
}
