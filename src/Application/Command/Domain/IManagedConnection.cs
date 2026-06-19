namespace Application.Command
{
    public interface IManagedConnection
    {
        void Open();
        bool IsOpen { get; }
        void Close();
    }
}
