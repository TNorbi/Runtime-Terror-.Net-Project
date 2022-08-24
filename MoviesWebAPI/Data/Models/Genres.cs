using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebAPI.Data.Models
{
    public class Genres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string GenreName { get; set; }
        public ICollection<Movies> Movies { get; set; }
    }
}
