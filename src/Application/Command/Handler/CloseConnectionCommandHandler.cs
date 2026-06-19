using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command.Handler
{
    internal class CloseConnectionCommandHandler : ICommandHandler<CloseConnectionCommand>
    {
        public Task Handle(CloseConnectionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
