using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Datas;
using test.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace test.Controllers
{
    [Route("api/addressbook")]
    public class AddressBookController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult index()
        {
            return new JsonResult(AddressesDataStore.current.LAddesses);
        }
        [HttpGet("{id}", Name = "returnaddress")]
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

        // POST api/values
        [HttpPost("add")]
        public IActionResult addAddress([FromBody]AddressInputDTO AddressRequest)
        {
            if (AddressRequest == null)
                return BadRequest();
            var MaxID = AddressesDataStore.current.LAddesses.Max(p => p.iID);
            var rtnAddress = new AddressDTO()
            {
                iID = ++MaxID,
                sName = AddressRequest.sName,
                sPhoneNumber = AddressRequest.sPhoneNumber,
                sAddress = AddressRequest.sAddress,
                sMoreInfo = AddressRequest.sMoreInfo

            };
            AddressesDataStore.current.LAddesses.Add(rtnAddress);
            return CreatedAtRoute("returnaddress", new { id = rtnAddress.iID }, rtnAddress);
        }

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

        [HttpPatch("{id}")]
        public IActionResult updateAddress(int id, [FromBody]JsonPatchDocument<AddressInputDTO> patch)
        {
            if (patch == null)
                return BadRequest();
            var vAddress = AddressesDataStore.current.LAddesses.FirstOrDefault(p => p.iID == id);
            if (vAddress == null)
                return NotFound();
            var rtnAddress = new AddressInputDTO()
            {
                sName = vAddress.sName,
                sPhoneNumber = vAddress.sPhoneNumber,
                sAddress=vAddress.sAddress,
                sMoreInfo=vAddress.sMoreInfo
            };
            patch.ApplyTo(rtnAddress, ModelState);
            if (!ModelState.IsValid)
                return BadRequest();
            vAddress.sName = rtnAddress.sName;
            vAddress.sPhoneNumber = rtnAddress.sPhoneNumber;
            vAddress.sAddress = rtnAddress.sAddress;
            vAddress.sMoreInfo = rtnAddress.sMoreInfo;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteAddress(int id)
        {
            var vAddress = AddressesDataStore.current.LAddesses.FirstOrDefault(p => p.iID == id);
            if (vAddress == null)
                return NotFound();
            AddressesDataStore.current.LAddesses.Remove(vAddress);
            return NoContent();
        }
    }
}
