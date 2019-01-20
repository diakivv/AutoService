using System;
using System.Collections.Generic;
using System.Text;
using AutoService.DAL.Entities;

namespace AutoService.DAL.Repositories
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        IEnumerable<Owner> GetOwnersByCarBrand(string brand);
        IEnumerable<Owner> GetOwnersByAge(int age);
        IEnumerable<Owner> GetOwnersByLastname(string lastname);
        IEnumerable<Owner> GetOwnersTop(int count);
        Owner GetOwnerWithCars(int ownerId);
    }
}
