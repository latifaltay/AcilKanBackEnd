using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodDonationResults
{
    public class GetBloodDonationByDonorIdQueryResult
    {
        public int Id { get; set; }
        public DateTime DonationDate { get; set; }
        public string HospitalName { get; set; }
        public string PatientFullName { get; set; }
        public string DonorFullName { get; set; }
        public string RequesterFullName { get; set; }
        public string Status { get; set; }
    }
}
