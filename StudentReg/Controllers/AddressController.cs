using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentReg.DataAccess;
using StudentReg.Services.Models;
using StudentReg.Services.Students;
using AutoMapper;
using StudentReg.Models;
using Microsoft.AspNetCore.Authorization;

namespace StudentReg.Controllers
{
    [Authorize]
    [Route("api/student/{studentId}/address")]
    [Controller]
    public class AddressController : Controller
    {
        private readonly IStudentRepository _service;
        private readonly IMapper _mapper;

        public AddressController(IStudentRepository service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        
        [HttpGet("{addressId}", Name = "GetAddress")]
        public IActionResult GetAddress(int addressId, int studentId)
        {
            var address = _service.GetAddress(studentId, addressId);

            if (address is null)
            {
                return NotFound();
            }

            var mappedAddress = _mapper.Map<AddressDto>(address);

            return Ok(mappedAddress);

        }
        [HttpGet]
        public ActionResult<ICollection<AddressDto>> GetAddresses(int studentId)
        {
            var address = _service.GetAddresses(studentId);
            if (address is null)
            {
                return NotFound();
            }
            var mappedAddress = _mapper.Map<ICollection<AddressDto>>(address);

            return Ok(mappedAddress);
        }

        [HttpPost]
        public ActionResult<Address> AddAddress(int studentId, [FromBody] CreateAddressDto address)
        {
            var mappedAddress = _mapper.Map<Address>(address);

            var newAddress = _service.AddAddress(studentId, mappedAddress);

            var addressForReturn = _mapper.Map<AddressDto>(newAddress);

            return CreatedAtRoute("GetAddresses", new { studentId = studentId, id = addressForReturn.AddressId }, addressForReturn);
        }

        [HttpPut("{addressId}")]
        public ActionResult UpdateAddress(int studentId,int addressId, [FromBody]UpdateAddressDto address)
        {
            var updateAddress = _service.GetAddress(studentId, addressId);

            _mapper.Map(address, updateAddress);

            _service.UpdateAddress(updateAddress);

            return NoContent();
            
        }

        [HttpDelete("{addressId}")]
        public ActionResult DeleteAddress(int studentId,int addressId)
        {
            var address = _service.GetAddress(studentId,addressId);

            _service.DeleteAddress(address);

            return NoContent();
        }

    }
}
