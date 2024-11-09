using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.TitlesForAboutPageCommands
{
    public class CreateTitlesForAboutPageCommand : IRequest
    {
        public string Title { get; set; }
    }
}
