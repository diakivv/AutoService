using System;
using System.Collections.Generic;
using System.Text;
using AutoService.DAL.Repositories;
using AutoService.DAL.Entities;

namespace AutoService.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoServiceContext _context;

        public IOwnerRepository Owners { get; }

        public ICarRepository Cars { get; }

        public UnitOfWork(AutoServiceContext context)
        {
            _context = context;
            Owners = new OwnerRepository(_context);
            Cars = new CarRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
