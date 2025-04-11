using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Caching
{
    /// <summary>
    /// Cache Manager Interface
    /// </summary>
    public interface ICacheBase:IDisposable
    {
        Task Clear(bool publisher = true);
    }
}
