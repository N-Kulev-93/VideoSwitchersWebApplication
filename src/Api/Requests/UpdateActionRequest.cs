using Application.Domain;

namespace Api.Requests
{
    public class UpdateActionRequest
    {
        public string Name { get; set;  }
        public List<ActionCommandParameterType>? CommandParameterTypes { get; set; }
        public bool MyProperty { get; set; }
    }
}
