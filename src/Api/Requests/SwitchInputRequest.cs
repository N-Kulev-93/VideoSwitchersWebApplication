namespace Api.Requests
{
    public class SwitchInputRequest
    {
        /// <summary>
        /// Device identifier.
        /// </summary>
        public required int SwitcherId { get; set; }

        /// <summary>
        /// The position of the input on device.
        /// </summary>
        public required int InputPosition { get; set; }


        /// <summary>
        /// The position of the output on device.
        /// </summary>
        public required int OutputPosition { get; set; }
    }
}
