using Application.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IActionCommandHandlerProvider
    {
        ICommandHandler<TCommand> Get<TCommand>() where TCommand : ActionCommand;
    }
}
