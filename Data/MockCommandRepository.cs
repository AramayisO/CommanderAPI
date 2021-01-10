using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public class MockCommandRepository : ICommandRepository
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{ Id=0, HowTo="List contents of the current direcotry", Line="dir", Platform="Windows" },
                new Command{ Id=1, HowTo="Print current working directory", Line="pwd", Platform="Unix" },
                new Command{ Id=2, HowTo="Update software", Line="sudo apt update", Platform="Unix" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "List contents of the current direcotry", Line = "dir", Platform = "Windows" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
