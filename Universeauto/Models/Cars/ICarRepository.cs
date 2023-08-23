namespace Universeauto.Models.Cars
{
    public interface ICarRepository :IRepository<Car>
    {
        IEnumerable<Car> Cars { get; }
        Car GetCar(long id);

    }
}
