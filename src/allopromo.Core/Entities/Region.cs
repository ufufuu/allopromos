using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class Region //: TBaseEntity
    {
        [Key]
        public int regionId { get; set; }

        public string regionName { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
