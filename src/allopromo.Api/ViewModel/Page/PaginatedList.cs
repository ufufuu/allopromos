using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allopromo.Api.Model.ViewModel.Page
{
    //public class PaginatedList<T>: List<T> // where T:class
    //{
    //    public int _pageIndex { get; set; }
    //    public double _totalPages { get; set; }
    //    public int totalPages { get; set; }
    //    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    //    {
    //        _pageIndex = pageIndex;
    //        _totalPages = (int)Math.Ceiling(count /(double)_pageIndex);
    //        totalPages = count / _pageIndex;
    //        this.AddRange(items);
    //    }
    //    public bool HasPrevious => _pageIndex>1;
    //    public bool hasNext => _pageIndex < _totalPages;
    //    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, 
    //        int pageIndex, 
    //        int pageSize)
    //    {
    //        var count = await source.CountAsync();
    //        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
    //        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    //    }
    //}
    public class PaginatedList<T>
    {

    }
}
