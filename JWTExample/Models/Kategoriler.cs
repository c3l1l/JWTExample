using System;
using System.Collections.Generic;

namespace JWTExample.Models
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            Filmlers = new HashSet<Filmler>();
        }

        public int KatId { get; set; }
        public string KategoriAdi { get; set; } = null!;

        public virtual ICollection<Filmler> Filmlers { get; set; }
    }
}
