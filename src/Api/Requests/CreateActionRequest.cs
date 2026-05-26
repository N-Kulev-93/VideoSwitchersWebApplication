using Application.Domain;

namespace Api.Requests
{
    public class CreateActionRequest
    {
        public required string Name { get; set; }
        public List<ActionCommandParameterType>? CommandParameterTypes { get; set; }
        public bool IsEnabled { get; set; }
    }
}
