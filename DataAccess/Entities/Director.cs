﻿#nullable disable
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Director:Record
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsRetired { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
