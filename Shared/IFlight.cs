

namespace Shared

{
    public interface IFlight
    {
        bool Ciritical { get; set; }
        string? FlightCode { get; set; }
        int Id { get; set; }
        bool IsVisitedOnStation4 { get; set; }
        ILeg? Leg { get; set; }
        int PassengersCount { get; set; }
        Target Target { get; set; }

        void Start(IFlightRoute flightRoute);
    }
}