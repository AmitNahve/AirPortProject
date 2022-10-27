

namespace Shared
{
    public interface IAirPortLogic
    {
        Task AddNewFlight(IFlight flight);

        List<LegStatus> GetStatus();
        List<IFlight> GetFlights();
    }
}