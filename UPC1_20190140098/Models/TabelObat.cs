using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UPC1_20190140098.Models
{
    public partial class TabelObat
    {
        public TabelObat()
        {
            PetugasApotek = new HashSet<PetugasApotek>();
        }

        public int IdObat { get; set; }
        public int? Harga { get; set; }
        public string JenisObat { get; set; }
        public string NamaObat { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<PetugasApotek> PetugasApotek { get; set; }
    }
}
