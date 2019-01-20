using System;
using System.Collections.Generic;
using System.Text;
using AutoService.DAL.Repositories;
using AutoService.DAL.Entities;

namespace AutoService.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IOwnerRepository Owners { get; }
        ICarRepository Cars { get; }
        int Save();
    }
}
