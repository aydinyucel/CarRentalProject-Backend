using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetCarById(int id);
        IDataResult<Car> GetCarByDesription(string description);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrand(string brandName);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetFilteredCars(string colorName, string brandName);
    }

}
