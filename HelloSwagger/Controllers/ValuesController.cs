using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloSwagger.Controllers
{
   [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("{apiVersion:regex(v3)}")]
        public string Get(int id)
        {
            return "value";
        }

       [Route("{apiVersion:regex(v3)}")]
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        [Route("{apiVersion:regex(v3)}")]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("{apiVersion:regex(v3)}")]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
