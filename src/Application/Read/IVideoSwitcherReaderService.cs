namespace Application.Read
{
    public interface IVideoSwitcherReaderService
    {
        Task<IQueryable<VideoSwitcher>> ReadAsync();
    }
}
