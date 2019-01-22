using System;
using System.Collections.Generic;
using System.Text;
using AutoService.BLL.DTO;
using AutoService.DAL.UnitOfWork;
using AutoService.DAL.Entities;
using AutoService.BLL.Infrastructure;

namespace AutoService.BLL.Services
{
    public class SaleService : ISaleService
    {
        IUnitOfWork db;

        public SaleService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void MakeSale(CarDTO carForSale, OwnerDTO buyer)
        {
            Car car = db.Cars.GetById(carForSale.Id);
            Owner owner = db.Owners.GetById(buyer.Id);

            if(car == null)
            {
                throw new InternalServiceException("The car was not found", "");
            }

            if(owner == null)
            {
                throw new InternalServiceException("The owner was not found", "");
            }

            if(car.OwnerId == owner.Id)
            {
                throw new InternalServiceException("Selling car to yourself", "");
            }

            car.OwnerId = owner.Id;
            db.Save();
        }

        public CarDTO GetCar(int id)
        {
            Car car = db.Cars.GetById(id);

            if (car == null)
            {
                throw new InternalServiceException("The car was not found", "");
            }

            return CarToCarDTO(car);
        }

        public IEnumerable<CarDTO> GetCars()
        {
            IEnumerable<Car> cars = db.Cars.GetAll();
            if (cars == null)
            {
                throw new InternalServiceException("Cars were not found", "");
            }

            var dtos = new List<CarDTO>();

            foreach (var car in cars)
            {
                dtos.Add(CarToCarDTO(car));
            }

            return dtos;
        }

        public OwnerDTO GetOwner(int id)
        {
            Owner owner = db.Owners.GetById(id);

            if (owner == null)
            {
                throw new InternalServiceException("The owner was not found", "");
            }

            return OwnerToOwnerDTO(owner);
        }

        public IEnumerable<OwnerDTO> GetOwners()
        {
            IEnumerable<Owner> owners = db.Owners.GetAll();
            if (owners == null)
            {
                throw new InternalServiceException("Owners were not found", "");
            }

            var dtos = new List<OwnerDTO>();

            foreach (var owner in owners)
            {
                dtos.Add(OwnerToOwnerDTO(owner));
            }

            return dtos;
        }

        private OwnerDTO OwnerToOwnerDTO(Owner owner)
        {
            return new OwnerDTO
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Age = owner.Age
            };
        }

        private CarDTO CarToCarDTO(Car car)
        {
            return new CarDTO
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Price = car.Price,
                OwnerId = car.OwnerId
            };
        }
    }
}
