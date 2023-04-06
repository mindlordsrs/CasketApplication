using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Simple
{
    /// <summary>
    /// Trial implementation of a system state repository.
    /// This is a singleton that stores the state in memory, so when you reboot the system, you will have to publish the state again.
    /// </summary>
    public class CasketStateRepository : ICasketStateRepository
    {
        #region [ Singleton instance ]

        private static CasketStateRepository instance = new CasketStateRepository();
        public static CasketStateRepository Instance { get { return instance; } }

        private CasketStateRepository()
        {

        }

        #endregion

        private CasketState casketState = GetDefaultState();

        /// <summary>
        /// Default state - system is in working state, maintenance works aren't planned
        /// </summary>
        /// <returns></returns>
        private static CasketState GetDefaultState()
        {
            return new CasketState 
            {
                WorkState = WorkState.Working, 
                WorkStartTime = null, 
            };
        }

        /// <summary>
        /// Get the system state
        /// </summary>
        /// <returns></returns>
        public CasketState GetState()
        {
            return casketState;
        }

        /// <summary>
        /// Save the system state
        /// </summary>
        /// <param name="state"></param>
        public void PutState(CasketState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            casketState = state;
        }
    }
}
