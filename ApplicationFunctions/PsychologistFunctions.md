# Функционал психолога

### Регистрация нового психолога:

POST api/v1/psychologists

**request**:
```json
{ 
    "first_name": "имя",
    "last_name" : "фамилия",
    "email": "pochta@mail.ru",
    "password": "парольчикб",
    "birthday" : "2004-10-08",
    "sex" : "ма генда",
    "specialization" : "основные направления",
    "experience_start_date" : "2015-01-01",
    "additional_info" :  "приготовлю печенье",
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

**request**: {}

**response**:
```json
[{
    "first_name" : "Анна",
    "last_name" : "Иванова",
    "email" : "anna.ivanova@example.com",
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

### Обновление профиля психолога (общий вид):

PATCH api/v1/psychologists/{psychologist_id}

**request**: 
```json
{
    "first_name" : "теперь-меня-зовут-олег",
    "additional_info" : "я люблю людей"
}
```
**response**: { 200 - OK }

---

### Обновление имени и фамилии:

PATCH api/v1/psychologists/{psychologist_id}/full_name

**requests**:
```json
{
    "first_name" : null,
    "last_name" : "я-вышла-замуж"
}
```

**response**: { 200 - OK }

---

### Обновление пароля:

PATCH api/v1/psychologists/{psychologist_id}/password

**requests**: {
"password": "паучикапау"
}

**response**: { 200 - OK }

---

### Обновление цены за сессию:

PATCH api/v1/psychologists/{psychologist_id}/price

**requests**: {
"price_per_hour" : 10000.0
}

**response**: { 200 - OK }

---

### Обновление специализации:

PATCH api/v1/psychologists/{psychologist_id}/specialization

**requests**: {
"specialization" : "кпт"
}

**response**: { 200 - OK }

---

### Обновление дополнительной информации:

PATCH api/v1/psychologists/{psychologist_id}/additional_info

**requests**: {
"additional_info": "я крутой психолог честно"
}

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

### Получение отзывов на психолога:

GET api/v1/psychologists/{psychologist_id}/reviews

**request**: {}

**response**: 
```json
[{
    "review_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "client_id" : "9i8h7g-6f5e-d4c3-b2a1-0p9o8i7u6y5t",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "rate" : 5,
    "description" : "Отличный психотерапевт, очень внимательный и понимающий",
    "post_time" : "2024-02-26 08:30:45"
},
{
    "review_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "client_id" : "8h7g6f-5e4d-c3b2-a1p0-o9i8u7y6t5r",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "rate" : 4,
    "description" : "Хороший специалист, помог мне справиться с проблемами",
    "post_time" : "2024-02-25 10:15:30"
},
{
    "review_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "client_id" : "7h6g5f-4e3d-c2b1-a0p9-o8i7u6y5t4r",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "rate" : 3,
    "description" : "Предлагал печеньки и называл пупсиком, НО не смеялся над моими шутками про отца, а печенье было с изюмом",
    "post_time" : "2024-02-24 14:20:10"
}]
```

---

### Получение доступных для записи окон психолога:

GET api/v1/psychologists/{psychologist_id}/spots

**request**: {}

**response**: 
```json
[{
    "spot_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "date" : "2024-03-01",
    "hour_start" : "09:00:00",
    "hour_end" : "10:00:00",
    "status" : "доступно"
},
{
    "spot_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "date" : "2024-03-01",
    "hour_start" : "10:00:00",
    "hour_end" : "11:00:00",
    "status" : "доступно"
},
{
    "spot_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "date" : "2024-03-02",
    "hour_start" : "14:00:00",
    "hour_end" : "15:00:00",
    "status" : "доступно"
}]
```

---

### Добавление нового окна для записи:

POST api/v1/psychologists/{psychologist_id}/spots

**request**:
```json
{
    "date" : "2024-02-27",
    "hour_start" : "04:00:00",
    "hour_end" : "07:00:00"
}
```

**response**: { 201 - OK }

---

### Получение расписания психолога:

GET api/v1/psychologists/{psychologist_id}/schedule

**request**: { }

**response**:
```json
[{
    "spot_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "date" : "2024-03-01",
    "hour_start" : "09:00:00",
    "hour_end" : "10:00:00",
    "status" : "доступно"
},
{
    "spot_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "date" : "2024-03-01",
    "hour_start" : "10:00:00",
    "hour_end" : "11:00:00",
    "status" : "занято"
},
{
    "spot_id": "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "psychologist_id": "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "date": "2024-03-02",
    "hour_start": "14:00:00",
    "hour_end": "15:00:00",
    "status": "доступно"
}]
```

---

