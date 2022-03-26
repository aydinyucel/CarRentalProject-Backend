using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedCar = "Araba Eklendi";
        public static string DeletedCar = "Araba Silindi";
        public static string UpdatedCar = "Araba Güncellendi";
        public static string CarNotAdded = "Araba Eklenemedi";
        public static string CarNotDeleted = "Araba Silinemedi";
        public static string CarNotUpdated = "Araba Güncellenemedi";

        public static string CarsListed = "Arabalar Listelendi";
        public static string CarsListedByColorId = "Arabalar Renge göre Listelendi";
        public static string CarsListedByBrandId = "Arabalar Markaya göre Listelendi";
        public static string CarListed = "Arabalar Listelendi";
        public static string CarsDetailsListed = "Arabaların detayları Listelendi";

        public static string CarInUse = "Araba zaten kiralık.";
        public static string CarImageCountEqualFive = "Resim sayısı 5'ten fazla olamaz!";
        public static string AddedCarImage = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string DefaultLogoForCarImage = "Default.png";

        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Sisteme Giriş  Başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access Token başarıyla oluştu";
        public static string Maintenance = "Sistem Bakımda";

    }
}
