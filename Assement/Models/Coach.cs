using System.ComponentModel.DataAnnotations;

namespace Assement.Models
{
    public class Coach
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please enter the name")]
        public string Name { get; set; }
        public string Specailiztion { get; set; }
        [Required(ErrorMessage = "please enter the ExperenceYear")]
        public int ExperenceYear { get; set; }
        public Team? Team { get; set; }
    }
}
