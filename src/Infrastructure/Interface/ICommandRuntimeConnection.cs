using Application.Command.Domain;

namespace Infrastructure.Interface
{
    internal interface ICommandRuntimeConnection : IDisposable
    {
        void Execute(string command);

        void Close();
    }
}
