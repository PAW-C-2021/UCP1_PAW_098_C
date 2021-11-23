using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UPC1_20190140098.Models
{
    public partial class PetugasApotek
    {
        public int IdApoteker { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int? IdObat { get; set; }
        public int? IdPembeli { get; set; }

        public virtual TabelObat IdObatNavigation { get; set; }
        public virtual Konsumen IdPembeliNavigation { get; set; }
    }
}
