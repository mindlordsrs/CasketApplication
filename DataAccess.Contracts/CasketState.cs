using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    /// <summary>
    /// System health status
    /// </summary>
    public enum WorkState
    {
        Working,
        NotWorking,
    }

    /// <summary>
    /// System state
    /// </summary>
    public class CasketState
    {
        /// <summary>
        /// System health status
        /// </summary>
        public WorkState WorkState { get; set; }

        /// <summary>
        /// Scheduled maintenance time.
        /// Can be null
        /// </summary>
        public DateTime? WorkStartTime { get; set; }
    }
}
