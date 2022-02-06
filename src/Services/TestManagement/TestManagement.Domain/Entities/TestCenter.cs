namespace TestManagement.Domain.Entities
{
    public class TestCenter : EntityBase
    {
        public string Name { get; protected set; }
        public int Capacity { get; protected set; }
        public TestCenter(string name,int capacity) :base()
        {
            Name = name;
            Capacity = capacity;
        }
    }
}
