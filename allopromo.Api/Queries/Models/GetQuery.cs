using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Queries.Models
{
    public class GetQuery<T>: IRequest<IQueryable<T>> where T:class
    {
        public string Id { get; set; }
    }
}
