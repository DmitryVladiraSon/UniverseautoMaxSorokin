using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models.Cars
{

    public class CarRepository :Repository<Car>, ICarRepository
    {
        private DataContext context;

        public CarRepository(DataContext cnt) : base(cnt) =>
            context = cnt;

        public IEnumerable<Car> Cars => context.Cars;

        public Car GetCar(long id) => context.Cars
            .Include(c => c.Customer).First(car => car.Id == id);
    }
}
