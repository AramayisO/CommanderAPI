using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public interface ICommandRepository
    {
        void CreateCommand(Command command);
     
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        void UpdateCommand(Command command);

        bool SaveChanges();
    }
}
