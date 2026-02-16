using System.ComponentModel.DataAnnotations;

namespace Assement.Models
{
    public class Competion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter the Title")]
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
