

namespace Shared
{
    public interface IAirPortLogic
    {
        Task AddNewFlight(IFlight flight);
       
        AirPortStatus GetStatus();
    }
}