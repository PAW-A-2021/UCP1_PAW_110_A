using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_110.Models
{
    public partial class Transaksii
    {
        public string IdTransaksi { get; set; }
        public string IdAdmin { get; set; }
        public string IdBarang { get; set; }
        public string IdCostumer { get; set; }
        public int Bayar { get; set; }
        public int Total { get; set; }
        public int Kembalian { get; set; }
        public int Tanggal { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Barang IdBarangNavigation { get; set; }
        public virtual Costumer IdCostumerNavigation { get; set; }
    }
}
