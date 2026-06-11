namespace Application.Command
{
    public class ActionConfiguration
    {
        private int SwitcherId { get; set; }
        public ActionType Type { get; set; }
        public string? CommandTemplate { get; set; }
        public bool Enabled { get; set; }
    }
}
