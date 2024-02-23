using RiddlesAPI.Models;
using RiddlesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace RiddlesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiddlesController : ControllerBase
    {
        private readonly RiddlesService _riddlesService;

        public RiddlesController(RiddlesService riddlesService) =>
            _riddlesService = riddlesService;

        [HttpGet]
        public async Task<List<Riddles>> Get() =>
            await _riddlesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Riddles>> Get(string id)
        {
            var riddles = await _riddlesService.GetAsync(id);

            if (riddles is null)
            {
                return NotFound();
            }

            return riddles;
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<Riddles>> GetByNumber(int number)
        {
 
            var riddles = await _riddlesService.GetByNumberAsync(number);

            if (riddles is null)
            {
                return NotFound();
            }

            return riddles;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Riddles newRiddles)
        {
            await _riddlesService.CreateAsync(newRiddles);

            return CreatedAtAction(nameof(Get), new { id = newRiddles.Id }, newRiddles);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Riddles updatedRiddles)
        {
            var riddles = await _riddlesService.GetAsync(id);

            if (riddles is null)
            {
                return NotFound();
            }

            updatedRiddles.Id = riddles.Id;

            await _riddlesService.UpdateAsync(id, updatedRiddles);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var riddles = await _riddlesService.GetAsync(id);

            if (riddles is null)
            {
                return NotFound();
            }

            await _riddlesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
