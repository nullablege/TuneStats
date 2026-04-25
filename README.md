# TuneStats

TuneStats, müzik dinleme verilerini analiz etmek ve büyük veri kümeleri üzerinde anlamlı dashboard çıktıları üretmek için geliştirilmiş bir ASP.NET Core MVC projesidir. Proje, SQL Server üzerinde tutulan dinleme kayıtlarını Dapper ile okuyarak genel istatistikler, dönemsel trendler, tür dağılımları, yaş kırılımları, şehir/ilçe analizleri ve detaylı veri tablosu ekranları sunar.

Bu çalışma, M&Y Eğitim Akademi 10. Dönem 7. Projesi kapsamında hazırlanmış bir bootcamp projesidir.

## Proje Amacı

TuneStats, yüksek hacimli dinleme verilerinin hızlı ve okunabilir biçimde analiz edilmesini hedefler. Uygulama, tek tek kayıt incelemek yerine veriyi özetleyen, karşılaştıran ve görselleştiren bir panel sağlar.

Proje özellikle büyük veritabanlarındaki kayıtlarla çalışabilmek için tasarlanmıştır. Geliştirme ve test sürecinde `TuneStatsDB` veritabanındaki `Dinlemeler` tablosunda bulunan 2.100.125 kayıt üzerinden denenmiştir.

## Özellikler

- Toplam dinleme, sanatçı, şarkı, popüler tür ve en aktif şehir özetleri
- Son günlere ait dinleme trendi grafiği
- Müzik türlerine göre dağılım analizi
- Yaş gruplarına göre dinleme istatistikleri
- İl ve ilçe bazlı dinleme dağılımları
- Haftanın günlerine göre dinleme yoğunluğu
- En çok dinlenen sanatçılar ve şarkılar listesi
- Top şehirler ve top türler için oran bazlı ilerleme grafikleri
- Büyük veri setleri için sayfalama destekli veri tablosu
- Dinleme ID ile kayıt arama
- Mobil ekranlarda kullanılabilir sidebar navigasyonu
- Boş veri durumlarında hataya düşmeyen dashboard akışı

## Kullanılan Teknolojiler

- ASP.NET Core MVC
- .NET 8
- SQL Server
- Dapper
- Microsoft.Data.SqlClient
- Razor Views
- HTML, CSS, JavaScript

## Proje Yapısı

```text
TuneStats/
  Context/
    DapperContext.cs
  Controllers/
    HomeController.cs
  DTOs/
  Models/
  Views/
    Home/
    Shared/
  wwwroot/
    js/
    lib/
    style.css
```

## Veritabanı

Uygulama varsayılan olarak aşağıdaki connection string ile çalışır:

```json
"DefaultConnection": "Server=.;Database=TuneStatsDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

Beklenen ana tablo `Dinlemeler` tablosudur. Uygulamada kullanılan temel alanlar:

- `DinlemeId`
- `AdSoyad`
- `Yas`
- `Il`
- `Ilce`
- `Sanatci`
- `Sarki`
- `Tur`
- `Tarih`

## Kurulum

Projeyi çalıştırmak için aşağıdaki ortam gereklidir:

- .NET 8 SDK
- SQL Server
- `TuneStatsDB` veritabanı

Bağımlılıkları yüklemek ve projeyi derlemek için:

```bash
dotnet restore
dotnet build
```

Uygulamayı çalıştırmak için:

```bash
dotnet run --project TuneStats/TuneStats.csproj
```

Varsayılan geliştirme profili HTTP için `http://localhost:5157` adresini kullanır.

## Ekranlar

Uygulamada iki ana ekran bulunur:

- Dashboard: Dinleme verilerinden üretilen genel istatistik ve grafik ekranı
- Veri Tablosu: Sayfalama ve ID araması ile ham kayıtların incelenebildiği tablo ekranı

## Notlar

Bu proje eğitim amacıyla geliştirilmiştir. Büyük veri setleriyle çalışma pratiği, SQL sorgularının dashboard ihtiyaçlarına göre şekillendirilmesi ve ASP.NET Core MVC üzerinde veri odaklı arayüz geliştirme deneyimi kazanmayı hedefler.

## Geliştirici

GitHub: [nullablege](https://github.com/nullablege)

## Proje Görselleri 
<img width="3369" height="1271" alt="Screenshot_117" src="https://github.com/user-attachments/assets/b2ef02f7-6b45-4f85-a4f8-96b8bfc8c6de" />
<img width="3368" height="1271" alt="Screenshot_118" src="https://github.com/user-attachments/assets/5c314d32-36ce-4742-83c0-98257634c5e2" />
<img width="3370" height="1264" alt="Screenshot_119" src="https://github.com/user-attachments/assets/2d4a67b0-83ee-455e-85ff-9181216f2dff" />
<img width="3372" height="1270" alt="Screenshot_120" src="https://github.com/user-attachments/assets/a0d0e47a-01f9-4864-91ab-d35a47ad2683" />
<img width="3373" height="1256" alt="Screenshot_123" src="https://github.com/user-attachments/assets/4d0ca13d-e562-438d-87d0-02813232a2eb" />
<img width="3369" height="1270" alt="Screenshot_124" src="https://github.com/user-attachments/assets/963e083a-e0bf-4231-8b73-1634d502d017" />

