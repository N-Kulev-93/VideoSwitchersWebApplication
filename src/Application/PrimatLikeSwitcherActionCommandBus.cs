using Application.Command;
using Application.Interface;
using Application.Query;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Application
{
    /// <summary>
    ///TODO: actionType as class and actionCommand as generic => ?
    /// </summary>
    public class PrimatLikeSwitcherActionCommandBus
    {

        ISwitcherManagedConnectionService _connectionService;

        /// <summary>
        ///  Current plan for this service is to be transient so it handles internaly entity changes that should not persist if the result of the action performed is failure.
        ///  Usually bus services are static in these scenarios, how we handle this ? ... TODO...
        /// </summary>
        ISwitcherWriterService _writerService;

        public PrimatLikeSwitcherActionCommandBus()
        {
            
        }

        public void Process(ActionCommand cmd)
        {
            switch (cmd.ActionType)
            {
                case Command.ActionType.Unknown:
                    break;
                case Command.ActionType.SwitchInput:
                    break;
                case Command.ActionType.RenameSwitcher:
                    break;
                case Command.ActionType.RenameInput:
                    break;
                case Command.ActionType.RenameOutput:
                    break;
                case Command.ActionType.OpenConnection:
                    break;
                case Command.ActionType.SelectActionConfiguration:
                    break;
                case Command.ActionType.SelectConnectionConfiguration:
                    break;
                default:
                    break;
            }
        }


        public void ExecuteOpenConnection(OpenConnectionCommand cmd)
        {
            var switcher = _writerService.ReadSingle(cmd.Id);
            if (switcher is null) return;

            _connectionService.OpenConnection(switcher);
        }

        public void ExecuteCloseConnection(CloseConnectionCommand cmd)
        {
            var switcher = _writerService.ReadSingle(cmd.Id);
            if (switcher is null) return;

            _connectionService.CloseConnection(switcher);
        }

        public void ExecuteSwitchInputAction(SwitchInputCommand cmd)
        {
            var target = _writerService.ReadSingle(cmd.Id);
            
            //TODO:...
            if (target is null) return;

            var result = target.SwitchVideoInput(cmd.InputPosition, cmd.OutputPosition);
            if (result.IsFailure) return; // TODO: ...

            _writerService.Write(target);
        }

        public void ExecuteRenameSwitcherAction(RenameSwitcherCommand cmd)
        {

        }

        public void ExecuteRenameInputAction(RenameSwitcherInputCommand cmd)
        {

        }

        public void ExecuteRenameOutputAction(RenameSwitcherOutputCommand cmd)
        {

        }

        public void ExecuteSelectConnectionConfiguration()
        {
            throw new NotImplementedException();
        }

        public void ExecuteSelectActionConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
