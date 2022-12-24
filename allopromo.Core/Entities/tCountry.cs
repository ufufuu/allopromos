using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allopromo.Core.Entities
{
    [Table("Countries")]
    public class tCountry
    {
        [Key]
        public int countryId { get; set; }
        public string countryName { get; set; }
        public int countryRegionId { get; set; }

        public tRegion Region { get; set; }
        public List<tCity> Cities { get; set; }
    }
}

