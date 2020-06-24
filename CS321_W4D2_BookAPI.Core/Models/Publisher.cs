using System;
using System.Collections.Generic;

namespace CS321_W4D2_BookAPI.Core.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundedYear { get; set; }
        public string CountryOfOrigin { get; set; }
        public string HeadQuartersLocation { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

