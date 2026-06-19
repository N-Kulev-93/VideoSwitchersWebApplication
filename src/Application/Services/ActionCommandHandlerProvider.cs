using Application.Command;
using Application.Interface;

namespace Application.Services
{
    public class ActionCommandHandlerProvider : IActionCommandHandlerProvider
    {
        readonly IServiceProvider _serviceProvider;

        public ActionCommandHandlerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;    
        }

        public ICommandHandler<TCommand>? Get<TCommand>() where TCommand : ActionCommand
        {
            var handler =  _serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
            return handler is not null ? (ICommandHandler<TCommand>)handler : null;
        }
    }
}
