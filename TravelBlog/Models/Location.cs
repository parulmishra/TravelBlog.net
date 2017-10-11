﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<People> Peoples { get; set; }
    }
}
