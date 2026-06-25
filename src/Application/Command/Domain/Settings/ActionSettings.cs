using Application.Shared.Domain;

namespace Application.Command
{
    public readonly record struct SwitcherActionSettingsKey(int SwitcherId, ActionType Type);

    public class ActionSettings : IEquatable<ActionSettings>
    {
        private int SwitcherId { get; set; }
        public ActionType Type { get; set; }
        public string? SwitcherTemplate { get; set; }
        public bool Enabled { get; set; }
        public SwitcherActionSettingsKey SwitcherKey => new(SwitcherId, Type);

        public ActionDefinition Action { get; set; }

        public override int GetHashCode()
        {
            return SwitcherKey.GetHashCode();
        }

        public bool Equals(ActionSettings? other)
        {
            return other is not null && this.SwitcherKey.Equals(other.SwitcherKey);
        }

        public override bool Equals(object? obj)
        {
            return obj is not null && this.Equals(obj as ActionSettings);
        }
    }
}
