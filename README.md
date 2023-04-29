# HotelMS
## **HotelMS** loyihasi haqida;
### Bu dasturni yaratishimizdan maqsad o'z tajribamizni oshirish va ko'nikma hosil qilish, jamoaviy ishlash muhitini his qilish va bu muhitga moslashishni o'rganishimiz uchun va yana otilgan darslarimizni takrorlash maqsadida yaratdik.
_____
# Dastur nima qila olishi haqida;
>  * Foydalanuvchilarni ro'yxatga olish;
> * Xona buyurtma qilish;
> * Xarajatlarni xisoblash;
> * To'lov qilish;
> * Mehmonxonalarda bajariluvchi boshqa amallar:

# Dasturni ishga tushirish uchun kompyuterni sozlash;

1. *`appsettings.json`* ga kirasiz va ushbu kodni yozasiz:
```C Sharp  
"ConnectionStrings": {
    "DefaultConnect": "user id=postgres; password=PgAdmin kodini kiriting; server=localhost; port=5432; database=Database nomini kiriting; pooling=true"},
```
2. *`Tools/NuGet Package Manager/Package Manager Console`* ga kiriladi
3. `add-database` o'zingiz `nom kritasiz` kiritiladi
4. *`update-database`* kiritiladi
