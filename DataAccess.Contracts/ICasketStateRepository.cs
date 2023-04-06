using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    /// <summary>
    /// System state storage
    /// </summary>
    public interface ICasketStateRepository
    {
        /// <summary>
        /// Get the system state
        /// </summary>
        /// <returns></returns>
        CasketState GetState();
        
        /// <summary>
        /// Save system state
        /// </summary>
        /// <param name="state"></param>
        void PutState(CasketState state);
    }
}
