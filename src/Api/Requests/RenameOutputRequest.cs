namespace Api.Requests
{
    public class RenameOutputRequest
    {
        /// <summary>
        /// Device identifier.
        /// </summary>
        public required int SwitcherId { get; set; }

        /// <summary>
        /// The position of the output on device.
        /// </summary>
        public required int Position { get; set; }

        /// <summary>
        /// Output new name.
        /// </summary>
        public required string Name { get; set; }
    }
}
