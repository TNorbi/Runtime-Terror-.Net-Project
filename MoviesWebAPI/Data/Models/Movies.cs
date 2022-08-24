using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebAPI.Data.Models
{
    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Mov_Id { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public double Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public string? Description { get; set; }

        public ICollection<Genres> Genres { get; set; }

        public ICollection<Ratings> UserRating { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
