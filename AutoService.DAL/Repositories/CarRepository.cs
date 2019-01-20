using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoService.DAL.Entities;

namespace AutoService.DAL.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AutoServiceContext context) : base(context)
        {
        }

        public IEnumerable<Car> GetCarsByBrand(string brand)
        {
            return Context.Cars.Where(car => car.Brand == brand);
        }

        public IEnumerable<Car> GetCarsByPriceRange(int minPrice, int maxPrice)
        {
            return Context.Cars.Where(car => car.Price >= minPrice && car.Price <= maxPrice);
        }

        public IEnumerable<Car> GetCarsByYearRange(int startYear, int endYear)
        {
            return Context.Cars.Where(car => car.Year >= startYear && car.Year <= endYear);
        }

        public IEnumerable<Car> GetCarsWithOwners()
        {
            return Context.Cars.Include(c => c.Owner).OrderBy(c => c.Price);
        }
    }
}
