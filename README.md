### 📌 **SchoolManager Projesinin Özellikleri**

SchoolManager, öğrenci yönetim sistemine yönelik çeşitli özellikler sunmaktadır. Kullanıcılar projede yer alan menü seçenekleri ile öğrenci bilgilerini, adres bilgilerini, notlarını ve diğer detayları yönetebilir. Aşağıda projenin neler yapabildiği, hangi seçimlerin ne tür çıktılar ürettiği adım adım açıklanmıştır.

---

### **💡 Genel Özellikler**

1. **Öğrenci Bilgileri Yönetimi:**
   - Öğrenci bilgilerini (isim, soyisim, numara, adres, not, kitap) sisteme ekleme.
   - Öğrencilerin şube ve numara bazında sıralı bir şekilde görüntülenmesi.

2. **Adres Bilgisi Yönetimi:**
   - Öğrenciler için şehir ve ilçe bilgilerini tanımlama.
   - Belirli bir öğrencinin adres bilgilerini listeleme.

3. **Not Yönetimi:**
   - Öğrenciler için ders bazında not ekleme.
   - Öğrenci notlarının derslere göre listelenmesi ve ortalama hesaplaması.

4. **Kitap Yönetimi:**
   - Öğrencilere okudukları kitapları ekleme.
   - Bir öğrencinin kaç kitap okuduğunun görüntülenmesi.

---

### **🔢 Menü Seçenekleri ve İşlevleri**

Kullanıcı bir seçim yaptığında, belirli işlemleri gerçekleştiren menü sistemi aşağıdaki gibi çalışır:

---

#### **1. Tüm Öğrencileri Listeleme**
**Seçim:** *1*  
**Sonuç:**  
Tüm öğrencilerin şube, numara, ad, soyad, ortalama ve okudukları kitap sayısı gibi bilgileri listelenir. Örnek çıktı:

```
Şube       No         Ad         Soyad      Ortalama      Okuduğu Kitap Sayısı
------------------------------------------------------------------------------
A          101        Ahmet      Yılmaz     78.5          3
B          102        Ayşe       Demir      85.0          2
C          103        Mehmet     Çelik      92.0          4
```

---

#### **2. Adres Ekleme**
**Seçim:** *2*  
**Kullanıcıdan İstenen:**  
- Öğrencinin numarası.  
- Şehir ve ilçe bilgileri.  

**Sonuç:**  
Belirtilen numaraya sahip öğrencinin adres bilgileri eklenir ve başarıyla kaydedildiği mesajı ekrana yazdırılır:

```
Lütfen öğrencinin numarasını giriniz: 101
Şehir: Ankara
İlçe: Çankaya
Adres bilgisi başarıyla kaydedildi.
```

---

#### **3. Not Ekleme**
**Seçim:** *3*  
**Kullanıcıdan İstenen:**  
- Öğrenci numarası.  
- Ders adı ve notu.  

**Sonuç:**  
Belirtilen öğrencinin ilgili dersine not eklenir. Örnek çıktı:

```
Lütfen öğrencinin numarasını giriniz: 101
Ders Adı: Matematik
Not: 95
Not başarıyla eklendi.
```

---

#### **4. Kitap Ekleme**
**Seçim:** *4*  
**Kullanıcıdan İstenen:**  
- Öğrenci numarası.  
- Kitap adı.  

**Sonuç:**  
Belirtilen öğrencinin okuduğu kitap listesine yeni kitap eklenir. Örnek çıktı:

```
Lütfen öğrencinin numarasını giriniz: 102
Kitap Adı: Suç ve Ceza
Kitap başarıyla eklendi.
```

---

#### **5. Belirli Öğrenci Bilgilerini Listeleme**
**Seçim:** *5*  
**Kullanıcıdan İstenen:**  
- Öğrenci numarası.  

**Sonuç:**  
Girilen numaraya sahip öğrencinin tüm bilgileri detaylı bir şekilde ekrana yazdırılır. Örnek çıktı:

```
Numara: 101
Ad: Ahmet
Soyad: Yılmaz
Şube: A
Ortalama: 78.5
Okuduğu Kitaplar: 
1. Savaş ve Barış
2. Simyacı
Adres: Ankara / Çankaya
```

---

#### **6. Öğrenci Ortalamalarını Listeleme**
**Seçim:** *6*  
**Sonuç:**  
Tüm öğrencilerin ders notlarına göre hesaplanan ortalamaları listelenir. Örnek çıktı:

```
Numara: 101 - Ad: Ahmet Yılmaz - Ortalama: 78.5
Numara: 102 - Ad: Ayşe Demir - Ortalama: 85.0
Numara: 103 - Ad: Mehmet Çelik - Ortalama: 92.0
```

---

### **📌 Kullanıcının Karşılaşacağı Durumlar**

1. **Hatalı Numara Girişi:**  
   Eğer kullanıcı, sistemde olmayan bir öğrenci numarası girerse şu mesaj ile bilgilendirilir:

   ```
   Hata: Girilen numaraya ait öğrenci bulunamadı.
   ```

2. **Eksik Veri Girişi:**  
   Kullanıcı eksik veya hatalı bilgi girerse tekrar denemesi istenir:

   ```
   Lütfen geçerli bir numara giriniz.
   ```

3. **Başarılı İşlemler:**  
   Her başarılı işlem sonunda işlem onay mesajı gösterilir:

   ```
   İşlem başarıyla tamamlandı.
   ```

---

### **🎯 Projenin Kullanıcı Deneyimi**

Bu sistem, kullanıcıya her adımda rehberlik eder ve işlemleri kolaylaştırır. Kullanıcıların seçimlerine göre net ve açıklayıcı çıktılar sunar. Yeni özellikler eklemek veya mevcutları genişletmek için modüler bir altyapı sunar.
