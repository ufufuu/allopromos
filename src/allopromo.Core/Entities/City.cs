using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace allopromo.Core.Entities
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int cityId { get; set; }

        public string cityName { get; set; }

        public virtual Country cityCountry { get; set; }
    }
}