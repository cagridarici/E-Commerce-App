# E-Commerce 

Mail gönderim işlemlerinin asenkron olarak RabbitMQ tarafından yürütüldüğü , DDD prensiplerine göre kurgulanmış API uygulamasıdır. <br>
API UI olarak Swagger kullanılmaktadır. 

Projeyi Sorunsuz Çalıştırabilmek İçin Notlar : <br>

<b>1-)</b> Infrastructure > E-Commerce.Data > Consts.cs class'ında bulunan CONNECTION_STRING değerini kendi connection string bilginizle değiştirmelisiniz. <br> 
<b>2-)</b> E-Commerce.Data projesi üzerinden migration oluşturarak database'i güncellemelisiniz. <br> 
<b>3-)</b> RabbitMQ bilgileri makinenizde farklıysa Infrastructure > E-Commerce.Infrastructure > RabbitMQ > RabbitMQConfiguration class'ındaki bilgileri değiştirmelisiniz.<br>
<b>4-)</b> Presentation > E-Commerce.RabbitMQ.ConsumerApp > MailSenderHelper > MailSenderService class'ındaki SendRealMail değerine göre uygulama mail gönderilmiş gibi davranarak işlemleri simule etmektedir. Eğer gerçek mail gönderme işlemi yapılacaksa bu değer true'ya alınarak SMTPConfiguration class'ındaki bilgiler düzenlenmelidir.<br>



![alt text](https://i.ibb.co/7KZQk1k/Proje-Resmi.png)
