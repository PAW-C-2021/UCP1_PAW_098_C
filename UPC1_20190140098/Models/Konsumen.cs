using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UPC1_20190140098.Models
{
    public partial class Konsumen
    {
        public Konsumen()
        {
            PetugasApotek = new HashSet<PetugasApotek>();
            Transaksii = new HashSet<Transaksii>();
        }

        public int IdPembeli { get; set; }
        public string PasswordPembei { get; set; }
        public string UsernamePembeli { get; set; }

        public virtual ICollection<PetugasApotek> PetugasApotek { get; set; }
        public virtual ICollection<Transaksii> Transaksii { get; set; }
    }
}
