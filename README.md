Asp.net MVC üzerine DevExpress MVC Extension çalışmalarım.

1. Gridview 

Callback partial view şeklinde çalışmaktadır. 
Kategoriye göre ürünler radio button ve text (Viewcontext) şeklinde gelmektedir. 
Band kullanıldı.
Excel export kullanıldı.  

2. Gridview (Server Mode)
Büyük veriler için direkt entity bağlantısını vererek yapılmıştır.
Bu şekilde sayfalama, sıralama vs. sqlde yapılmaktadır. 120 den sonra where in ile ilerler.
View tarafında db instance alındı static classda yapılabilir.

3. Dropdownlist Combobox
Model verilerek liste doldurulmaktadır.
İlk çalıştırma hızlı olması içindir. 
Yine Callback mantığında Select items daha az dolu gelir. 

4. Dropdownlist Combobox (ViewBag Mode)
Viewbag ile doldurulup sayfa dolu gelir ancak tekrardan veri tabanına gitmez.
Static Iqueryable ile yapılmıştır.

#Devexpress #devexpressmvc #mvc #mvcextensions
