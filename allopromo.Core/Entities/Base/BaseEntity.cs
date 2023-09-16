using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Entities.Base
{
    public class BaseEntity:IBaseEntity
    {
        public virtual DateTime createdDate { get; set; }
        public virtual DateTime? updatedDate { get; set; } // Canoot Declare a Static Type nullable ?
    }
}
