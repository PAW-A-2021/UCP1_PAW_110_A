using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_110.Models
{
    public partial class Costumer
    {
        public Costumer()
        {
            Transaksiis = new HashSet<Transaksii>();
        }

        public string IdCostumer { get; set; }
        public string NamaCostumer { get; set; }
        public int NomorTelepon { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Transaksii> Transaksiis { get; set; }
    }
}
