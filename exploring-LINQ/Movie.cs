using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exploring_LINQ
{
    internal class Movie
    {

        public string Title { get; set; } = "NA";

        public int Year { get; set; }

        public string Director { get; set; } = "NA";

        public List<string> Actors { get; set; } = new List<string>() { "NO_ANSWER_SHOULD_RETURN" };

        public string Genre { get; set; } = "NA";

        public double Rating { get; set; }

        public string RatingCategory { get; set; } = "G";

    }
}
