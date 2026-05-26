namespace Api.Requests
{
    public class ConnectionSettingsDto
    {
        public int Type { get; set; }
        public string SettingsJSON { get; set; }
    }
    public class ActionSettingsDto
    {
        public int Type { get; set; }
        public bool IsEnabled { get; set; }
        public string? SwitcherTemplate { get; set; }
    }
    public class UpdateVideoSwitcherRequest
    {
        public string Name { get; set; }
        public ConnectionSettingsDto? ConnectionSettings { get; set; }
        public IEnumerable<ActionSettingsDto> ActionsSettings { get; set; }
    }
}
