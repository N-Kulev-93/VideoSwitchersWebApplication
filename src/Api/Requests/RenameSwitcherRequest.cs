namespace Api.Requests
{
    public class RenameSwitcherRequest
    {
        /// <summary>
        /// Device identifier.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Device new name.
        /// </summary>
        public required string Name { get; set; }
    }
}
