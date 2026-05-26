using Application.Domain;

namespace Api.Requests
{
    

    public class ConfigureActionRequest
    {
        public int SwitcherId { get; set;}
        public ActionType Type { get; set; }
        public required bool IsEnabled { get; set; }
        /// <summary>
        /// Null -> command not supported on device or IsEnabled is false.
        /// </summary>
        public required string? Template { get; set; }
    }
}
