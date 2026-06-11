namespace Application.Command
{
    public class SimpleEntity : IEquatable<SimpleEntity>
    {
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is SimpleEntity && this.Equals(obj as SimpleEntity);
        }

        public bool Equals(SimpleEntity? other)
        {
            return this.Id.Equals(other?.Id);
        }
    }
}
