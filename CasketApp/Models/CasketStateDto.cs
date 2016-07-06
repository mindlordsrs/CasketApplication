using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasketApp.Models
{
    /// <summary>
    /// ДТО для передачи информации о состоянии системы
    /// </summary>
    public class CasketStateDto
    {
        public CasketStateDto()
        {

        }
        
        /// <summary>
        /// Создание из объекта слоя данных
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
        /// Признак работоспособности системы
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// Время начала запланированных работ
        /// </summary>
        public DateTime? WorkStartTime { get; set; }

        /// <summary>
        /// Преобразование в объект слоя данных
        /// </summary>
        /// <returns></returns>
        public DataAccess.Contracts.CasketState ToDataEntity()
        {
            return new DataAccess.Contracts.CasketState { WorkState = Working ? DataAccess.Contracts.WorkState.Working : DataAccess.Contracts.WorkState.NotWorking, WorkStartTime = WorkStartTime, };
        }
    }
}