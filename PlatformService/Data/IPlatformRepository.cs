using PlatformService.API.Models;
using System.Collections.Generic;

namespace PlatformService.API.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);

        void CreatePlatform(Platform platform);
    }
}
