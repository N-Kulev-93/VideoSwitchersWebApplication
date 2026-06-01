namespace Application.Read
{
    public class ActionConfiguration
    {
        public int Type { get; set; }
        private int SwitcherId { get; set; }
        public string? CommandTemplate { get; set; }
        public bool Enabled { get; set; }
    }
}
