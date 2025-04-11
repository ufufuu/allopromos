using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Services.Base.ICommand
{

    /* Understanding Command Pattern Implementation and the difference bt/wn implementation 
     * trhough a Service Class ?
     */
    // System Analysis and Design ?
    // Use-case Analysis and Design ?
    public interface ICommand
    {
        void Execute();
    }
    public class AddUserTransaction : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
