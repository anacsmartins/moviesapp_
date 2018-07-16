using System;
using System.Collections.Generic;

namespace moviesapp.Models
{
    public partial class TblLocation
    {
        public int LocationId { get; set; }
        public string DateLocation { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
    }
}
