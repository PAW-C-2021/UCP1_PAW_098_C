using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UPC1_20190140098.Models
{
    public partial class TableNota
    {
        public int IdNota { get; set; }
        public int? IdTransaksi { get; set; }
        public int? TotalHarga { get; set; }

        public virtual TabelTransaksi IdNotaNavigation { get; set; }
        public virtual Transaksii IdTransaksiNavigation { get; set; }
    }
}
