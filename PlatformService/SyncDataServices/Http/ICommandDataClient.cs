using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    // This is a factory for HTTP requests between Services. We use factory to easily recreate failing requests
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}