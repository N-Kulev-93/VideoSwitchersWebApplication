namespace Application.Interface
{
    public interface ICommunicationSource : IDisposable
    {
        void Open();
        bool IsAlive { get; }
        void Close();
        void Execute(string command);
    }
}
