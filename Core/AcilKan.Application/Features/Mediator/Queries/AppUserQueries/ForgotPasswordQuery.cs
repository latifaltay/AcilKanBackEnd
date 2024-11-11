using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.AppUserQueries
{
    public class ForgotPasswordQuery(string email) : IRequest<ForgotPasswordQueryResult>
    {
        public string Email { get; set; } = email;
    }
}
