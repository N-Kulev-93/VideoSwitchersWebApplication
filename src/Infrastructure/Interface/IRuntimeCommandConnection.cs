using Application.Write.Domain;

namespace Infrastructure.Interface
{
    internal interface IRuntimeCommandConnection : IManagedConnection, IDisposable
    {
        void Execute(string command);
    }
}
