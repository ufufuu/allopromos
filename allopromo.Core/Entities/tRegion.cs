using System.ComponentModel.DataAnnotations;
namespace allopromo.Core.Entities
{
    public class tRegion
    {
        [Key]
        public int regionId { get; set; }
        public string regionName { get; set; }
    }
}
