namespace Application.Write
{
    // TODO: Do we need this class?
    // I'm starting to change my mind about aggregates concept in ddd world.
    // My attention towards functional event sourcing is increasing rapidly...
    public class VideoSwitcherArgumentException : Exception
    {
        public VideoSwitcherArgumentException()
        {
        }

        public VideoSwitcherArgumentException(string? message) : base(message)
        {
        }
    }

    public class VideoSwitcher
    {

        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public ICollection<VideoInput> Inputs { get; private set; } = null!;
        public ICollection<VideoOutput> Outputs { get; private set; } = null!;
        public ICollection<ActionConfiguration> ActionConfigurations { get; private set; } = null!;
        public ConnectionConfiguration ConnectionConfiguration { get; private set; } = null!;

        /// <summary>
        /// Switch is implemented in infrastructure, initialize with IMaterializedInterceptor,
        /// When turn on creates runtime connection source based on connection type with settings 
        /// from provided configuration.
        /// </summary>

        public DomainResult Rename(string name)
        {
            // TODO: Check if string with value of "" should be included in null check and throw exception or it's invariant for the result.
            // TODO: check why Marthin Fowler uses custom exception model for arguments without value instead of built-in ArgumentNullException.
            if (string.IsNullOrWhiteSpace(name))
                throw new VideoSwitcherArgumentException($"Missing value for argument {nameof(name)} for 'rename input' action.");

            this.Name = name;

            return new DomainResult(maxErrorCapacity: 0);
        }

        public DomainResult RenameInput(int position, string name)
        {
            if (position < 0 || position > Inputs.Count)
                throw new VideoSwitcherArgumentException("Out-of-range position value for 'rename input' action.");

            var result = new DomainResult(maxErrorCapacity: 2);

            if (name.Equals(string.Empty))
                result.AddErrorMessage(value: "Empty name value for 'rename input' action.");

            var sameNameInput = Inputs.Where(input => !input.Position.Equals(position)).FirstOrDefault(input => input.Name.Equals(name));
            if (sameNameInput is not null)
                result.AddErrorMessage(value: $"Input at position {sameNameInput.Position} already using {name} name for 'rename input' action.");

            var input = Inputs.FirstOrDefault(input => input.Position.Equals(position));
            if (input is null)
                result.AddErrorMessage(value: $"Input at position {position} not found for 'rename input' action.");

            // TODO: Check if we should skip this check and undo the changes upper in the stack(where the entity's method is invoked) in case 'IsFailure' is true.
            if (result.IsFailure) return result;

            //TODO: Check if its possible to remove compilator warning since if target input is null result always equals 'IsFailure'.
            input!.Name = name;
            return result;
        }

        public DomainResult RenameOutput(int position, string name)
        {

            var result = new DomainResult(maxErrorCapacity: 2);

            //TODO: refactor...
            if (position < 0 || position > Outputs.Count)
                throw new VideoSwitcherArgumentException("Out-of-range position value for 'rename output' action.");

            if (string.IsNullOrWhiteSpace(name))
                throw new VideoSwitcherArgumentException("Empty or missing name value for 'rename output' action.");

            if (Outputs.Where(output => !output.Position.Equals(position)).Select(i => i.Name).Any(current => current == name))
                throw new VideoSwitcherArgumentException("Duplicate name value for 'rename output' action.");

            var output = Outputs.Single(output => output.Position.Equals(position));
            output.Name = name;

            return result;
        }

        public DomainResult SwitchSource(int inputPosition, int outputPosition)
        {
            var result = new DomainResult(maxErrorCapacity: 2);

            // Check if this validation is correct, does it overlap somehow with next check for existence?.
            if (inputPosition < 0 || inputPosition > Outputs.Count)
                result.AddErrorMessage("");

            if (outputPosition < 0 || outputPosition > Outputs.Count)
                result.AddErrorMessage("");

            //TODO: Or contains ? Check for O(n) just for information, it doesnt matter much here...
            if(Inputs.Any(input => input.Position.Equals(inputPosition)))
                result.AddErrorMessage("");

            var output = Outputs.FirstOrDefault(output => output.Position.Equals(outputPosition));
            if (output is null)
                result.AddErrorMessage("");
            // TODO: ...
            if (result.IsFailure) return result;

            output!.InputPosition = inputPosition;
            //TODO: DbContext persist. Runtime execute if configured as switcher command with template.
           
            return result;
        }


        //Do we need these ? We can directly call connection.Open() in controller
        public DomainResult OpenConnection()
        {
            var result = new DomainResult(maxErrorCapacity: 2);
         //   // Is this infrastructure or domain concern ?
        //    if (ConnectionSwitch.IsOpen)
                result.AddErrorMessage("");

        //    if (!this.ConnectionConfiguration.IsComplete)
                result.AddErrorMessage("");

            if (result.IsFailure) return result;

       //     if (this.ConnectionConfiguration.IsComplete) // Always true, investigate how to aknowledge the compilator ...
          //      this.ConnectionSwitch.Open(this.ConnectionConfiguration.SettingsJSON); // domain or infra for validation hm ...
            //TODO: Infralayer Runtime initialize instance(connection internal source).
            return result;
        }

        public DomainResult CloseConnection()
        {
            //TODO: Runtime persist(connection internal source).
            return new DomainResult();
        }


        public DomainResult ConfigureConnectionType(ConnectionType type)
        {
            var result = new DomainResult(maxErrorCapacity: 1);
            //if (this.ConnectionSwitch.IsOpen)
            {
                result.AddErrorMessage("Already open...close existing and configure.");
                return result;
            }

            if (this.ConnectionConfiguration?.Type.Equals(type) is true)
            {
                result.AddErrorMessage("Connection type is already set with provided value.");
                return result;
            }

            // compilator ...
            //this.ConnectionConfiguration!.Type = type;
            //Infrastructure layer -> change internal source instance with implementation depending on type.
            //this.ConnectionSwitch.ChangeType(type);
            //DbContext persist, 
            return result;
        }

        public DomainResult ConfigureConnectionSettings(string settingsJSON)
        {
            var result = new DomainResult(maxErrorCapacity: 1);

            //if (this.ConnectionSwitch.IsOpen)
            //{
            //    result.AddErrorMessage("Already open...close existing and configure.");
            //}

            //if (!ConfiguredConnection)
            //{
            //    result.AddErrorMessage("Configure connection type then settings.");
            //}

            //if (result.IsFailure) return result;

            //// If this line is reached its always configured but we cant lie the compilator...
            //if (ConfiguredConnection)
            //this.ConnectionConfiguration.SettingsJSON = settingsJSON;

            return new DomainResult(maxErrorCapacity: 2);
        }

        public DomainResult ConfigureAction()
        {
            //TODO: DbContext persist.
            return new DomainResult(maxErrorCapacity: 2);
        }
    }
}
