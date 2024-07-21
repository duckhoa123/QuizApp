using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class QuizzModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
