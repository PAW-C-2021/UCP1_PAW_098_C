using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UPC1_20190140098.Models
{
    public partial class Transaksii
    {
        public Transaksii()
        {
            TableNota = new HashSet<TableNota>();
        }

        public int IdTransaksii { get; set; }
        public int? IdObat { get; set; }
        public int? IdPembeli { get; set; }
        public DateTime? TglTransaksi { get; set; }
        public int? TotalHarga { get; set; }

        public virtual Konsumen IdPembeliNavigation { get; set; }
        public virtual ICollection<TableNota> TableNota { get; set; }
    }
}
