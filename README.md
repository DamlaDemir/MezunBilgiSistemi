# Mezun Bilgi Sistemi 

**Gerçekleştirilen platform:** Visual Studio-2015 <br>
 **Problemin kısa tanımı:** Bir mezun bilgi sistemi geliştirilerek sistemde mezun olan öğrencileri ve şirketleri buluşturmak hedeflenmektedir. Sistem üzerinden şirketler İngilizce düzeyine, not ortalamasına, mezun olduğu bölüme göre, arama yapıp istedikleri öğrenciye hızlıca ulaşabilmelidir. 
Ayrıca sistem de şirket için en uygun mezunu belirleyebilmelidir. Öğrenciler de sistemdeki bilgilerini güncelleyebilmelidir.<br>
**Kullanılan dosya:** OgrenciBilgi.txt isimli dosyada kayıtlı olan mezun bilgileri başlangıçta sisteme çekilir.

### Kullanılan Sınıfların Açıklamaları <hr>
**OgrenciBilgi Sınıfı:** Bu sınıfta öğrencinin özellikleri tanımlıdır ve öğrenciye ait staj ve mezun bilgileri LinkedList şeklinde tutulmaktadır. 

**MezunBilgi Sınıfı:** Bu sınıf öğrenciye ait mezuniyet bilgilerine sahiptir.

**StajBilgi Sınıfı:** Bu sınıf öğrencinin yapmış olduğu  stajların bilgilerine sahiptir.

**Sirket Sınıfı:** Bu sınıf sisteme kayıt olan şirketlerin kayıt bilgilerine sahiptir.

**Node Sınıfı:**  Bu sınıf düğüm bilgisine sahiptir.

**ListADT Sınıfı:** Bu sınıfta abstract metotlar tanımlıdır. LinkedListMezun, LinkedListStaj ve  LinkedListSirket sınıfları bu sınıftan kalıtılmıştır.
       
**LinkedListMezun Sınıfı:** Öğrenciye ait mezun bilgileri liste şeklinde ikili arama ağacına bağlı olarak tutulur.
 
**LinkedListStaj Sınıfı:** Öğrenciye ait staj bilgileri liste şeklinde ikili arama ağacına bağlı olarak tutulur.

    
**LinkedListSirket Sınıfı:** Sisteme kayıt olan şirketlerin bilgileri liste şeklinde tutulur.


**IkiliAramaAgacDugumu Sınıfı:** Bu sınıf ikili arama ağacının düğüm bilgisine sahiptir.

**IkiliAramaAgaci Sınıfı:**



**HeapDugumu Sınıfı:** Bu sınıfta heap ağacı için düğüm bilgileri vardır.

**Heap Sınıfı:** Bu sınıfta heap ağacı oluşturularak öğrenciler eklenir.



**HashEntry Sınıfı:**

**HashMapChain Sınıfı:**

###	Kullanılan Veri Yapıları: <hr>

**LinkedList:** Bu veri yapısını ikili arama ağacı üzerinde öğrenciye ait mezun ve staj bilgilerini listelemede ve sisteme kayıt olan şirketlerin bilgilerini saklamakta kullanılır.

**İkili Arama Ağacı:** Bu veri yapısında öğrencileri, öğrenci numaralarına göre ağacın düğümlerine yerleştiriyoruz.

**Heap:**  Her bölüm için ayrı bir heap oluşturup heap içinde de öğrencilerin başarı derecelerine göre büyükten küçüğe  sıralayarak heap’in düğümlerine yerleştiriyoruz.

**Hash Table:** Anahtar olarak öğrenci bölümlerini gönderip bölüm adlarına göre indis bulunur. Aynı bölümdeki öğrenciler için de indisin içinde heap tutulur.

### Ekran Görüntüleri <hr>

![ekran görüntüsü 1](https://github.com/DamlaDemir/MezunBilgiSistemi/blob/master/MezunBilgiSistemiOdev/Images/1.png)

![ekran görüntüsü 2](https://github.com/DamlaDemir/MezunBilgiSistemi/blob/master/MezunBilgiSistemiOdev/Images/2.png)

![ekran görüntüsü 3](https://github.com/DamlaDemir/MezunBilgiSistemi/blob/master/MezunBilgiSistemiOdev/Images/3.png)

![ekran görüntüsü 4](https://github.com/DamlaDemir/MezunBilgiSistemi/blob/master/MezunBilgiSistemiOdev/Images/4.png)

