# NetGym - Spor Salonu Yönetim Sistemi 🏋️‍♂️

## Proje Hakkında ℹ️
NetGym, spor salonları için kurumsal mimaride geliştirilmiş .Net Core tabanlı bir API'dir. Mimari yapısından dolayı ölçeklendirebilir, geliştirebilir ve ücretsiz bir şekilde kullanabilirsiniz. 

## İçindekiler 📑
- [NetGym - Spor Salonu Yönetim Sistemi 🏋️‍♂️](#netgym---spor-salonu-yönetim-sistemi-️️)
  - [Proje Hakkında ℹ️](#proje-hakkında-ℹ️)
  - [İçindekiler 📑](#i̇çindekiler-)
  - [Mimari Yapı ve Uyulan Standartlar 🏗️](#mimari-yapı-ve-uyulan-standartlar-️)
  - [Teknolojiler 🛠️](#teknolojiler-️)
  - [Proje Yapısı 📁](#proje-yapısı-)
  - [Özellikler ✨](#özellikler-)
  - [API Endpoints 🔌](#api-endpoints-)
    - [Auth 🔐](#auth-)
    - [Member 👥](#member-)
    - [Subscription 📝](#subscription-)
    - [Package 📦](#package-)
    - [Campaign 🎯](#campaign-)
    - [Trainer 💪](#trainer-)
    - [Dealer 🤝](#dealer-)
  - [Kurulum 🚀](#kurulum-)
    - [Gereksinimler 📋](#gereksinimler-)
    - [Adımlar 📝](#adımlar-)
  - [Lisans 📄](#lisans-)

## Mimari Yapı ve Uyulan Standartlar 🏗️
- Kurumsal Mimari
- SOLID İlkeleri
- Cross-Cutting Concerns
- Tasarım Desenleri

## Teknolojiler 🛠️
- .NET 8.0
- ASP.NET Core Web API
- Fluent Validation
- Autofac
- Memory Cache
- LINQ Sorguları
- Entity Framework Core
- MSSQL Server
- JWT Authentication

## Proje Yapısı 📁
```
NetGym/
├── Business/         # İş mantığı katmanı
├── Core/            # Çekirdek katman
├── DataAccess/      # Veri erişim katmanı
├── Entities/        # Varlık sınıfları
├── WebAPI/          # API katmanı
└── ConsoleUI/       # Konsol arayüzü
```

## Özellikler ✨
- Üye Yönetimi
- Abonelik Yönetimi
- Paket Yönetimi
- Kampanya Yönetimi
- Eğitmen Yönetimi
- Bayi Yönetimi
- JWT tabanlı Kimlik Doğrulama 
- Memory Cache

## API Endpoints 🔌

![localhost_44374_swagger_index html](https://github.com/user-attachments/assets/a2f57d0a-3cb5-4017-b521-27e6967d98ba)


## Kurulum 🚀

### Gereksinimler 📋
- .NET 8.0 SDK
- MSSQL Server

### Adımlar 📝
1. Projeyi klonlayın
```bash
git clone https://github.com/0Baris/NetGym.git
```

2. Veritabanını oluşturun
```bash
sqlcmd -S localhost -i NetGymDB.sql
```

3. Projenin ana dizinine gidin ve NuGet paketlerini yükleyin
```bash
cd NetGym
dotnet restore
```

4. Projeyi çalıştırın
```bash
cd WebAPI
dotnet run
```

## Lisans 📄
Bu proje MIT lisansı altında lisanslanmıştır.
