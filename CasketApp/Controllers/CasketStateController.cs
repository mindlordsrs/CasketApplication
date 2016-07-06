using CasketApp.Filters;
using CasketApp.Models;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CasketApp.Controllers
{
    /// <summary>
    /// Контроллер состояния системы
    /// Предоставляет информацию и сохраняет состояние.
    /// Контроллер является слоем бизнес-логики. В нашем случае это оправданно, так как логики почти нет.
    /// </summary>
    public class CasketStateController : ApiController
    {
        private readonly ICasketStateRepository casketStateRepository;

        public CasketStateController()
            /// TODO    Использовать DI, текущая реализация приводит в ненужным ссылкам на сборку реализации хранилища, и не позволяет подменять эту реализацию
            : this(DataAccess.Simple.CasketStateRepository.Instance)
        {

        }
        
        /// <summary>
        /// Это правильный конструктор - репозиторий должен передаваться снаружи как зависимость
        /// </summary>
        /// <param name="casketStateRepository"></param>
        public CasketStateController(ICasketStateRepository casketStateRepository)
        {
            if (casketStateRepository == null)
                throw new ArgumentNullException("casketStateRepository");

            this.casketStateRepository = casketStateRepository;
        }

        // GET api/casketstate
        public CasketStateDto GetCasketState()
        {
            return new CasketStateDto(casketStateRepository.GetState());
        }

        // POST api/casketstate
        [ValidateHttpAntiForgeryToken]
        public void PostCasketState(CasketStateDto value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var state = value.ToDataEntity();

            //  Если система не работает, то нет смысла сохранять дату начала работ
            //  Это бизнес-логика, и её было бы неплохо протестить.
            //      Для этого можно было бы создать сервис, который выполнял бы работу, или реализовать её внутри доменного объекта состояния (это не ДТО и не объект слоя данных).
            if (state.WorkState == WorkState.NotWorking)
                state.WorkStartTime = null;

            casketStateRepository.PutState(state);
        }
    }
}
