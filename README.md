
# Kütüphane Yönetim Sistemi

Bu proje, C# dilinde geliştirilmiş bir **Kütüphane Yönetim Sistemi** uygulamasıdır. Temel olarak kitapların eklenmesi, ödünç verilmesi, iade edilmesi ve raporlanması gibi işlemleri destekler. Kullanıcı dostu bir konsol arayüzüyle yönetim sağlanır.

---

## Özellikler

### Kitap İşlemleri
- **Kitap Ekleme**: Yeni kitaplar ekleyebilir ve stok bilgilerini girebilirsiniz.
- **Kitap Arama**: Kitapları isim veya yazara göre arayabilirsiniz.
- **Stok Görüntüleme**: Mevcut kitapların stok bilgilerini listeleyebilirsiniz.

### Ödünç Alma ve İade İşlemleri
- **Kitap Ödünç Alma**:
  - Belirli bir süre için kitap ödünç alınabilir.
  - Kullanıcıdan bütçe kontrolü yapılarak uygunluk değerlendirilir.
  - Stok bilgisi, ödünç alma işlemine göre güncellenir.
- **Kitap İade Etme**:
  - Ödünç alınan kitaplar sistem üzerinden iade edilebilir.
  - İade edilen kitaplar stok bilgisine tekrar eklenir.

### Raporlama
- **Tüm Kitaplar**: Sistemde kayıtlı olan tüm kitapları listeleyebilirsiniz.
- **Kiralanan Kitaplar**: Ödünç alınan kitapların detaylarını görebilirsiniz.
- **Yazar Bazlı Filtreleme**: Belirli bir yazara ait tüm kitapları listeleyebilirsiniz.
- **Yayın Yılı Filtreleme**: Belirli bir yıl için yayınlanmış kitapları görüntüleyebilirsiniz.

---

## Kod Yapısı

### 1. **`Book.cs`**
Kitap nesnesini tanımlayan sınıf:
```csharp
public class Book
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int Year { get; set; }
    public int Quantity { get; set; }
}
```

### 2. **`Loan.cs`**
Ödünç alınan kitapları temsil eden sınıf:
```csharp
public class Loan
{
    public Book Book { get; set; }
    public int Days { get; set; }
    public string User { get; set; }
    public DateTime ReturnDate { get; set; }
}
```

### 3. **`ProgramObjects.cs`**
Sistemin çalışma esnasında kullandığı verileri saklayan statik sınıf:
- `books`: Sistemde mevcut kitaplar.
- `loans`: Ödünç alınan kitapların kayıtları.

### 4. **`Program.cs`**
Uygulamanın giriş noktası ve ana iş mantığını içeren sınıf:
- **Menü**: Ana menü ve alt menüler konsol üzerinden kullanıcıya sunulur.
- **Metotlar**:
  - `AddBook`: Yeni kitap ekleme.
  - `BorrowBook`: Kitap ödünç alma.
  - `ReturnBook`: Kitap iade etme.
  - `SearchBook`: Kitap arama işlemleri.
  - `Report`: Raporlama ekranı.

---

## Örnek Kitap Listesi
Program başlangıcında sisteme kayıtlı örnek kitaplar:

| Kitap Adı                        | Yazar                  | Yıl  | Stok |
|----------------------------------|------------------------|------|------|
| Bilgisayar Mühendisliğine Giriş | Toros Rıfat Çölkesen   | 2022 | 5    |
| Kürk Mantolu Madonna            | Sabahattin Ali         | 1937 | 3    |
| Saatleri Ayarlama Enstitüsü     | Ahmet Hamdi Tanpınar   | 1961 | 2    |
| Kuyucaklı Yusuf                 | Sabahattin Ali         | 1937 | 1    |

---

## Kullanım
1. **Proje Kodu**: `Program.cs` dosyasını çalıştırarak başlatabilirsiniz.
2. **Ana Menü**:
   - 1: Kitap Ekleme
   - 2: Kitap Kiralama
   - 3: Kitap İade
   - 4: Kitap Arama
   - 5: Raporlama
   - 6: Çıkış

3. İşlem seçimi yaparak yönlendirmeleri takip edin.

---

## Geliştiriciler İçin
Projeyi klonlayın ve kendi geliştirme ortamınızda deneyin:
```bash
git clone https://github.com/mustafa44msi/LibraryManagementSystem.git
```

---

Bu proje, öğrenme amaçlı geliştirilmiş bir sistemdir ve temel kütüphane yönetim işlevlerini içerir. Daha fazla özellik eklemek veya geliştirmek için katkıda bulunabilirsiniz!
