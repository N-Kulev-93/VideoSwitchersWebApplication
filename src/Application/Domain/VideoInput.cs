namespace Application.Domain
{
    public class VideoInput
    {
        public required int Position { get; set; }
        public required string Name { get; set; }  
        public required int SwitcherId { get; set; }
    }
}
