﻿using AcilKan.Application.Features.Mediator.Results.AboutResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutByIdQuery(int id) : IRequest<GetAboutByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}