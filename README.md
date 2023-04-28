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

1. Dasturni ishga tushirasiz;
2. *`appsettings.json`* ga kirasiz va 1-qatordan Enter tugmani bosib 2-qatorda ushbu kodni yozishingiz zarur:
```C Sharp  
"ConnectionStrings": {
    "DefaultConnect": "user id=postgres; password=PgAdmin kodini kiriting; server=localhost; port=5432; database=Database nomini kiriting; pooling=true"},
```
3. *`Tools/NuGet Package Manager/Package Manager Console`* ga kiriladi
4. `add-database` o'zingi nom berasiz kiritiladi (*_enterni bosish esdan chiqmasin_*!)
5. *`update-database`* kiritiladi (_enterni bosish esdan chiqmasin_!)
6. Dasturni **`Run`** qilsangiz bo'ladi