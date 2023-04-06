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
    /// System state controller
    /// Exposes information and saves the state.
    /// Controller is a part of business-logic layer. It is reasonable in our case as we have very small amount of business logic.
    /// </summary>
    public class CasketStateController : ApiController
    {
        private readonly ICasketStateRepository casketStateRepository;

        public CasketStateController()
            /// TODO    Use DI, current implementation requires unnesessary references to storage implementation asembly and doesn't allow to mock this implementation
            : this(DataAccess.Simple.CasketStateRepository.Instance)
        {

        }
        
        /// <summary>
        /// This is the right ctor - repository dependency should be injected from outside
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

            //  If system isn't working then there is no sence in saving scheduled maintenance start date
            //  This is a business logic and should be tested separately.
            //      To do this one could create a service performing this work, or implement it inside domain system state entity (not a dto and not a data-layer object).
            if (state.WorkState == WorkState.NotWorking)
                state.WorkStartTime = null;

            casketStateRepository.PutState(state);
        }
    }
}
