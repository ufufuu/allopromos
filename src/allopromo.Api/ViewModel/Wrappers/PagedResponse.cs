using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Model.Wrappers
{
    public class PagedResponse<T> :Response<T>
    {
        public int _pageNumber { get; set; }
        public int _pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
        public Uri firstPage { get; set; }
        public Uri lastPage { get; set; }
        public Uri nextPage { get; set; }
        public Uri previousPage { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize):base(data)
        {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _data = data;
            Message = String.Empty;
            Succeeded = true;
            Errors = null;
        }
    }
}
