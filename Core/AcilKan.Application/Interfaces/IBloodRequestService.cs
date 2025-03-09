using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IBloodRequestService
    {
        Task<BloodRequest> GetBloodRequestWithDetailsByIdAsync(int id);
        Task<List<BloodRequest>> GetBloodRequestsAsync();
        Task<BloodRequest> GetRequesterUserIdByBloodRequestIdAsync(int id);
        Task<bool> IsActiveAndBloodRequestStatusByTCAsync(string tc);
        Task<List<BloodRequest>> GetBloodRequestsByUserIdAsync(int userId);



    }
}
