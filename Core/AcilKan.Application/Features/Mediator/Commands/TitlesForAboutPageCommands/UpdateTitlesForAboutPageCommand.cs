using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.TitlesForAboutPageCommands
{
    public class UpdateTitlesForAboutPageCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
