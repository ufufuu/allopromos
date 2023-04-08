using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tRegion
    {
        [Key]
        public int RegionId { get; set; }
        public string regionName { get; set; }

        public virtual ICollection <tCountry> Countries { get; set; } = null!;
    }
}
