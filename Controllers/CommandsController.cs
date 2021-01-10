using CommanderAPI.Models;
using CommanderAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommanderAPI.Dtos;

namespace CommanderAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _commandMapper;

        public CommandsController(ICommandRepository commandRepository, IMapper commandMapper)
        {
            _commandRepository = commandRepository;
            _commandMapper = commandMapper;
        }


        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _commandRepository.GetAllCommands();
            return Ok(_commandMapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _commandRepository.GetCommandById(id);

            if (command != null)
            {
                return Ok(_commandMapper.Map<CommandReadDto>(command));
            }

            return NotFound();
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _commandMapper.Map<Command>(commandCreateDto);
            _commandRepository.CreateCommand(commandModel);
            
            if (_commandRepository.SaveChanges())
            {
                var commandReadDto = _commandMapper.Map<CommandReadDto>(commandModel);
                return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
            }

            return BadRequest();
        }
    }
}
