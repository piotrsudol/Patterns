namespace Patterns.Prototype
{
    void Main()
    {
        List<IBlock> grid = new List<IBlock>();
        grid.Add(BlockFactory.Create("Hello World"));
        grid.Add(BlockFactory.Create("3"));
        grid.Add(BlockFactory.Create("01/02/2010"));
    }

    public class BlockFactory
    {
        public static IBlock Create(string content)
        {
            if (DateTime.TryParse(content, out var dt))
                return new DateTimeBlock() { Format = "dd/MM/yyyy", DateTime = dt };
            if (int.TryParse(content, out var number))
                return new NumberBlock() { Number = number };

            return new TextBlock { Content = content };
        }
    }

    public interface IBlock
    {
        string Render { get; }
        IBlock Clone();
    }

    public class TextBlock : IBlock
    {
        public string Content { get; set; }
        public IBlock Clone() => new TextBlock { Content = Content };
        public string Render => Content;
    }

    public class NumberBlock : IBlock
    {
        public int Number { get; set; }
        public IBlock Clone() => new NumberBlock { Number = Number };
        public string Render => Number.ToString();
    }

    public class DateTimeBlock : IBlock
    {
        public DateTime DateTime { get; set; }
        public string Format { get; set; }
        public IBlock Clone() => new DateTimeBlock { DateTime = DateTime, Format = Format };
        public string Render => DateTime.ToString(Format);
    }
}
