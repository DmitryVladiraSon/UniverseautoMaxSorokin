namespace Universeauto.Models
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }
        Car GetCar(long id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
    }
}
