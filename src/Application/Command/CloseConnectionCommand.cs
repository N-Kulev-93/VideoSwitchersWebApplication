using Application.Write;

namespace Application.Command
{
    public class CloseConnectionCommand(int id) : ActionCommand
    {
        public override ActionType ActionType => ActionType.CloseConnection;
        internal int Id { get; } = id;
    }
}
