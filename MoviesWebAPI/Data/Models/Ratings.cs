using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesWebAPI.Data.Models
{
    public class Ratings
    {
        [Key,Column(Order= 0)]
        public int UserId { get; set; }

        [Key,Column(Order=1)]
        public int Mov_Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Users User { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Movies Movie { get; set; }

        public int Rating { get; set; }
    }
}
