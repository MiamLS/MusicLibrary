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
        public ActionResult Get()
        {
            try
            {
                IEnumerable<MusicRecord> musicRecords = _musicRecordRepository.GetAll();
                if (musicRecords == null || musicRecords.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(musicRecords);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MusicRecordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicRecordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
