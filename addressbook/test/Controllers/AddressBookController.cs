using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Datas;

namespace test.Controllers
{
    [Route("api/addressbook")]
    public class AddressBookController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult getAll()
        {
            return new JsonResult(AddressesDataStore.current.LAddesses);
        }
        [HttpGet("{id}")]
        public IActionResult getAddress(int id)
        {
            var rtn= AddressesDataStore.current.LAddesses.FirstOrDefault(c => c.iID == id);
            if (rtn == null)
            {
                return NotFound();
            }
            return Ok(rtn);
        }
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
