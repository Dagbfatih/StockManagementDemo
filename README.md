# StockManagementDemo
Stock management demo

## Hakkında
Bu proje hisse alım satım robotlarının algoritmasını simüle etmek amacıyla geliştirilmiştir.
Projenin kod kalitesine değil algoritmanın işleyişine odaklanılmıştır.

**Proje (https://www.amcharts.com/demos/stock-chart-candlesticks/#code) tarafındaki veriyi simüle etmektedir.**

## Mum Grafikleri
Algoritma için **candlesick chart pattern**'lerden yararlanılmıştır. Candlesick grafikleri bir hissenin bir zaman aralığında (ör:`1dk aralıkla`) değişimini gösteren grafiklerdir.
Bu grafikleri finans uzmanları okurken önemli 12 tane pattern den yararlanarak tahminde bulunurlar.

### **Bunlar**:
### Hisse Fiyatlarının Yükselişine İşaret Eden:
1- Hammer
2- Inverse Hammer
3- Morning Star
4- Bullish Engulfing
5- Piercing Line
6- Three White Soldiers

### Hisse Fiyatlarının Düşüşüne İşaret Eden:
7- Hanging Man
8- Dark Cloud Cover
9- Shooting Star
10- Bearish Engulfing
11- Evening Star
12- Three Black Crows

Bu yazılım ise bu pattern'lerden bazılarını tanımlayıp ona göre hisse alım satımı yapmaktadır.

## Algoritma
Sistem 3 ana entity'e sahiptir. Bunlar `Stock`, `Possibility` ve `Decision`'dır.
![Ekran görüntüsü 2023-11-19 113013](https://github.com/Dagbfatih/StockManagementDemo/assets/74913012/81da61c0-05ff-46da-ad25-e853014409dd)

`Stock`: Veritabanından gelen Hisseyi temsil eder.
![Ekran görüntüsü 2023-11-19 113625](https://github.com/Dagbfatih/StockManagementDemo/assets/74913012/86a85552-08fb-4841-94ac-21243659b2a7)

`Possibility`: **Olasılık Algoritması.** Stock'ların hangi Candlestick Pattern'ine uygun olduğuna göre ve önceki stock'ların durumlarına göre hisse fiyatının %? ihtimalle yükseleceğini ya da düşeceğini tahmin eder.
![Ekran görüntüsü 2023-11-19 113654](https://github.com/Dagbfatih/StockManagementDemo/assets/74913012/aa7b1a20-8044-46a7-876d-366c4dde824a)

`Decision`: **Karar Algoritması.** `Possiblity`'lere göre hissenin satın alınıp alınmaması gerektiğine karar veren sistemdir. Hisseyi `Sell`, `Buy` ya da `Keep` şeklinde üç durumla kontrol eder.
![Ekran görüntüsü 2023-11-19 113934](https://github.com/Dagbfatih/StockManagementDemo/assets/74913012/8b6d22bc-d869-488f-a972-00964ee4a6ff)

Algoritma bu şekilde ilerler. 
1. `Algorithms`/`CandleStick`/`TypeDetermineAlgorithm`/`DetermineCandleStickTypeAlgorithm.cs` ile bir anlık verinin hangi CandleStick Pattern'ine uygun olduğunu belirler.
2. `Possibility Algorithm` ile olasılıkları hesaplar.
3. `Decision Algorithm` ile kararı verir.

Buradaki 2. ve 3. işlemler için hesaplama işlemleri pattern'lere **dağıtılır** ve küçük parçalar halinde yönetilir.
Bu dağıtma işlemine karar veren `Distributor`'ler vardır.
Bunlar, hissenin pattern'ine göre hangi algoritma tarafından işleneceğine karar verir.
![Ekran görüntüsü 2023-11-19 112837](https://github.com/Dagbfatih/StockManagementDemo/assets/74913012/18074d2a-e632-4261-9ba5-4fc68053e9f6)
![Ekran görüntüsü 2023-11-19 112748](https://github.com/Dagbfatih/StockManagementDemo/assets/74913012/a7f8e2f9-f89f-4d0e-96a3-89afb30d5838)

### İş akışı:
1- Sistem bir repo ile verileri **.CSV** dosyasından çeker ve `Stock` modeli ile mapler.
2- Bu Stock'lar MainDistributor ile önce `PossibilityAlgorithm`'e gönderilir ve her birinin olasılıkları hesaplanır.
3- MainDistributor bu `Possibility`'leri aldıktan sonra `DecisionAlgorithm`'e gönderir ve `Decision`ları alır.
4- Bu decision'lar ekrana yazdırılır.

**Proje (https://www.amcharts.com/demos/stock-chart-candlesticks/#code) tarafındaki veriyi simüle etmektedir.**
**Eğer algoritmanın ne kadar doğru çalıştığını görmek isterseniz burayı kontrol ediniz.**

**Not:** Bu projede `Algorithm`ler dışındaki bölümlerin kod kalitesine dikkat edilmemiştir.

**İyi çalışmalar**
