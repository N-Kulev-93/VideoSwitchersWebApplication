using Application.Command.Rules;
using Application.Shared;

namespace Application.Command
{
    public class VideoSwitcher : SimpleEntity
    { 
        public string Name { get; private set; } 
        public ICollection<VideoInput> Inputs { get; private set; }
        public ICollection<VideoOutput> Outputs { get; private set; }
        public SwitcherSettings Settings { get; private set; }
        public bool IsOnline { get; private set; }

        public DomainResult Rename(string name)
        {
            this.Name = name;

            return DomainResult.Success;
        }

        public DomainResult RenameInput(int position, string name)
        {
            var result = new DomainResult(maxErrorCapacity: 2);

            if (!new NameIsNotExistInVideoSwitcherInputs(name).IsSatisfiedBy(this))
                result.AddErrorMessage("Input name already in use.");

            if (!new VideoSwitcherInputPositionInRange(position).IsSatisfiedBy(this))
                result.AddErrorMessage("Input position out of range.");

            if (result.IsFailure) return result;

            var input = Inputs.Single(input => input.Position.Equals(position));
            input.Name = name;

            return result;
        }

        public DomainResult RenameOutput(int position, string name)
        {
            var result = new DomainResult(maxErrorCapacity: 2);
            
            if (!new NameIsNotExistInVideoSwitcherOutputs(name).IsSatisfiedBy(this))
                result.AddErrorMessage("Output name already in use.");

            if (!new VideoSwitcherOutputPositionInRange(position).IsSatisfiedBy(this))
                result.AddErrorMessage("Output position out of range.");

            if (result.IsFailure) return result;

            var output = Outputs.Single(output => output.Position.Equals(position));
            output.Name = name;

            return result;
        }

        public DomainResult SetOutputSourceInput(int inputPosition, int outputPosition)
        {
            var result = new DomainResult(maxErrorCapacity: 2);

            if (!new VideoSwitcherInputPositionInRange(inputPosition).IsSatisfiedBy(this)) 
                result.AddErrorMessage("Input position out of range.");

            if (!new VideoSwitcherOutputPositionInRange(outputPosition).IsSatisfiedBy(this))
                result.AddErrorMessage("Output position out of range.");

            if (result.IsFailure) return result;

            var output = Outputs.Single(output => output.Position.Equals(outputPosition));
            output.InputPosition = inputPosition;
           
            return result;
        }
    }
}
