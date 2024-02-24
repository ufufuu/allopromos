using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Model
{
    public class BaseApiEntityModel
    {
        [Key]
        public string Id { get; set; }
    }
    //public partial class BaseApiEntityModel
    //{
    //    [Key]
    //    public string Id { get; set; }
    //}
}
