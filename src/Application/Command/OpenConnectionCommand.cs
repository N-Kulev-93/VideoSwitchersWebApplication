using Application.Write;

namespace Application.Command
{
    public class OpenConnectionCommand(int id) : ActionCommand
    {
        internal int Id => id;
        public override ActionType ActionType => ActionType.OpenConnection;
    }
}
