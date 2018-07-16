using System;
using System.Collections.Generic;

namespace moviesapp.Models
{
    public partial class TblCustomers
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DateCreate { get; set; }
    }
}
