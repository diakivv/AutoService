using System;
using System.Collections.Generic;
using System.Text;
using AutoService.DAL.Entities;

namespace AutoService.DAL.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetCarsByBrand(string brand);
        IEnumerable<Car> GetCarsByYearRange(int startYear, int endYear);
        IEnumerable<Car> GetCarsByPriceRange(int minPrice, int maxPrice);
        IEnumerable<Car> GetCarsWithOwners();
        //IEnumerable<Car> GetTopExpensiveCars(int count)
    }
}
