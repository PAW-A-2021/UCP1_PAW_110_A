using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_110.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Transaksiis = new HashSet<Transaksii>();
        }

        public string IdAdmin { get; set; }
        public string Password { get; set; }
        public string NamaAdmin { get; set; }

        public virtual ICollection<Transaksii> Transaksiis { get; set; }
    }
}
