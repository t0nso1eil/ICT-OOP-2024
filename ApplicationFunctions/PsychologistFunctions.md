# Функционал психолога

### Регистрация нового психолога:

POST api/v1/psychologists

**request**:
```json
{
    "first_name": "имя",
    "last_name" : "фамилия",
    "email": "pochta@mail.ru",
    "phone_number" : "+79092479999",
    "password": "парольчикб",
    "birthday": "2004-10-08", 
    "sex" : "женщина",
    "additional_info" : "я люблю собак",
    "specialization" : "основные направления",
    "experience_start_date" : "2015-01-01",
    "price_per_hour" : 4000.0
}
```

**response**: { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 201 - OK } 

---

### Получение профиля психолога:

GET api/v1/psychologists

**request**: { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response**:
```json
{
    "first_name": "имя",
    "last_name" : "фамилия",
    "email": "pochta@mail.ru",
    "phone_number" : "+79092479999",
    "birthday" : "2004-10-08",
    "age" : 19,
    "sex" : "ма генда",
    "specialization" : "основные направления",
    "experience_start_date" : "2015-01-01",
    "experience_years" : 9,
    "additional_info" :  "приготовлю печенье",
    "price_per_hour" : 4000.0,
    "rate" : 4.2,
    "registration_date" : "2024-02-02"
}
```

---

### Получение всех психологов:

GET api/v1/psychologists

**request**: { }

**response**:
```json
[{
    "first_name" : "Анна",
    "last_name" : "Иванова",
    "email" : "anna.ivanova@example.com",
    "phone_number" : "+79092479999",
    "birthday" : "1985-05-15",
    "age" : 39,
    "sex" : "женский",
    "specialization" : "клиническая психология, семейная терапия",
    "experience_start_date" : "2010-09-20",
    "experience_years" : 11,
    "additional_info" : "Имею опыт работы с детьми и взрослыми, провожу индивидуальные и групповые сеансы",
    "price_per_hour" : 5000.0,
    "rate" : 4.7,
    "registration_date" : "2023-08-12"
},

{
    "first_name" : "Михаил",
    "last_name" : "Петров",
    "email" : "mikhail.petrov@example.com",
    "phone_number" : "+79092479999",
    "birthday" : "1978-12-10",
    "age" : 46,
    "sex" : "мужской",
    "specialization" : "когнитивно-поведенческая терапия, работа с зависимостями",
    "experience_start_date" : "2005-03-25",
    "experience_years" : 19,
    "additional_info" : "Специализируюсь на проблемах ангста и депрессии",
    "price_per_hour" : 5500.0,
    "rate" : 4.9,
    "registration_date" : "2022-11-30"
},

{
    "first_name": "Елена",
    "last_name": "Смирнова",
    "email": "elena.smirnova@example.com",
    "phone_number" : "+79092479999",
    "birthday": "1992-07-20",
    "age": 30,
    "sex": "женский",
    "specialization": "психотерапия личности, работа с травмами",
    "experience_start_date": "2017-04-15",
    "experience_years": 7,
    "additional_info": "Имею опыт работы с жертвами домашнего насилия и людьми с психическими расстройствами",
    "price_per_hour": 4500.0,
    "rate": 4.5,
    "registration_date": "2023-05-18"
}]
```

---

### Обновление профиля психолога:

PATCH api/v1/psychologists

**request**: 
```json
{
  "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d",
  "first_name": "имя",
  "last_name" : "фамилия",
  "email": "pochta@mail.ru",
  "phone_number" : "+79092479999",
  "password": "парольчикб",
  "birthday": "2004-10-08",
  "sex" : "женщина",
  "additional_info" : "я люблю собак",
  "specialization" : "основные направления",
  "experience_start_date" : "2015-01-01",
  "price_per_hour" : 4000.0
}
```
**response**: { 200 - OK }

---

### Получение психологов по фильтру цена:

GET api/v1/psychologists?price_min={price_min}&price_max={price_max}

**request**:
```json
{
    "price_min" : 1500.0,
    "price_max" : 2000.0
}
```

**response**:
```json
{
    "first_name" : "имя",
    "last_name" : "фамилия",
    "email": "pochta@mail.ru",
    "birthday" : "2004-10-08",
    "age" : 19,
    "sex" : "ма генда",
    "specialization" : "основные направления",
    "experience_start_date" : "2015-01-01",
    "experience_years" : 9,
    "additional_info" :  "приготовлю печенье",
    "price_per_hour" : 1900.0,
    "rate" : 4.2,
    "registration_date" : "2024-02-02"
}
```

---

### Получение психологов по фильтру оценка:

GET api/v1/psychologists?rate_min={rate_min}&rate_max={rate_max}

**request**:
```json
{
    "rate_min" : 4.2,
    "rate_max" : 5.0
}
```

**response**:
```json
[{
    "first_name" : "имя",
    "last_name" : "фамилия",
    "email": "pochta@mail.ru",
    "birthday" : "2004-10-08",
    "age" : 19,
    "sex" : "ма генда",
    "specialization" : "основные направления",
    "experience_start_date" : "2015-01-01",
    "experience_years" : 9,
    "additional_info" :  "приготовлю печенье",
    "price_per_hour" : 1900.0,
    "rate" : 4.3,
    "registration_date" : "2024-02-02"
},
{
    "first_name" : "имя",
    "last_name" : "фамилия",
    "email": "drugayapochta@mail.ru",
    "birthday" : "2003-11-08",
    "age" : 20,
    "sex" : "ма генда",
    "specialization" : "основные направления",
    "experience_start_date" : "2015-01-01",
    "experience_years" : 9,
    "additional_info" :  "приготовлю печенье",
    "price_per_hour" : 1900.0,
    "rate" : 4.3,
    "registration_date" : "2024-01-01"
}]
```

---

