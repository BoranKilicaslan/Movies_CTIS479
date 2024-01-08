using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short? Year { get; set; }
        [DisplayName("Director")]
        public int? DirectorId { get; set; }

        [DisplayName("Director")]
        public string directorOutput { get; set; }
        public double Revenue { get; set; }
    }
}
