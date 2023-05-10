using sampleApp.Areas.Admin.Data.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sampleApp.Areas.Admin.Controllers.API
{
    public class StateAPIController : ApiController
    {

        [HttpGet]
        public List<State> getStates() {
            State s = new State();
            return s.GetStates();
        }

        [HttpPut]
        public bool updateState(State s) {
            return s.updateState();
        }

        [HttpDelete]
        public bool removeState(State s)
        {
            return s.removeState();
        }

        [HttpPost]
        public bool addNewState(State s)
        {
            return s.addNewState();
        }
    }
}
