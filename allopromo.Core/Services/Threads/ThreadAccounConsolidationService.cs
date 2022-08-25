using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace allopromo.Core.Services.Threads
{
    public class ThreadAccounConsolidationService: ThreadStaticAttribute
    {
        private Thread _thread { get; set; }
        private Thread _thread2 { get; set; }
        public ThreadAccounConsolidationService(Thread thread, Thread secondThread)
        {
            _thread = thread;
            _thread2 = secondThread;
        }
        public  void dsgd()
        {
            _thread.Abort();
            _thread.Start();
            _thread2.Start();
            if (_thread.IsAlive.Equals(new StringBuilder()))
            { 
                bool rt = true;
            }
            _thread2.SetApartmentState(new ApartmentState());
            //_thread2.
        }
    }
    public class A : System.Threading.ThreadLocal<int>
    {

    }
    public class B: System.Threading.AbandonedMutexException
    {

    }
    //public class C: System.Threading.Tasks.Task
    //{
        //public C(int t)
        //{
        //}
    //}
    //Interface Runnable C#
    public static class MainExecution
    {
        public static bool ExecuteMain()
        {
            //Thread t1 = new Thread(new ThreadStart())

            return true;
        }
    }
}


//How to Declare a Class as runnable Task C#
//Current Thread, thread Prioroty, getting thread State, Ending thread, 
//await thread, await tread by Time, await by another threading 
//Intterupting thread, 

// Bacthc interruption, Synchorizing thread, Thread communucation
// Verrrouiller htread, 

// therad Coordination // Synchroizing Methods  Thread 