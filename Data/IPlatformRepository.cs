using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public interface IPlatformRepository
    {
        void CreatePlatform(Platform platform);

        IEnumerable<Platform> GetAllPlatforms();

        Platform GetPlatformById(int id);

        void UpdatePlatform(Platform platform);

        void DeletePlatform(Platform platform);

        bool SaveChanges();
    }
}
