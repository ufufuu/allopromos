using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Entities.Base
{
    public class BaseEntity:IBaseEntity
    {
        public string Id { get; set; }

        public static explicit operator BaseEntity(Task<List<tDepartment>> v)
        {
            throw new NotImplementedException();
        }
    }
}
