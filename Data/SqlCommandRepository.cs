﻿using CommanderAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public class SqlCommandRepository : ICommandRepository
    {
        private readonly CommanderContext _commandContext;

        public SqlCommandRepository(CommanderContext commandContext)
        {
            _commandContext = commandContext;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _commandContext.Commands.Add(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commandContext.Commands.Include(c => c.Platform).ToList();
        }

        public Command GetCommandById(int id)
        {
            return _commandContext.Commands.Include(c => c.Platform).FirstOrDefault(p => p.Id == id);
        }

        public void UpdateCommand(Command command)
        {
            // Do nothing
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _commandContext.Commands.Remove(command);
        }

        public bool SaveChanges()
        {
            return (_commandContext.SaveChanges() >= 0);
        }
    }
}
