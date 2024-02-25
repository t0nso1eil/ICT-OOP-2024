# Функционал клиента

### Регистрация нового клиента:

POST api/v1/clients/add

**request** - { "first_name": "имя", 
"last_name" : "фамилия", 
"email": "pochta@mail.ru",
"password": "парольчикб",
"phone" : "+79092479999"",
"additional_info" : "я люблю собак"
"birthday": "2004-10-08",
"sex" : "female"
}

**response** - { "client_id":"7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 201 - OK }

----------

### Получение профиля клиента:

GET api/v1/clients

**request** - { "id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d"}

**response** - { "first_name": "имя",
"last_name" : "фамилия",
"email": "pochta@mail.ru",
"registration_date" : "2024-02-25 03:14:07"
"phone" : "+79092479999"",
"additional_info" : "я люблю собак"
"birthday": 8.10.2004,
"sex" : "female"
}

------------

### Обновление профиля клиента:

POST api/v1/clients/update

**request** - { }

**response** - { }

------------

### Написание отзыва на психолога

-----------

### Отправка сообщения в чат с психологом

-----------

### Удаление сообщения


