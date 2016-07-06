using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    /// <summary>
    /// Хранилище состония системы
    /// </summary>
    public interface ICasketStateRepository
    {
        /// <summary>
        /// Получить состояние системы
        /// </summary>
        /// <returns></returns>
        CasketState GetState();
        
        /// <summary>
        /// Сохранить состояние системы
        /// </summary>
        /// <param name="state"></param>
        void PutState(CasketState state);
    }
}
