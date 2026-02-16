using Assement.Models;
using System.ComponentModel.DataAnnotations;

namespace Assement.Dtos
{
    public class TeamCreateDto
    {
        [Required(ErrorMessage = "please enter the name")]
        public string Name { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "please enter the CoachId")]
        public int CoachId { get; set; }
        
    }
}
