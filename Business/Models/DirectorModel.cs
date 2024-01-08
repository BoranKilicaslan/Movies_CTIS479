using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DirectorModel
    {
        public int Id { get; set; }

        [DisplayName("Director")]


        [Required(ErrorMessage = "{0} is required!")]

        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
        // Way 5:
        [MinLength(3, ErrorMessage = "{0} must be minimum {1} characters!")]
        [MaxLength(10, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }



        [DisplayName("Movies")]
        public List<Movie> Movies { get; set; }


        [DisplayName("Surname")]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        [DisplayName("Movie number that belongs to director")]
        public int MovieCountOutput { get; set; }

        [DisplayName("Retired or not?")]
        public string IsRetiredOutput { get; set; }
        public bool IsRetired { get; set; }


    }
}
