# 📰 BlogStore – Katmanlı Mimari Blog Platformu

**BlogStore**, ASP.NET Core MVC ile geliştirilmiş, kullanıcıların blog yazabildiği, yorum yapabildiği, yazarların takip edilebildiği ve admin paneliyle içeriklerin kolayca yönetilebildiği modern ve ölçeklenebilir bir **katmanlı mimari** blog platformudur.

---

## 📌 Proje Mimarisi

BlogStore, SOLID prensipleri ve temiz kod anlayışıyla oluşturulmuş, modüler bir yapıya sahiptir. Katmanlar:

- **EntityLayer**: Veritabanı modelleri  
- **DataAccessLayer**: Entity Framework Core işlemleri (CRUD)  
- **BusinessLayer**: İş kuralları, servisler ve validasyonlar  
- **WebUI**: ASP.NET Core MVC kullanıcı arayüzü  
- **ViewModels**: Görünümle veri transferi için özelleştirilmiş sınıflar  

---

## 📚 Kullanılan Teknolojiler
- ASP.NET Core MVC (.NET 8)*
- Entity Framework Core
- ASP.NET Core Identity
- FluentValidation
- AJAX / jQuery
- SQL Server

## 🚀 Temel Özellikler

### 🌐 Anasayfa

- SEO uyumlu, görsel destekli modern bir arayüz  
- Slug yapısı sayesinde URL’lerde **makale ID’si yerine başlık** görünür  
  - Örnek: `/Article/ArticleDetail/yapay-zeka-ve-gelecek`

### 📄 Makale Detay Sayfası

- Seçilen makalenin tam içeriği görüntülenir  
- Altında **yazar bilgileri (adı, resmi, açıklama)** yer alır  
- **Login olmayan kullanıcılar yorum formunu göremez**  
- **AJAX ile yorum gönderimi** sağlanır  
- **Client-side validation** ile kullanıcı deneyimi artırılır  

---

## 🔐 Kullanıcı İşlemleri

- Giriş (Login) / Kayıt (Register) / Çıkış (Logout)  
- Şifre sıfırlama ve değiştirme  
- Profil bilgilerini güncelleme  
- ASP.NET Core Identity altyapısı kullanılmıştır  

---

## 🛠️ Admin Paneli (Flexy Teması ile)

### 📊 Dashboard

- Toplam makale, yorum, kategori, kullanıcı sayıları  
- En son eklenen makaleler listesi  
- Kullanıcıya özel istatistik kutucukları  

### 📋 İçerik Yönetimi

- Makale ve kategori oluşturma, düzenleme, silme  
- Kullanıcı profili ve şifre güncelleme ekranı  

### 🧩 Menü Alanları

- **Yeni Makale Oluştur**  
- **Makale Listem**  
- **Profilim**  

---

## 👥 Yazarlar ve Kategoriler

### 👤 Yazarlar

- Menüde yer alan "Yazarlar" sayfasında tüm yazarlar 3 sütunlu **responsive kartlar** ile listelenir  
- Her yazar kartında adı, fotoğrafı ve kısa açıklaması yer alır  
- Bir yazara tıklanınca sadece o yazara ait bloglar görüntülenir  

### 🏷️ Kategoriler

- Ana menüden tüm kategorilere erişim sağlanır  
- Her kategori detay sayfasında o kategoriye ait bloglar listelenir  

---

## 🧪 Validasyon & Kullanıcı Deneyimi

- **FluentValidation** ile model doğrulama  
- Formlarda **client-side validation**  
- Hatalı girişlerde kullanıcıya **TempData["message"]** ile bilgilendirme  
- AJAX işlemler sonrası dinamik geri bildirimler, form temizleme ve yönlendirme  

---

## 🧱 Dependency Injection Geliştirmesi

Tüm servis kayıtları `BusinessLayer > Container > DependencyInjection.cs` içerisine taşınmış ve aşağıdaki şekilde çağrılmıştır:

```csharp
services.AddBusinessLayerServices();
```
---

### Eklenecek Özellikler

 Toksiklik barındıran yorumların yapay zeka kullanılarak filtrelenmesi
 
### 🖼️ Ekran Görselleri 
![Screenshot 2025-07-06 110053](https://github.com/user-attachments/assets/ded68c43-47ed-4617-ab37-e6d1e7bd2217)
![Screenshot 2025-07-06 110034](https://github.com/user-attachments/assets/f78a4a4b-897e-4d6d-8406-c20199451f7c)
![Screenshot 2025-07-06 115247](https://github.com/user-attachments/assets/6d752e03-9c16-42fe-832d-4342b5db7226)
![Screenshot 2025-07-06 111459](https://github.com/user-attachments/assets/424d5cfd-d1b6-48e4-b009-88fc1a607460)
![Screenshot 2025-07-06 111510](https://github.com/user-attachments/assets/4dada259-9b40-424b-8fdf-e9fc3444121e)
![Screenshot 2025-07-06 111518](https://github.com/user-attachments/assets/02deb7c8-a677-4359-a723-677f99b5c0c0)
![Screenshot 2025-07-06 111526](https://github.com/user-attachments/assets/6f870631-17e2-48d5-8cc7-b4a41ec85694)
![Screenshot 2025-07-06 111535](https://github.com/user-attachments/assets/56f13fc9-4e52-4058-a57c-28d53d3f9754)
![Screenshot 2025-07-06 111546](https://github.com/user-attachments/assets/38f6cfe4-1ac9-4b5d-8391-d20c1511b303)
![Screenshot 2025-07-06 111603](https://github.com/user-attachments/assets/ff68e9ab-772a-423d-b0bb-4490e0ec3030)
![Screenshot 2025-07-06 111609](https://github.com/user-attachments/assets/bc14a1df-5a63-4b0d-b2de-a712efdfc609)
![Screenshot 2025-07-06 111617](https://github.com/user-attachments/assets/65e6087e-96e8-4806-b180-5b0ecfb54d01)
![Screenshot 2025-07-06 111634](https://github.com/user-attachments/assets/a11dc4ab-6c42-46d0-9b3e-797e9af6cb97)
![Screenshot 2025-07-06 111722](https://github.com/user-attachments/assets/134f365b-27a3-4e56-9dbd-20c51545d074)
![Screenshot 2025-07-06 111735](https://github.com/user-attachments/assets/4fe1c241-b908-401c-aa4b-6b7bc2b1522c)
![Screenshot 2025-07-06 111744](https://github.com/user-attachments/assets/08d5bde7-ddaa-4f54-8005-8ca39276c76f)
![Screenshot 2025-07-06 111757](https://github.com/user-attachments/assets/9a554b44-3041-43c0-82bf-5575621ba33f)
