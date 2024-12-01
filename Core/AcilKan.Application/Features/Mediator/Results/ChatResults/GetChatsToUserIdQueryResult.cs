using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.ChatResults
{
    public class GetChatsToUserIdQueryResult
    {
        public string ToUserFullName { get; set; }
        public List<MessageInfo> MessageInfo { get; set; }
    }
}
