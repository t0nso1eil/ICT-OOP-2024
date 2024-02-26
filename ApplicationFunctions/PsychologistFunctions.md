# Функционал психолога

### Регистрация нового психолога:

POST api/v1/psychologists/add

**request** - { 
"first_name": "имя",
"last_name" : "фамилия",
"email": "pochta@mail.ru",
"password": "парольчикб",
"specialization" : "основные направления",
"experience_years" : 9,
"working_hours_start" : "9:00:00",
"working_hours_end" : "21:00:00",
"price_per_hour" : 4000.0
}

**response** - { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 201 - OK} 

---

### Получение профиля психолога:

GET api/v1/psychologists

**request** - { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response** - {
"first_name": "имя",
"last_name" : "фамилия",
"email": "pochta@mail.ru",
"registration_date" : "2024-02-25 03:14:07",
"specialization" : "основные направления",
"experience_years" : 9,
"working_hours_start" : "9:00:00",
"working_hours_end" : "21:00:00",
"price_per_hour" : 4000
}

---

### Обновление профиля психолога (общий вид):

PATCH 

**request** - { }

**response** - { 200 - OK }

---

### Обновление имени и фамилии:

PATCH api/v1/

**requests** - {
"first_name": "null",
"last_name" : "я-вышла-замуж"
}

**response** - { 200 - OK }

---

### Обновление пароля:

PATCH api/v1/

**requests** - {
"password" : "паучикапау"
}

**response** - { 200 - OK }

_добавить метод на проверку пароля (совпадение для верификации)_

---

### Обновление цены за сессию:

PATCH api/v1/

**requests** - {
}

**response** - { 200 - OK }

---

### Обновление специализации:

PATCH api/v1/

**requests** - {
}

**response** - { 200 - OK }

---

### Обновление дополнительной информации:

PATCH api/v1/

**requests** - {
"additional_info" : "я больше не люблю собак"
}

**response** - { 200 - OK }

---

### Получение психологов по фильтру цена +/ оценка:

GET api/v1/psychologists

**request** - { }

**response** - { }

---

### Получение отзывов на психолога:

GET api/v1/psychologists/{psychologist_id}/reviews

**request** - { }

**response** - { }

---

### Получение доступных для записи окон психолога:

GET api/v1/psychologists

**request** - { }

**response** - { }

---

### Получение расписания психолога:

GET api/v1/psychologists

**request** - { }

**response** - { }

---

