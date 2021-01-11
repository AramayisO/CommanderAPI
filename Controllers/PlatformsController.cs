using AutoMapper;
using CommanderAPI.Data;
using CommanderAPI.Dtos;
using CommanderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Controllers
{
    [ApiController]
    [Route("api/platforms")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        // GET api/platforms
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            var platforms = _platformRepository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        // GET api/platforms/{id}
        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platform = _platformRepository.GetPlatformById(id);

            if (platform == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        // POST api/platforms
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _platformRepository.CreatePlatform(platformModel);

            if (_platformRepository.SaveChanges())
            {
                var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
                return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
            }

            return BadRequest();
        }

        // PUT api/platforms/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlatform(int id, PlatformUpdateDto platformUpdateDto)
        {
            var platformFromRepo = _platformRepository.GetPlatformById(id);

            if (platformFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(platformUpdateDto, platformFromRepo);
            _platformRepository.UpdatePlatform(platformFromRepo);
            _platformRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/platforms/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(int id)
        {
            var platformFromRepo = _platformRepository.GetPlatformById(id);

            if (platformFromRepo == null)
            {
                return NotFound();
            }

            _platformRepository.DeletePlatform(platformFromRepo);
            _platformRepository.SaveChanges();

            return NoContent();
        }
    }
}
