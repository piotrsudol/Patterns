
namespace Patterns.Prototype
{
    void Main()
    {
        var garden = new GardenFactory(
            new TreeSeed("Apple"),
            new GrassSeed("Green"),
            new FlowerSeed("Roses")
        );
        garden.CreatePlant1().Dump();
        garden.CreatePlant2().Dump();
        garden.CreatePlant3().Dump();
    }

    public class GardenFactory
    {
        Seed[] _seed = new Seed[3];

        public GardenFactory(Seed first, Seed second, Seed third)
        {
            _seed = new[] { first, second, third };
        }

        public Seed CreatePlant1() => _seed[0].Copy();
        public Seed CreatePlant2() => _seed[0].Copy();
        public Seed CreatePlant3() => _seed[0].Copy();
    }

    public abstract class Seed
    {
        public abstract Seed Copy();
    }

    public class TreeSeed : Seed
    {
        public string Type { get; }
        public TreeSeed(string type) => Type = type;
        public override Seed Copy() => new TreeSeed(Type);
    }

    public class GrassSeed : Seed
    {
        public string Type { get; }
        public GrassSeed(string type) => Type = type;
        public override Seed Copy() => new GrassSeed(Type);
    }

    public class FlowerSeed : Seed
    {
        public string Type { get; }
        public FlowerSeed(string type) => Type = type;
        public override Seed Copy() => new FlowerSeed(Type);
    }
}
