namespace Logger
{
    public abstract record class AbstractEntity : IEntity
    {   
        public Guid Id { get; init; } = Guid.NewGuid();
        public abstract string Name { get;}
    }
}
