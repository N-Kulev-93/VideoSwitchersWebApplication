namespace Application.Command
{
    public record SerialPortSettings
    {
        public int BaudRate { get; set; } = 19_200;
        public string PortName { get; set; } = "COM1";
        public int Parity { get; set; } = 8;
        public int DataBits { get; set; } = 1;
        public int StopBits { get; set; } = 1;    
    }
    
    public record TelnetSettings
    {
    }

    /// <summary>
    /// This implementation is temporary hack until time is present 
    /// for revising most suitable impolementation for this case.
    /// </summary>
    public record ConnectionConfiguration
    {
        private int SwitcherId { get; set; }
        /// <summary>
        /// Private setters used by entity framework during iitialization,
        /// static method constructor when switching type runtime
        /// </summary>
        public ConnectionType Type { get; private set; }
        public string SettingsJSON { get; private set; }

    }
}
