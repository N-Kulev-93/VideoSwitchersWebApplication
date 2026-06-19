using Application.Interface;

namespace Application.Command
{
    public class RenameSwitcherCommand(int id, string name) : ICommand
    {
        internal int Id { get; } = id;
        internal string Name { get; } = name;
    }
}
