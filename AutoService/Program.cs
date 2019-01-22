using System;
using System.Configuration;
using AutoService.DAL.UnitOfWork;
using AutoService.BLL.Services;
using AutoService.BLL.DTO;
using AutoService.BLL.Infrastructure;

namespace AutoService
{
    class Program
    {
        static void Main(string[] args)
        {
            SaleService ss = new SaleService(new UnitOfWork(new DAL.Entities.AutoServiceContext()));

            Console.WriteLine("Cars:");

            foreach(var car in ss.GetCars())
            {
                Console.WriteLine($"{car.Id} {car.Brand} {car.Model}");
            }

            Console.WriteLine("Owners:");

            foreach (var owner in ss.GetOwners())
            {
                Console.WriteLine($"{owner.Id} {owner.FirstName} {owner.LastName}");
            }

            Console.WriteLine("---------------------------");

            OwnerDTO buyer = ss.GetOwner(1);
            CarDTO carForSale = ss.GetCar(2);

            try
            {
                ss.MakeSale(carForSale, buyer);

                Console.WriteLine("Successful purchase");
            }
            catch(InternalServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
