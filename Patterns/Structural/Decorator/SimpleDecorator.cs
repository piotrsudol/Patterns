
namespace Patterns.Structural.SimpleDecorator
{
    void Main() { }

    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }

    public class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public abstract class BaseDecorator : IItem
    {
        protected IItem data;
        public BaseDecorator(IItem item) => this.data = item;
        public virtual int Id { get => data.Id; set => data.Id = value; }
        public virtual string Name { get => data.Name; set => data.Name = value; }
        public virtual string Description { get => data.Description; set => data.Description = value; }
    }

    public class EventDecorator : BaseDecorator
    {
        public EventDecorator(IItem item) : base(item) { }

        public override string Name
        {
            get => data.Name;
            set
            {
                data.Name = value;
                log(value);
            }
        }

        private void log(string value) { }
    }
}
