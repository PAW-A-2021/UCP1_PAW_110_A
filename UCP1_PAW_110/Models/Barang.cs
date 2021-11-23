using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_110.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksiis = new HashSet<Transaksii>();
        }

        public string IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int Harga { get; set; }
        public int Kuantitas { get; set; }

        public virtual ICollection<Transaksii> Transaksiis { get; set; }
    }
}
