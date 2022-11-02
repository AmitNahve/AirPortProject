

namespace Shared
{
    public interface ILeg
    {
        IFlight? Flight { get; set; }
        int? FlightId { get; set; }
        int Id { get; set; }
        int NextLegNumber { get; set; }
        int LegNumber { get; set; }
        int StationWatingTime { get; set; }
        Target Target { get; set; }
        Task EnterStation(IFlight flight);
        void ExitStation();
        Task Visit();
    }
}