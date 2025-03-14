﻿using AcilKan.Application.Features.Mediator.Results.CityResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.CityQueries
{
    public class GetCityByIdQuery(int id) : IRequest<GetCityByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
