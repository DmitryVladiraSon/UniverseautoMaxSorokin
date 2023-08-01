using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models
{

    public class CarRepository : ICarRepository
    {
        private DataContext context;

        public CarRepository(DataContext cnt) =>
            context = cnt;

        public IEnumerable<Car> Cars => context.Cars;

        public void DeleteCar(Car car)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
        }

        public void AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            context.Cars.Update(car);
            context.SaveChanges();
        }

        public Car GetCar(long id) => context.Cars
            .Include(c => c.Customer).First(car => car.Id == id);
    }
}
