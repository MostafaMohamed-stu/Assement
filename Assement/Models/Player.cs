using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Assement.Models
{
    [Index("Name",IsUnique = true)]
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter the name")]
        public string Name { get; set; }
        public string Postion { get; set; }
        public int age { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
