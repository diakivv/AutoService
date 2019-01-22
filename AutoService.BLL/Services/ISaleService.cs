using System;
using System.Collections.Generic;
using System.Text;
using AutoService.BLL.DTO;

namespace AutoService.BLL.Services
{
    public interface ISaleService
    {
        void MakeSale(CarDTO carForSale, OwnerDTO buyer);

        CarDTO GetCar(int id);
        IEnumerable<CarDTO> GetCars();

        OwnerDTO GetOwner(int id);
        IEnumerable<OwnerDTO> GetOwners();
    }
}
