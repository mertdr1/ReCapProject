using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helper.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(
                CarImageLimitExceed(carImage.CarId)
                );
            if (result!=null)
            {
                return result;
            }
        
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.UtcNow;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        private IResult CarImageLimitExceed(int carId)
        {
            var imagesCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (imagesCount>=1)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(_carImageDal.Get(c => c.CarImageId == carImage.CarImageId).ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.EntityListed);
        
        }
        //-----------
        public IDataResult<List<CarImage>> IfCarHasNotImageCheck(int carId)
        {
            var defPath = @"/images/default.jpg";
            var countImage = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (countImage == false)
            {
                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = carId, ImagePath = defPath, Date = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImages);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
        //-----------
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id), Messages.EntityListed);
        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(IfCarHasNotImageCheck(id).Data, Messages.EntityListed);
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var oldPath = carImage.ImagePath;
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.CarImageId == carImage.CarImageId).ImagePath, formFile);
            carImage.Date = DateTime.UtcNow;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
