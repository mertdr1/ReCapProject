using Core.DataAccess;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : IEntityRepository<Car>
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1, BrandId=1, ColorId=1, ModelYear=2016, DailyPrice=140000, Description="Astra J"},
                new Car{ CarId=2, BrandId=1, ColorId=2, ModelYear=2019, DailyPrice=130000, Description="Clio"},
                new Car{ CarId=3, BrandId=2, ColorId=1, ModelYear=2016, DailyPrice=245000, Description="Passat"},
                new Car{ CarId=4, BrandId=2, ColorId=1, ModelYear=2015, DailyPrice=180000, Description="Corolla"},
            };
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            //throw new NotImplementedException();
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == entity.CarId);
        }
    }
}
