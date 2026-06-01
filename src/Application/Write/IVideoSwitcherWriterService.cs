using Application.Write;
using System;
namespace Application.Write
{
    public interface IVideoSwitcherWriterService
    {
        Task WriteAsync(VideoSwitcher videoSwitcher);
    }

}
