using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SPDVI_Marta_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        // GET api/Values/GetString
        [AllowAnonymous]
        [HttpGet]
        [Route("GetString")]
        public string GetString()
        {
            return "bla-bla-bla";
        }

        // GET api/Values/GetListOfString
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListOfString")]
        public List<string> GetListOfString()
        {
            List<string> listOfString = new List<string>();
            listOfString.Add("Hello json");
            listOfString.Add("Happy St. Valentines day <3!");

            return listOfString;
        }


        // POST api/Values/PostString
        [AllowAnonymous]
        [HttpPost]
        [Route("PostString")]
        public IHttpActionResult PostString([FromBody]string jsonString)
        {
            Console.WriteLine(jsonString);
            return Ok();
        }


        // POST api/Values/PostListOfString
        [AllowAnonymous]
        [HttpPost]
        [Route("PostListOfString")]
        public IHttpActionResult PostListOfString([FromBody]List<string> jsonListOfString)
        {
            Console.WriteLine(jsonListOfString);
            return Ok();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
