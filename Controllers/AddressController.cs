using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoremIpsumLogistica.Models;
using UserManageAPI.Services;

namespace UserManageAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressesByUserId(int userId)
        {
            var addresses = await _addressService.GetAddressesByUserIdAsync(userId);
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> AddAddress([FromBody] Address address)
        {
            var newAddress = await _addressService.AddAddressAsync(address);
            return CreatedAtAction(nameof(GetAddressById), new { id = newAddress.Id }, newAddress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> UpdateAddress(int id, [FromBody] Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            var updatedAddress = await _addressService.UpdateAddressAsync(address);
            if (updatedAddress == null)
            {
                return NotFound();
            }

            return Ok(updatedAddress);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await _addressService.DeleteAddressAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
