using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public class Players
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Country { get; set; }
        [NotMapped]
        public int line { get; set; }
    }
}
