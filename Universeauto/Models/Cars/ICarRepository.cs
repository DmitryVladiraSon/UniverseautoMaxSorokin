namespace Universeauto.Models.Cars
{
    public interface ICarRepository 
    {
        IEnumerable<Car> Cars { get; }
        Car GetCar(long id);

    }
}
