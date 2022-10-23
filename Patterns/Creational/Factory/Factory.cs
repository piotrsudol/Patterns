namespace Patterns.Factory
{
    //LINQPAD
    void Main()
    {
        var created = new World();
        created.Dump();
    }

    public class World
    {
        public World() => VehicleFactory.CreateVehicle();
    }

    public class Moon
    {
        public Moon() => VehicleFactory.CreateVehicle();
    }

    public class VehicleFactory
    {
        public static Vehicle CreateVehicle()
        {
            return new Vehicle() { Name = "Yellow Car" };
        }
    }

    public class Vehicle
    {
        public string Name { get; set; }
    }
}
