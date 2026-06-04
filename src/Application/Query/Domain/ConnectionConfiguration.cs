namespace Application.Read
{
    public class ConnectionConfiguration
    {
        private int SwitcherId { get; set; }
        public int Type { get; set; }
        public string? SettingsJSON { get; set; }
    }

    public class SerialPortConfiguration
    {
        public int BaudRate { get; set; }
        public string PortName { get; set; }
        public int Parity { get; set; }
        public int DataBits { get; set; }
        public int StopBits { get; set; }
    }
}
