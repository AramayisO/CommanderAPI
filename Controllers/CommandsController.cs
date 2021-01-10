using CommanderAPI.Models;
using CommanderAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;

        public CommandsController(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command >> GetAllCommands()
        {
            var commands = _commandRepository.GetAllCommands();
            return Ok(commands);
        }

        // /GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _commandRepository.GetCommandById(id);
            return Ok(command);
        }
    }
}
