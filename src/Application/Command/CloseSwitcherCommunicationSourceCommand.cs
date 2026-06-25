using Application.Interface;

namespace Application.Command
{
    public class CloseSwitcherCommunicationSourceCommand(int id) : ICommand
    {
        internal int Id { get; } = id;
    }
}
