using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WebServer.Data;
using WebServer.Model;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultRepo adultService;

        public AdultController(IAdultRepo adultService)
        {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] string name)
        {
            try
            {
                IList<Adult> adults = await adultService.GetAdultsAsync();

                if (name != null)
                {
                    int i = 0;
                    while (i < adults.Count)
                    {
                        if (!(adults[i].FirstName.Contains(name) || adults[i].LastName.Contains(name)))
                        {
                            adults.RemoveAt(i);
                        }
                        else
                        {
                            i++;
                        }
                    }
                }

                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> PostAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await adultService.AddAdultAsync(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await adultService.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> PatchAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updateAdult = await adultService.UpdateAdultAsync(adult);
                return Ok(updateAdult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}