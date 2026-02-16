using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Assement.Models
{
    [Index("Name",IsUnique = true)]
    public class Team
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter the name")]
        public string Name { get; set; }
        public string City { get; set; }
        public int CoachId { get; set; }    
        public Coach? Coach { get; set; }
        public List<Player>? Player { get; set; }
        public List<Competion>? Competions { get; set; }
    }
}
