using Microsoft.AspNetCore.Mvc;
using MusicalogApi.Models;
using MusicalogApi.Models.DTO;
using MusicalogApi.Models.Repository;

namespace MusicalogApi.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : Controller
    {
        private readonly IDataRepository<Album, AlbumDto> _dataRepository;

        public AlbumsController(IDataRepository<Album, AlbumDto> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Albums
        [HttpGet]
        public IActionResult Get()
        {
            var albums = _dataRepository.GetAll();
            return Ok(albums);
        }

        // GET: api/Albums/3
        [HttpGet("{id}", Name = "GetAlbum")]
        public IActionResult Get(int id)
        {
            var album = _dataRepository.GetDto(id);
            if (album == null)
            {
                return NotFound("Album not found.");
            }

            return Ok(album);
        }

        // POST: api/Albums
        [HttpPost]
        public IActionResult Post([FromBody] Album album)
        {
            if (album is null)
            {
                return BadRequest("Album is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(album);
            return CreatedAtRoute("GetAlbum", new { Id = album.Id }, null);
        }

        // PUT: api/Albums/3
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Album album)
        {
            if (album == null)
            {
                return BadRequest("Album is null.");
            }

            var albumToUpdate = _dataRepository.Get(id);
            if (albumToUpdate == null)
            {
                return NotFound("The Album couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(albumToUpdate, album);
            return NoContent();
        }

        // DELETE: api/Albums/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var album = _dataRepository.Get(id);
            if (album == null)
            {
                return NotFound("The Album couldn't be found.");
            }

            _dataRepository.Delete(album);
            return NoContent();
        }
    }
}
