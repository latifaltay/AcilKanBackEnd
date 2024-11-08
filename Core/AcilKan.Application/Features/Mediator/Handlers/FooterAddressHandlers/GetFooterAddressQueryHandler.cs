using AcilKan.Application.Features.Mediator.Queries.FooterAddressQueries;
using AcilKan.Application.Features.Mediator.Results.FooterAddressResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetFooterAddressQueryResult
            {
                Id = x.Id,
            }).ToList();
        }
    }
}
