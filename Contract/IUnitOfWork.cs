

namespace Contract
{
    public interface IUnitOfWork
    {
        IFlightRepository Flights { get; }
        ILegRepository Legs { get; }
        ILogRepository Logs { get; }
         void Complete();
    }
}
