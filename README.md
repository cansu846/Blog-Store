📰 BlogStore – Katmanlı Mimari Blog Platformu
ASP.NET Core MVC ile geliştirilen BlogStore, kullanıcıların blog yazabildiği, yorum yapabildiği, toksik içeriklerin filtrelendiği, admin paneli ile içeriklerin yönetilebildiği modern bir web uygulamasıdır.

📌 Katmanlı Mimari ve Proje Özeti
Bu proje aşağıdaki katmanlardan oluşur:

EntityLayer: Veritabanı modelleri

DataAccessLayer: Entity Framework Core işlemleri

BusinessLayer: Servisler, validasyon ve iş mantığı

WebUI: ASP.NET Core MVC arayüz katmanı

DTOs ve ViewModels: Veri transferleri için sade sınıflar

🚀 Temel Özellikler
🌐 Anasayfa
SEO uyumlu, görsel destekli ana sayfa tasarımı

Test/örnek değil, gerçek ve tutarlı makale içerikleri

Her blog altında “Devamını Oku” butonu

Slug yapısı ile URL’lerde sadece makale başlığı görünür
Örn: /Article/ArticleDetail/yapay-zeka-ve-gelecek

📄 Makale Detay Sayfası
Tıklanan makalenin detayları gösterilir

Başlık altında yazara ait bilgiler (adı, resmi, açıklama)

AJAX ile yorum gönderme (login olmayan kullanıcılar yorum panelini görmez)

Client-side validation desteği

Toksik yorum filtresi (HuggingFace API ile)

Yorumların toksik skoru yüksekse veritabanına eklenmez, kullanıcıya bildirim verilir

🔐 Kimlik Doğrulama
Giriş (Login), Kayıt (Register), Şifre Sıfırlama, Çıkış işlemleri

ASP.NET Identity ile entegre

Şifre değiştirme, profil bilgilerini güncelleme

🧠 Toksik İçerik Tespiti
HuggingFace API kullanılarak unitary/toxic-bert modeli ile yorum analizi

ToxicityScore alanı ile içerik puanlanır

0.5 üzeri skorlar ayrı tabloda listelenir (admin panelinde moderasyon için)

🛠️ Admin Paneli
Tema: Flexy Admin Panel
Panelde yer alan bölümler:

📊 Dashboard
Toplam kullanıcı, makale, kategori, yorum sayısı

Son eklenen makaleler listesi

Kullanıcıya özel hızlı istatistik kutucukları

📋 İçerik Yönetimi
Makale oluşturma, silme, düzenleme

Kategori ekle / sil / güncelle

Yorumları listeleme ve toksik olanları ayrı görme

Profil bilgileri ve şifre güncelleme alanı

🧩 Menü Alanları
Yeni Makale Oluştur

Makale Listem

Profilim (Kullanıcı bilgilerini güncelleme, şifre değiştirme)

🧠 Dependency Injection Geliştirmesi
BusinessLayer > Container > DependencyInjection.cs içerisinde
Program.cs üzerindeki services.AddScoped... kayıtları extension olarak taşındı:

csharp
Copy
Edit
services.AddBusinessLayerServices();
👥 Yazarlar & Kategoriler
👤 Yazar Sayfası
Menüde Yazarlar tıklanınca 3 sütunlu responsive grid tasarımı

Yazar kartında:

Adı, resmi, kısa açıklama

Tıklandığında: yazara ait tüm makaleler listelenir

🏷️ Kategoriler
Ana menüde kategori listesi

Her kategoriye özel detay sayfasında o kategoriye ait bloglar

🧪 Validasyon ve Kullanıcı Deneyimi
FluentValidation kullanımı

Formlarda client-side validasyon

Geri bildirimler TempData["message"] ile

AJAX işlemler sonrası bildirim, form sıfırlama, yeniden yönlendirme desteği

🖼️ Ekran Görselleri 
![Screenshot 2025-07-06 110053](https://github.com/user-attachments/assets/ded68c43-47ed-4617-ab37-e6d1e7bd2217)
![Screenshot 2025-07-06 110034](https://github.com/user-attachments/assets/f78a4a4b-897e-4d6d-8406-c20199451f7c)
![Screenshot 2025-07-06 110631](https://github.com/user-attachments/assets/e2dfe3fb-7c3e-4000-bfa7-3b27c0c0490b)
![Screenshot 2025-07-06 110641](https://github.com/user-attachments/assets/6867f626-6eb6-41d0-859b-37ff11945b71)
![Screenshot 2025-07-06 111453](https://github.com/user-attachments/assets/5c55743c-205c-4c5c-b1d3-7df3a0334ca8)
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
