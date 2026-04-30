namespace Application.Command.Domain
{

    public enum ActionParameterType
    {
        None = 0,
        InputPosition = 1,
        OutputPosition = 2,

    }
    public class ActionParameter
    {
        public string N { get; set; }
    }

    public class ActionDeviceSettings
    {
        public required string Template { get; set; }
        public int MyProperty { get; set; }
    }

    public class ActionSettings
    {
        internal ActionType Type { get; set; }


        public int SwitcherId { get; set; }
        public ActionDeviceSettings? DeviceSettings { get; set; }
    }
}
