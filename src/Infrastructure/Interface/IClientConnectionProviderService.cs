namespace Infrastructure.Interface
{
    /// <summary>
    /// Our clients are always switcher devices, based on result of the upcoming research 
    /// described below the reading interface will remain with identity only 
    /// or with two sepparate implementations of reading implementation for read and write models 
    /// affecting also the names of interface/methods(more generalized - ClientConnection or more explicit SwitcherConnection).
    /// </summary>
    internal interface IClientConnectionProviderService
    {
        /// <summary>
        /// Since the connection is living in memory only while application is alive, how should we use its representation 
        /// in CQRS, should we have sepparate providers for read/write, should we lock it when reading and writing at same time ? Research soon...
        /// </summary>
        IRuntimeCommandConnection? Get(int id);
    }
}
