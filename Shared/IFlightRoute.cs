
namespace Shared
{
    public interface IFlightRoute
    {
         List<ILeg>? Legs { get; set; }
        IAirPortLogic AirPort { get; set; }

        IEnumerable<ILeg> GetNextStation();
    }
}