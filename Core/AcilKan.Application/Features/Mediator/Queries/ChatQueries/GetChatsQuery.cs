using AcilKan.Application.Features.Mediator.Results.ChatResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.ChatQueries
{
    public class GetChatsQuery(int toUserId) : IRequest<List<GetChatQueryResult>>
    {
        public int ToUserId { get; set; } = toUserId;
    }
}
