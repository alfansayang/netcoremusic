using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Web.Models;
using Music.Web.Repository;

namespace Music.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            this._artistRepository = artistRepository;
        }

        [HttpGet]
        [Route("GetArtists")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _artistRepository.Get();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetArtist/{id}")]
        public async Task<IActionResult> GetById(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var data = await _artistRepository.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddPost([FromBody]ArtistModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _artistRepository.Insert(model.ConvertToData());
                    if (data > 0)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeletePost(int id = 0)
        {
            int result = 0;

            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await _artistRepository.Delete(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]ArtistModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _artistRepository.Update(model.ConvertToData());
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}