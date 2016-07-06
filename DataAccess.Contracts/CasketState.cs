using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    /// <summary>
    /// Состояние работоспособности
    /// </summary>
    public enum WorkState
    {
        Working,
        NotWorking,
    }

    /// <summary>
    /// Состояние системы
    /// </summary>
    public class CasketState
    {
        /// <summary>
        /// Состояние работоспособности
        /// </summary>
        public WorkState WorkState { get; set; }

        /// <summary>
        /// Время начала запланированных работ.
        /// Может быть не указано
        /// </summary>
        public DateTime? WorkStartTime { get; set; }
    }
}
