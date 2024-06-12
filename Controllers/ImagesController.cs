using HotelListingAPI.Models;
using HotelListingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListingAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            var images = await _imageService.GetImagesAsync();
            return Ok(images);
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> CreateImage(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdImage = await _imageService.CreateImageAsync(image);
            return CreatedAtAction(nameof(GetImage), new { id = createdImage.Id }, createdImage);
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedImage = await _imageService.UpdateImageAsync(id, image);
            if (updatedImage == null)
            {
                return NotFound();
            }
            return Ok(updatedImage);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var deleted = await _imageService.DeleteImageAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
