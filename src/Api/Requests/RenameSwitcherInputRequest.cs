namespace Api.Requests
{
    public class RenameSwitcherInputRequest
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
    }
}
