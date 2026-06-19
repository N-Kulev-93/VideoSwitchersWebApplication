using Application.Interface;

namespace Application.Command
{
    public class CloseConnectionCommand(int id) : ICommand
    {
        internal int Id { get; } = id;
    }
}
