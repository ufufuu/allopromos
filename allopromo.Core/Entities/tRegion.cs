using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tRegion: Base.BaseEntity
    {
        [Key]
        public int regionId { get; set; }
        public string regionName { get; set; }


        //public DateTime createdDate {get; set;}
        //public Date


        public virtual ICollection <tCountry> Countries { get; set; } = null!;
    }
}
