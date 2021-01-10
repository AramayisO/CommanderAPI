using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public class SqlCommandRepository : ICommandRepository
    {
        private readonly CommandContext _commandContext;

        public SqlCommandRepository(CommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commandContext.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _commandContext.Commands.FirstOrDefault(p => p.Id == id);
        }
    }
}
