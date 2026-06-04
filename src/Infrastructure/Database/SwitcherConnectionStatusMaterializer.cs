using Application.Read;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.PortableExecutable;
using IStatusService = Infrastructure.Interface.ISwitcherConnectionStatusService;
using ReadContextVideoSwitcher = Application.Read.VideoSwitcher;
using WriteContextVideoSwitcher = Application.Write.VideoSwitcher;

namespace Infrastructure.Database
{
    internal class SwitcherWriteConnectionStatusMaterializer : IMaterializationInterceptor
    {
        public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
        {
            var switcherInstance = instance as WriteContextVideoSwitcher;
            if (switcherInstance is not null)
            {
                var statusService = materializationData.Context.GetService<IStatusService>();

                switcherInstance.IsOnline = statusService.HasOpenConnection(switcherInstance.Id);

                return switcherInstance;
            }
            
            return instance;
        }
    }

    internal class SwitcherReadConnectionStatusMaterializer : IMaterializationInterceptor
    {
        public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
        {
            var switcherInstance = instance as ReadContextVideoSwitcher;
            if (switcherInstance is not null)
            {
                var statusService = materializationData.Context.GetService<IStatusService>();

                switcherInstance.IsOnline = statusService.HasOpenConnection(switcherInstance.Id);

                return switcherInstance;
            }

            return instance;
        }
    }
}
