namespace Application.Write
{
    public class VideoSwitcher
    { 
        public int Id { get; private set; }
        public string Name { get; private set; } 
        public ICollection<VideoInput> Inputs { get; private set; }
        public ICollection<VideoOutput> Outputs { get; private set; }
        public ICollection<ActionConfiguration> ActionConfigurations { get; private set; } 
        public ConnectionConfiguration ConnectionConfiguration { get; private set; } 
        public bool IsOnline { get; set; }


        public DomainResult Rename(string name)
        {
            this.Name = name;

            return new DomainResult(maxErrorCapacity: 0);
        }

        public DomainResult RenameInput(int position, string name)
        {
            var result = new DomainResult(maxErrorCapacity: 2);

            if (result.IsFailure) return result;

            var input = Inputs.Single(input => input.Position.Equals(position));
            input.Name = name;

            return result;
        }

        public DomainResult RenameOutput(int position, string name)
        {

            var result = new DomainResult(maxErrorCapacity: 2);

            if (result.IsFailure) return result;

            var output = Outputs.Single(output => output.Position.Equals(position));

            output.Name = name;

            return result;
        }

        public DomainResult SwitchVideoInput(int inputPosition, int outputPosition)
        {
            var result = new DomainResult(maxErrorCapacity: 2);

            if (result.IsFailure) return result;

            var output = Outputs.Single(output => output.Position.Equals(outputPosition));

            output.InputPosition = inputPosition;
            //TODO: DbContext persist. Runtime execute if configured as switcher command with template.
           
            return result;
        }

        public DomainResult ConfigureConnection(ConnectionConfiguration configuration)
        {
            var result = new DomainResult(maxErrorCapacity: 1);

            //TODO:
            return result;
        }

        public DomainResult ConfigureAction()
        {
            //TODO: DbContext persist.
            return new DomainResult(maxErrorCapacity: 2);
        }
    }
}
