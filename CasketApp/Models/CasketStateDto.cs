using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasketApp.Models
{
    /// <summary>
    /// dto for system state date transfer
    /// </summary>
    public class CasketStateDto
    {
        public CasketStateDto()
        {

        }
        
        /// <summary>
        /// Create using data-layer object
        /// </summary>
        /// <param name="state"></param>
        public CasketStateDto(DataAccess.Contracts.CasketState state)
        {
            if (state == null)
                throw new ArgumentNullException("state");

            Working = state.WorkState == DataAccess.Contracts.WorkState.Working;
            WorkStartTime = state.WorkStartTime;
        }

        /// <summary>
        /// System health status
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// Maintenance start date
        /// </summary>
        public DateTime? WorkStartTime { get; set; }

        /// <summary>
        /// Conversion to date-laer object
        /// </summary>
        /// <returns></returns>
        public DataAccess.Contracts.CasketState ToDataEntity()
        {
            return new DataAccess.Contracts.CasketState { WorkState = Working ? DataAccess.Contracts.WorkState.Working : DataAccess.Contracts.WorkState.NotWorking, WorkStartTime = WorkStartTime, };
        }
    }
}