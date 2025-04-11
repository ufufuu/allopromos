using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allopromo.Core.Entities
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int countryId { get; set; }
        public string countryName { get; set; }

        [ForeignKey("regionId")]
        public virtual Region Region { get; set; } = null !;
        public virtual List<City> Cities { get; set; } = null !;


    }
}





