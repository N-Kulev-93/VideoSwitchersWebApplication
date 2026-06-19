namespace Application.Command
{
    public class SerialPortConfiguration
    {
        public int BaudRate { get; set; } = 19_200;
        public string PortName { get; set; } = "COM1";
        public int Parity { get; set; } = 8;
        public int DataBits { get; set; } = 1;
        public int StopBits { get; set; } = 1;    
    }
}
