using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace allopromo.Core.Entities
{
    [Table("Cities")]
    public class tCity
    {
        [Key]
        public int cityId { get; set; }
        public string cityName { get; set; }
        public string cityGpsLongitude { get; set; }
        public string cityGpsLatitude { get; set; }


        //public int countryId { get; set; } 
        // ? Remove ? because of belowed property, redundance !

        public virtual tCountry cityCountry { get; set; }
    }
}