using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.ArticlesForAboutPageCommands
{
    public class CreateArticlesForAboutPageCommand : IRequest
    {
        public int TitleId { get; set; }
        public string Article { get; set; }
    }
}
