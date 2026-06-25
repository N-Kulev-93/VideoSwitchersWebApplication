using Application.Command;
using System;
namespace Application.Interface
{

    public interface IWriter : ISwitcherWriter, ISettingsWriter<SerialPortSettings>, ISettingsWriter<TelnetSettings>;
    public interface ISwitcherWriter : IWriter<VideoSwitcher>, IManualCommitWriter<VideoSwitcher>;
    public interface ISettingsWriter<TCommunicationSettings> : IWriter<SwitcherSettings>;
    public interface ISerialPortSettingsWriter : ISettingsWriter<SerialPortSettings>;

    public interface IManualCommitWriter<TEntity>
    {
        /// <summary>
        ///  This shoudne be exposed to domain layer, check how to refactor 
        ///  it only on infra level since the transactional logic is infrastructure concern.
        /// </summary>
        /// <param name="videoSwitcher"></param>
        /// <returns></returns>
        void SoftWrite(VideoSwitcher videoSwitcher);
        void Commit();
    }

    public interface IWriter<TEntity>
    {
        /// <summary>
        /// Command targeted video switcher.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        VideoSwitcher? Read(int id);
        void Write(VideoSwitcher videoSwitcher);
    }
}
