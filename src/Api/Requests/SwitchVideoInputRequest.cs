namespace Api.Requests
{
    public class SwitchVideoInputRequest
    {
        public int Id { get; set; }
        public int OutputPosition { get; set; }
        public int InputPosition { get; set; }
    }
}
