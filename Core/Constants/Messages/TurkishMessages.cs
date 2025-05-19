using Core.Entities.Concrete;

namespace Core.Constants.Messages
{
    public class TurkishMessages
    {
        public static string AuthorizationDenied = "Yetkisiz erişim.";
        public static string InvalidIdentityNumber = "Kimlik numarası geçersiz.";
        public static string IdentityNumberAlreadyExists = "Bu kimlik numarası zaten mevcut.";
        public static string TrainerAlreadyExists = "Bu eğitmen zaten mevcut.";
        public static string UserPhoneNumberAlreadyExists = "Telefon numarası zaten mevcut.";
        public static string NameAlreadyExists = "Bu isim zaten mevcut.";
        public static string NameCannotBeEmpty = "İsim boş olamaz.";
        public static string NameLengthError = "İsim 2-50 karakter arasında olmalıdır.";

        public static string CampaignAdded = "Kampanya eklendi.";
        public static string CampaignUpdated = "Kampanya güncellendi.";
        public static string CampaignDeleted = "Kampanya silindi.";
        
        public static string DealerMemberAdded = "Bayi üyesi eklendi.";
        public static string DealerMemberUpdated = "Bayi üyesi güncellendi.";
        public static string DealerMemberDeleted = "Bayi üyesi silindi.";
        
        public static string DealerAdded = "Bayi eklendi.";
        public static string DealerUpdated = "Bayi güncellendi.";
        public static string DealerDeleted = "Bayi silindi.";
        
        public static string EquipmentAdded = "Ekipman eklendi.";
        public static string EquipmentUpdated = "Ekipman güncellendi.";
        public static string EquipmentDeleted = "Ekipman silindi.";
        
        public static string GymAccessLogAdded = "Spor salonu erişim kaydı eklendi.";
        public static string GymAccessLogUpdated = "Spor salonu erişim kaydı güncellendi.";
        public static string GymAccessLogDeleted = "Spor salonu erişim kaydı silindi.";
        
        public static string GymCapacityAdded = "Spor salonu kapasitesi eklendi.";
        public static string GymCapacityUpdated = "Spor salonu kapasitesi güncellendi.";
        public static string GymCapacityDeleted = "Spor salonu kapasitesi silindi.";
        
        public static string MemberCampaignAdded = "Üye kampanyası eklendi.";
        public static string MemberCampaignUpdated = "Üye kampanyası güncellendi.";
        public static string MemberCampaignDeleted = "Üye kampanyası silindi.";
        
        public static string MemberMeasurementAdded = "Üye ölçümü eklendi.";
        public static string MemberMeasurementUpdated = "Üye ölçümü güncellendi.";
        public static string MemberMeasurementDeleted = "Üye ölçümü silindi.";
        
        public static string MemberAdded = "Üye eklendi.";
        public static string MemberUpdated = "Üye güncellendi.";
        public static string MemberDeleted = "Üye silindi.";
        
        public static string PackageAdded = "Paket eklendi.";
        public static string PackageUpdated = "Paket güncellendi.";
        public static string PackageDeleted = "Paket silindi.";
        
        public static string PaymentAdded = "Ödeme eklendi.";
        public static string PaymentUpdated = "Ödeme güncellendi.";
        public static string PaymentDeleted = "Ödeme silindi.";
        
        public static string RoleAdded = "Rol eklendi.";
        public static string RoleUpdated = "Rol güncellendi.";
        public static string RoleDeleted = "Rol silindi.";
        
        public static string SubscriptionAdded = "Abonelik eklendi.";
        public static string SubscriptionUpdated = "Abonelik güncellendi.";
        public static string SubscriptionDeleted = "Abonelik silindi.";
        
        public static string TrainerAssignmentAdded = "Eğitmen ataması eklendi.";
        public static string TrainerAssignmentUpdated = "Eğitmen ataması güncellendi.";
        public static string TrainerAssignmentDeleted = "Eğitmen ataması silindi.";
        
        public static string TrainerAdded = "Eğitmen eklendi.";
        public static string TrainerUpdated = "Eğitmen güncellendi.";
        public static string TrainerDeleted = "Eğitmen silindi.";
        
        public static string TrainerScheduleAdded = "Eğitmen programı eklendi.";
        public static string TrainerScheduleUpdated = "Eğitmen programı güncellendi.";
        public static string TrainerScheduleDeleted = "Eğitmen programı silindi.";
        
        public static string UserRegisterSuccess = "Kullanıcı başarıyla kaydedildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        public static string UserAlreadyExists = "Bu e-posta adresiyle bir kullanıcı zaten mevcut.";
        public static string AccessTokenCreated = "Erişim tokenı oluşturuldu.";
        
        public static string ErrorOccurred = "Bir hata oluştu.";
        public static string NotFound = "Bulunamadı.";
        public static string ValidationFailed = "Doğrulama başarısız oldu.";
        public static string UnauthorizedAccess = "Yetkisiz erişim.";
        public static string OperationFailed = "İşlem başarısız oldu.";
        public static string InvalidStatus => "Geçerli bir durum değeri olmalıdır (0: Pasif, 1: Aktif)";

        public static string RegionError = "Böyle bir bölge bulunamadı!";

        public static string Success = "Başarılı bir şekilde listelendi.";
        
        // Validasyonlar için gereken mesajlar
        public static string CompanyNameLength = "Şirket adı 2-50 karakter arasında olmalıdır.";
        public static string MemberIdInvalid = "Geçerli bir üye ID'si gereklidir.";
        public static string UserIdInvalid = "Geçerli bir kullanıcı ID'si gereklidir.";
        public static string DealerIdInvalid = "Geçerli bir bayi ID'si gereklidir.";
        
        // Ekstra validasyon mesajları
        public static string RegionLength = "Bölge bilgisi 2-50 karakter arasında olmalıdır.";
        public static string TaxNumberLength = "Vergi numarası 10-11 karakter olmalıdır.";
        public static string AccessDateRequired = "Giriş tarihi gereklidir.";
        public static string InvalidAccessType = "Geçersiz giriş/çıkış tipi.";
        public static string DeviceIdInvalid = "Geçerli bir cihaz ID'si gereklidir.";
        
        public static string CampaignLimitExceeded = "Kampanya limiti aşıldı, en fazla 6 kampanya eklenebilir.";

    }
}
