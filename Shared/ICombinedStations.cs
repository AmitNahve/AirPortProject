

namespace Shared
{
    public interface ICombinedStations
    {
        List<ILeg>? Stations { get; set; }

        Task VisitStation(IFlight flight);
        
    }
}