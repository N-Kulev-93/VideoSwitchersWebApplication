using System.Diagnostics.CodeAnalysis;

namespace Application.Write
{
    public class ConnectionConfiguration
    {
        public ConnectionType Type { get; set; }
        public string? SettingsJSON { get; set; }


        [MemberNotNullWhen(returnValue: true, member: "SettingsJSON")]
        public bool IsComplete => !Type.Equals(ConnectionType.None) && !string.IsNullOrWhiteSpace(SettingsJSON); // We have to validate the settings model in the domain somehow...must refactor.
    }
}
