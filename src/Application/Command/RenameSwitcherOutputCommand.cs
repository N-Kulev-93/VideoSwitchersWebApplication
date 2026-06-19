using Application.Interface;

namespace Application.Command
{
    public class RenameSwitcherOutputCommand(int id, int position, string name) : ICommand
    {
        internal int Id { get; } = id;
        internal int Position { get; } = position;
        internal string Name { get; } = name;
    }
}
