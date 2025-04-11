using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.Events
{


    //public class OrderPlaced: IObservable<TEntity> where TEntity class

    public class OrderPlaced : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderPlacedHandler : IObserver<string>
    {
        public void OnCompleted()
        {
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            //throw new NotImplementedException();
        }
    }
}
