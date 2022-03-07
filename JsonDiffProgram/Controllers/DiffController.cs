using JsonDiffProgram.DiffStorage;
using JsonDiffProgram.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonDiffProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        private readonly ILogger<DiffController> _logger;
        private readonly IDiffStorage _storage;

        public DiffController(ILogger<DiffController> logger,
        IDiffStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        //Return item result (DIFF)
        [HttpGet("{id}")]
        public async Task<ActionResult<DiffResultDto>> GetItem(int id)
        {
            try
            {
                var result = await _storage.GetDiff(id);
                var itemDto = new DiffResultDto
                {
                    DiffResultType = result.ResultCode.ToString(),
                    Diffs = result.Diffs,
                };

                return Ok(itemDto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //Remove item
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            if (await _storage.Remove(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Set left Base64-encoded value
        [HttpPut("{id}/left")]
        public async Task<ActionResult> SetLeft(int id, [FromBody] DiffDtos diffData)
        {
            try
            {
                await _storage.SetLeft(id, diffData.Data);
                return Created(string.Empty, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Set right Base64-encoded value
        [HttpPut("{id}/right")]
        public async Task<ActionResult> SetRight(int id, [FromBody] DiffDtos diffData)
        {
            try
            {
                await _storage.SetRight(id, diffData.Data);
                return Created(string.Empty, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
