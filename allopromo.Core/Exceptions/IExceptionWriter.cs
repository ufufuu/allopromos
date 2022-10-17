using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Exceptions
{
    public interface IExceptionWriter
    {
        void WriteException(string ex);
        void WriteException(string ex, int evntId);
    }
}
