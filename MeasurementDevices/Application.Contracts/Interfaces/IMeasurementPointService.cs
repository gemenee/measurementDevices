using System.Threading.Tasks;

namespace Application.Contracts.Interfaces
{
    public interface IMeasurementPointService
    {
        public Task<int> AddMeasurementPointAsync(
            string name,
            int consumerId,
            int voltageTransformerId,
            int currentTransformerId,
            int ElectricityMeterId);
    }
}
