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
  - [Yapım Aşamasında 🚧](#yapım-aşamasında-)
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
- Entity Framework Core
- MSSQL Server
- JWT Authentication
- MongoDB
- Redis Cache
- Docker

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
- Redis Cache Entegrasyonu
- MongoDB Log Yönetimi

## API Endpoints 🔌

### Auth 🔐
- POST /api/auth/login
- POST /api/auth/register

### Member 👥
- GET /api/member/getall
- GET /api/member/getbyid
- POST /api/member/add
- PUT /api/member/update
- DELETE /api/member/delete
- GET /api/member/getallwithdetails
- GET /api/member/getbyidwithdetails
- GET /api/member/getmembercampaigns
- GET /api/member/getmembercampaigndetailbymemberid

### Subscription 📝
- GET /api/subscription/getall
- GET /api/subscription/getbyid
- POST /api/subscription/add
- PUT /api/subscription/update
- DELETE /api/subscription/delete
- GET /api/subscription/getallbydetails
- GET /api/subscription/getdetailsbyid

### Package 📦
- GET /api/package/getall
- GET /api/package/getbyid
- POST /api/package/add
- PUT /api/package/update
- DELETE /api/package/delete

### Campaign 🎯
- GET /api/campaign/getall
- GET /api/campaign/getbyid
- POST /api/campaign/add
- PUT /api/campaign/update
- DELETE /api/campaign/delete

### Trainer 💪
- GET /api/trainer/getall
- GET /api/trainer/getbyid
- POST /api/trainer/add
- PUT /api/trainer/update
- DELETE /api/trainer/delete
- GET /api/trainer/getallwithdetails
- GET /api/trainer/getbyidwithdetails

### Dealer 🤝
- GET /api/dealer/getall
- GET /api/dealer/getbyid
- POST /api/dealer/add
- PUT /api/dealer/update
- DELETE /api/dealer/delete
- GET /api/dealer/getallwithdetails
- GET /api/dealer/getbyidwithdetailsbyid

## Kurulum 🚀

### Gereksinimler 📋
- .NET 8.0 SDK
- MSSQL Server
- Redis Server
- Docker

### Adımlar 📝
1. Projeyi klonlayın
```bash
git clone https://github.com/0Baris/NetGym.git
```

2. Veritabanını oluşturun
```bash
sqlcmd -S localhost -i NetGymDB.sql
```

3. Redis'i başlatın
```bash
docker run --name redis -p 6379:6379 -d redis
```

4. Projeyi çalıştırın
```bash
cd WebAPI
dotnet run
```

## Yapım Aşamasında 🚧
- [ ] MongoDB Log Yönetimi
- [ ] Redis Cache Yönetimi
- [ ] Docker Container Yapılandırması

## Lisans 📄
Bu proje MIT lisansı altında lisanslanmıştır.
