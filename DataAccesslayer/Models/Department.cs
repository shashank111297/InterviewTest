using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccesslayer.Models
{
    public partial class Department
    {
        public Department()
        {
            Jobs = new HashSet<Job>();
        }

        public decimal Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
