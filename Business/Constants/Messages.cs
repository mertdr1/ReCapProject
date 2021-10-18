using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string CarImageLimit = "A car can only has 5 images";
        public static string AuthorizationDenied = "Yetkiniz yok";
        internal static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        internal static string UserRegistered = "Kayıt olundu";
        internal static string SuccessfulLogin = "Başarılı giriş.";
        internal static string PasswordError = "Şifre Hatası.";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string AccessTokenCreated = "Token ulaştırıldı.";
    }
}
