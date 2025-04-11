using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Events.Handlers
{
    public class OrderPlacedHandler : IObserver<string>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(string value)
        {
        }
    }
}
