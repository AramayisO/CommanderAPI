using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public class SqlPlatformRepository : IPlatformRepository
    {
        private readonly CommanderContext _commanderContext;

        public SqlPlatformRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _commanderContext.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _commanderContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _commanderContext.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePlatform(Platform platform)
        {
            // Do nothing
        }

        public void DeletePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _commanderContext.Platforms.Remove(platform);
        }
        
        public bool SaveChanges()
        {
            return (_commanderContext.SaveChanges() >= 0);
        }
    }
}
