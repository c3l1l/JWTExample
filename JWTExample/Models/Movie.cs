using System;
using System.Collections.Generic;

namespace JWTExample.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = null!;
        public string Director { get; set; } = null!;
        public int Duration { get; set; }
        public DateTime DateReleased { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
