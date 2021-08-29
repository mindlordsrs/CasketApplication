using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Simple
{
    /// <summary>
    /// Пробная реализация репозитория для хранения состояния системы.
    /// Это синглтон, который хранит состояние впамяти, так что при перезагрузке системы придется публиковать состояние заново.
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
        /// Default state - system is in working state, support works aren't planned
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
        /// Получить состояние системы
        /// </summary>
        /// <returns></returns>
        public CasketState GetState()
        {
            return casketState;
        }

        /// <summary>
        /// Сохранить состояние системы
        /// </summary>
        /// <param name="state"></param>
        public void PutState(CasketState state)
        {
            if (state == null)
                throw new ArgumentNullException("state");

            casketState = state;
        }
    }
}
