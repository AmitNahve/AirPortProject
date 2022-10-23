using Models;
using Shared;

namespace BL.Services
{
    public interface ILegService
    {
        IEnumerable<LegStatus> GetStatus();
        IEnumerable<ILeg> GetLegs();
    }
}