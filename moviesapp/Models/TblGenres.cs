using System;
using System.Collections.Generic;

namespace moviesapp.Models
{
    public partial class TblGenres
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string DateCreate { get; set; }
        public int? Active { get; set; }
    }
}
