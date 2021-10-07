using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccesslayer.Models
{
    public partial class Location
    {
        public Location()
        {
            Jobs = new HashSet<Job>();
        }

        public decimal Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal? Zip { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
