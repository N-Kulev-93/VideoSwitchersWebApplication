namespace Application.Query
{
    public class SerialPortSettings : CommunicationSettings
    {
        public int BaudRate { get; set; }
        public string PortName { get; set; }
        public int Parity { get; set; }
        public int DataBits { get; set; }
        public int StopBits { get; set; }
    }
}
