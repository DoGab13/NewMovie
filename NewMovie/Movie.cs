using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMovie
{
    class Movie
    {
        public string? Title { get; set; }
        public string? Star { get; set; }
        public string? Director { get; set; }
        public string? Type { get; set; }
        public DateTime? Year { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Star}";
        }
    }

}
