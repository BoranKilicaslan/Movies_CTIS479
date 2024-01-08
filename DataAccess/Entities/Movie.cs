#nullable disable
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Base;

namespace DataAccess.Entities
{
    public class Movie:Record
    {
        [MaxLength(150)]
        public string Name { get; set; }
        public short? Year { get; set; }
        public double Revenue { get; set; }
        public int? DirectorId { get; set; }
        public Director Director { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
