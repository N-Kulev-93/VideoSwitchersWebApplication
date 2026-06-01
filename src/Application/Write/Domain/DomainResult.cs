namespace Application.Write
{
    public class DomainResult
    {
        readonly List<string> _errorMessages;

        internal DomainResult(int? maxErrorCapacity = null)
        {
            _errorMessages = maxErrorCapacity.HasValue ? new(capacity: maxErrorCapacity.Value) : new();
        }

        internal void AddErrorMessage(string value)
        {
            if (value is null)
            {
                _errorMessages.Add("Unknown error without message.");
                return;
            }

            _errorMessages.Add(value);
        }

        internal bool IsFailure => _errorMessages.Count > 0;
        internal bool IsSuccess => _errorMessages.Count == 0;

        public override string ToString()
        {
            // TODO: Check if better to have sepparate method for printing result.
            return $"Error count: {_errorMessages.Count}. Messages:{Environment.NewLine} {string.Join(Environment.NewLine, _errorMessages)}";
        }
    }
}
