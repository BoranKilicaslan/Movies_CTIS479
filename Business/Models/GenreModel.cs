using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Movice numbers")]
        public int MovieCountOutput { get; set; }

        public List<int> MovieIdsInput { get; set; }

        [DisplayName("Movies")]
        public string MovieNamesOutput { get; set; }
    }
}
