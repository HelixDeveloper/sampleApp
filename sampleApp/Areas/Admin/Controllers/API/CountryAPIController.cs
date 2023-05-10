using sampleApp.Areas.Admin.Data.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sampleApp.Areas.Admin.Controllers.API
{
    public class CountryAPIController : ApiController
    {
        [HttpPost]
        public bool addNewCountry(Country c) {
            return c.addNewCountry();
        }

        [HttpDelete]
        public bool removeCountry(Country c) {
            return c.removeCountry();
        }

        [HttpPut]
        public bool updateCountry(Country c)
        {
            return c.updateCountry();
        }

        [HttpGet]
        public List<Country> getCountries() {
            Country c = new Country();
            return c.GetCountries();
        }
    }
}
