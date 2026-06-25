using Application.Command;
using Application.Interface;

namespace Infrastructure.Services
{
    internal class DbWriter : IWriter
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public VideoSwitcher? Read(int id)
        {
            throw new NotImplementedException();
        }

        public void SoftWrite(VideoSwitcher videoSwitcher)
        {
            throw new NotImplementedException();
        }

        public void Write(VideoSwitcher videoSwitcher)
        {
            throw new NotImplementedException();
        }
    }
}
