namespace Application.Command
{
    public class SwitcherSettings
    {
        public required CommunicationSettings Communication { get; set; }
        public required Dictionary<SwitcherActionSettingsKey, ActionSettings> Actions { get; set; }
    }
}
