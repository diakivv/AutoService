using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoService.DAL.Entities;

namespace AutoService.DAL.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(AutoServiceContext context) : base(context) { }

        public IEnumerable<Owner> GetOwnersByAge(int age)
        {
            return Context.Owners.Where(owner => owner.Age == age);
        }

        public IEnumerable<Owner> GetOwnersByCarBrand(string brand)
        {
            return Context.Owners.Include(o => o.Cars).
                Where(owner => owner.Cars.Any(car => car.Brand == brand));
        }

        public IEnumerable<Owner> GetOwnersByLastname(string lastname)
        {
            return Context.Owners.Where(owner => owner.LastName == lastname);
        }

        public IEnumerable<Owner> GetOwnersTop(int count)
        {
            return Context.Owners.Include(o => o.Cars).OrderByDescending(c => c.Cars.Count).Take(count);
        }

        public Owner GetOwnerWithCars(int ownerId)
        {
            return Context.Owners.Include(o => o.Cars).SingleOrDefault(a => a.Id == ownerId);
        }
    }
}
