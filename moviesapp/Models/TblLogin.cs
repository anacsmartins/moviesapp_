using System;
using System.Collections.Generic;

namespace moviesapp.Models
{
    public partial class TblLogin
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password_ { get; set; }
        public string Email { get; set; }
    }
}
