using allopromo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allopromo.Core.Interfaces
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current customer
        /// </summary>
        ApplicationUser GetCurrentUser();
        /// <summary>
        /// Gets the current customer
        /// </summary>
        Customer CurrentCustomer { get; }

        /// <summary>
        /// Set the current customer by Middleware
        /// </summary>
        /// <returns></returns>
        Task<Customer> SetCurrentCustomer();
    }
}
