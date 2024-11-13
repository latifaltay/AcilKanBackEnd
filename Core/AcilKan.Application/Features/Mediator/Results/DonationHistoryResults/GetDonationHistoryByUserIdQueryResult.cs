using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.DonationHistoryResults
{
    public class GetDonationHistoryByUserIdQueryResult
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string PatientFullName { get; set; }
    }
}
