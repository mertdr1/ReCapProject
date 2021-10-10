using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            RentalManager rental = new RentalManager(new EfRentalDal());
           // - -Burası Kiralama denemesi
            Rental rentalRequest2 = new Rental
            {
                CarId = 3,
                CustomerId = 4,
                RentDate = DateTime.Now
                
            };

            var res = rental.Add(rentalRequest2);
            Console.WriteLine(res.Message);


            //NewMethod(rental);

        }

        private static void NewMethod(RentalManager rental)
        {
            foreach (var item in rental.GetAll().Data)
            {
                Console.WriteLine("--------");
                Console.WriteLine($"CarId : {item.CarId} Customer : {item.CustomerId} RentDate : {item.RentDate}");
                Console.WriteLine($"ReturnDate : {item.ReturnDate}");
                Console.WriteLine("--------");
            }
        }

    }
}
