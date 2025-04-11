using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    /// <summary>
    /// Specific query used to fetch count without running in memory
    /// </summary>

    public interface IBasketQueryService
    {
        Task<int> CountTotalBasketItems(string username);
    }
}
