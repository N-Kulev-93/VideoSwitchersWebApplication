using Application.Interface;

namespace Application.Command
{
    public class OpenSwitcherCommunicationCommand(int id) : ICommand
    {
        internal int Id => id;
    }
}
