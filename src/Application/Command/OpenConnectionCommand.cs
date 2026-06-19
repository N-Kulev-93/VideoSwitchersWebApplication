using Application.Interface;

namespace Application.Command
{
    public class OpenConnectionCommand(int id) : ICommand
    {
        internal int Id => id;
    }
}
