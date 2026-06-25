namespace Application.Interface
{
    public interface IActionCommandHandlerProvider
    {
        ICommandHandler<TCommand> Get<TCommand>() where TCommand : ICommand;
    }
}
