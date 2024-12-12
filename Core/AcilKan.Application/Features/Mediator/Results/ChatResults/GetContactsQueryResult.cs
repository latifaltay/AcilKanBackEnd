using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.ChatResults
{
    public class GetContactsQueryResult
    {
        public string UserFullName { get; set; }
        public DateTime SendDate { get; set; }
        public string LastMessageInfo { get; set; }
        public int ToUserId { get; set; }
    }
}
