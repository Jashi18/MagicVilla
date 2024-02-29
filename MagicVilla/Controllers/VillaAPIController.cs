using MagicVilla.Data;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.VillaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<VillaDto> GetVilla(int id )
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.Find(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
             return Ok(villa);
        }

        [HttpPost]
        public ActionResult<VillaDto> CreateVilla ([FromBody]VillaDto villa)
        {
            if (villa == null)
            {
                return BadRequest(villa);
            }

            if(VillaStore.VillaList.Find(u => u.Name == villa.Name) != null)
            {
                ModelState.AddModelError("", "That name already exsist");
                return BadRequest(ModelState);
            }

            villa.Id = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.VillaList.Add(villa);
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla (int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.Find(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            VillaStore.VillaList.Remove(villa);
            return NoContent();
        }


        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.Find(u =>u.Id == id);
            villa.Name = villaDto.Name;
            villa.Occupancy = villaDto.Occupancy;
            villa.Sqft = villaDto.Sqft;
            return NoContent();
        }
    }
}
