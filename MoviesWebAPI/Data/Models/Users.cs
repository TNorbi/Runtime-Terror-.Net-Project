using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebAPI.Data.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Gender { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Ratings> UserRating { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
