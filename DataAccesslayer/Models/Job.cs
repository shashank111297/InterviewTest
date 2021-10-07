using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccesslayer.Models
{
    public partial class Job
    {
        public decimal Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? LocationId { get; set; }
        public decimal? DepartmentId { get; set; }
        public DateTime? PostedDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
    }
}
