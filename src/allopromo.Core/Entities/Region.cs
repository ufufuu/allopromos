using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class Region: Base.BaseEntity
    {
        [Key]
        public int regionId { get; set; }
        public string regionName { get; set; }


        //public DateTime createdDate {get; set;}
        //public Date


        public virtual ICollection <Country> Countries { get; set; } = null!;
    }
}
