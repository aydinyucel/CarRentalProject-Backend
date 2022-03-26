using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId),
                DefaultControl(carImage.CarId));
            if (result == null)
            {
                
                carImage.ImagePath = FileHelper.Upload(formFile);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.AddedCarImage);
            }

            return result;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run();
            if (result!=null)
            {
                return result;
            }
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            DefaultControl(carImage.CarId);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.Update(file, result.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageCount(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result == 5)
            {
                return new ErrorResult(Messages.CarImageCountEqualFive);
            }
            return new SuccessResult();
        }

        public IResult DefaultControl(int id)
        {
            var result = _carImageDal.GetAll(c=> c.CarId==id);
            var result2 = result.SingleOrDefault(c => c.ImagePath == "Default.png");
            if (result2==null && result.Count==0)
            {
                _carImageDal.Add(new CarImage() { Date = DateTime.Now ,ImagePath=Messages.DefaultLogoForCarImage,CarId=id});
                return new SuccessResult();
            }
            else if(result2!=null)
            {
                _carImageDal.Delete(new CarImage { CarId = result2.CarId, Date = result2.Date, Id = result2.Id, ImagePath = result2.ImagePath });
                return new SuccessResult();
            }
            else
            {
                return new SuccessResult();
            }
            
             
        }
        
    }
}
