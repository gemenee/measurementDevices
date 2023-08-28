using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Dtos;

namespace Application.Contracts.Interfaces
{
    public interface IVerificationService
    {
        Task<IEnumerable<ExpiredDeviceDto>> GetDevicesWithExpiredVerification(string deviceCategory, int? consumerId);
    }
}