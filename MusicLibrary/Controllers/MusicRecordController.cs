using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using MusicLibrary.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FrontendPolicy")]
    public class MusicRecordController : ControllerBase
    {
        private readonly MusicRecordRepository _musicRecordRepository;
        public MusicRecordController(MusicRecordRepository musicRecordRepository)
        {
            _musicRecordRepository = musicRecordRepository;
        }

        // GET: api/<MusicRecordController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MusicRecord>> Get(
    [FromQuery] string? title = null,
    [FromQuery] string? artist = null)
        {
            IEnumerable<MusicRecord> musicRecords =
                _musicRecordRepository.GetAll(title, artist);

            return Ok(musicRecords);
        }



        // GET api/<MusicRecordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult<MusicRecord> Post([FromBody] MusicRecord musicRecord)
        {
            try
            {
                _musicRecordRepository.Add(musicRecord);
                return Created($"api/MusicRecord/{musicRecord.Id}", musicRecord);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MusicRecordController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<MusicRecord> Put(int id, [FromBody] MusicRecord value)
        {
            var updatedRecord = _musicRecordRepository.Update(id, value);
            if (updatedRecord == null)
            {
                return NotFound();
            }
            return Ok(updatedRecord);
        }

        // DELETE api/<MusicRecordController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            MusicRecord? deletedRecord = _musicRecordRepository.Delete(id);

            if (deletedRecord == null)
            {
                return NotFound(); // Return 404 Not Found 
            }

            return NoContent(); // Return 204 No Content to indicate successful deletion
        }

    }
}
