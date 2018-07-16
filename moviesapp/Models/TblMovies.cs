using System;
using System.Collections.Generic;

namespace moviesapp.Models
{
    public partial class TblMovies
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
    }
}
