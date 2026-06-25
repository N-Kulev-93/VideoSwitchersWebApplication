using Application.Interface;

namespace Application
{
    public class ActionCommandProcessor
    {
        readonly IActionCommandHandlerProvider _handlerProvider;

        public ActionCommandProcessor(IActionCommandHandlerProvider handlerProvider)
        {
            _handlerProvider = handlerProvider;
        }


        public void Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            //TODO: queue here or what ?


            var handler = _handlerProvider.Get<TCommand>();
            if (handler is null)
                return;

            handler.Handle(command);
        }
    }
}
