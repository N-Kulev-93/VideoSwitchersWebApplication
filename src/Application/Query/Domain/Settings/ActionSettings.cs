namespace Application.Query
{
    public readonly record struct SwitcherActionSettingsKey(int SwitcherId, int Type);

    public class ActionSettings : IEquatable<ActionSettings>
    {
        private int SwitcherId { get; set; }
        public int Type { get; set; }
        public string? CommandTemplate { get; set; }
        public bool Enabled { get; set; }
        public SwitcherActionSettingsKey Key => new(SwitcherId, Type);

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public bool Equals(ActionSettings? other)
        {
            return other is not null && this.Key.Equals(other.Key);
        }

        public override bool Equals(object? obj)
        {
            return obj is not null && this.Equals(obj as ActionSettings);
        }
    }
}
