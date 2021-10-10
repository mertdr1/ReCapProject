using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length<2)
            {
                //throw new Exception("2 Karakterden az olamaz");
                return new ErrorResult(Messages.CarNameCannotBeLessTwo);
            }
            if (car.DailyPrice<=0)
            {
                //throw new Exception("Günlük kiralama fiyatı 0'dan Büyük olmalı");
                return new ErrorResult(Messages.CarPriceCannotBeLessThanZero);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 24)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            var result = _carDal.GetAll();
            if (result==null)
            {
                return new ErrorDataResult<List<Car>>();
            }
             return  new SuccessDataResult<List<Car>>(result,Messages.EntityListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(d => d.CarId == id);
            if (result==null)
            {
                return new ErrorDataResult<Car>(result);
            }
                return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.EntityListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.EntityListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.EntityUpdated);
           
        }
    }
}
