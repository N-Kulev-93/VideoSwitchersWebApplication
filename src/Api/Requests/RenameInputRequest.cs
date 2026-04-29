namespace Api.Requests
{
    public class RenameInputRequest
    {

        /// <summary>
        /// Device identifier.
        /// </summary>
        public required int SwitcherId { get; set; }

        /// <summary>
        /// The position of the input on device.
        /// </summary>
        public required int Position { get; set; }

        /// <summary>
        /// Input new name.
        /// </summary>
        public required string Name { get; set; }
    }
}
