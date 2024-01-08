#nullable disable

using DataAccess.Base;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Genre: Record
    {
        [MaxLength(75)]
        public string Name { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }
    }
}
