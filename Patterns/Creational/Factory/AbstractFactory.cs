namespace Patterns.Factory.AbstractFactory
{
    void Main()
    {
        var created = new World(new CarFactory());
        var moon = new Moon(new MoonVehicleFactory());
        created.Dump();
    }

    public class World
    {
        public World(IVehicleFactory factory) => factory.CreateVehicle();
    }

    public class Moon
    {
        public Moon(IVehicleFactory factory) => factory.CreateVehicle();
    }

    public interface IVehicleFactory
    {
        public Vehicle CreateVehicle();
    }

    public class CarFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new Vehicle() { Name = "Yellow Car" };
        }
    }

    public class MoonVehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new Vehicle() { Name = "Curiosity" };
        }
    }

    public class Vehicle
    {
        public string Name { get; set; }
    }
}
