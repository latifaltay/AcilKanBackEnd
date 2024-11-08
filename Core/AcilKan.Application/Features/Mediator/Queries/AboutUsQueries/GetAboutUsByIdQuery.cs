﻿using AcilKan.Application.Features.Mediator.Results.AboutUsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.AboutUsQueries
{
    public class GetAboutUsByIdQuery(int id) : IRequest<GetAboutUsByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
