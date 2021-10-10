using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameCannotBeLessTwo = "Araba ismi iki karakterden az olamaz.";
        public static string CarPriceCannotBeLessThanZero = "Araba günlük fiyatı 0 ve 0'dan az olamaz.";
        public static string EntityAdded = "Değer eklendi";
        public static string EntityUpdated = "Değer güncellendi";
        public static string EntityDeleted = "Değer silindi";
        public static string EntityListed = "Değerler listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string EntityNameAlreadyExists = "Bu değer ismi zaten mevcut.";
        public static string EntityAlreadyExists = "Bu değer zaten mevcut";
        public static string CanNotBeRented = "Bu araba zaten kiralanmış.Kiralık süresi bitmeden yeniden kiralanamaz";
        public static string EntityWasBrought = "Değer getirildi";
    }
}
