# Функционал клиента

### Регистрация нового клиента:

POST api/v1/clients/add

**request** - {
"first_name": "имя", 
"last_name" : "фамилия", 
"email": "pochta@mail.ru",
"password": "парольчикб",
"phone" : "+79092479999"",
"additional_info" : "я люблю собак",
"birthday": "2004-10-08",
"sex" : "женщина"
}

**response** - { "client_id":"7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 201 - OK }

---

### Получение профиля клиента:

GET api/v1/clients

**request** - { "client_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d"}

**response** - { 
"first_name": "имя",
"last_name" : "фамилия",
"email": "pochta@mail.ru",
"registration_date" : "2024-02-25 03:14:07"
"phone" : "+79092479999"",
"additional_info" : "я люблю собак",
"birthday": "2004-10-08",
"sex" : "женщина"
}

---

### Обновление профиля клиента (общий вариант):

PATCH api/v1/clients/update

**request** - {
"client_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d",
"first_name" : "теперь-меня-зовут-олег",
"additional_info" : "я люблю людей"
}

**response** - { "client_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 200 - OK }

---

### Обновление имени и фамилии:

PATCH api/v1/clients/{client_id}/update_full_name

**requests** - {
"first_name": "null",
"last_name" : "я-вышла-замуж"
}

**response** - { 200 - OK }

---

### Обновление пароля:

PATCH api/v1/clients/{client_id}/update_password

**requests** - {
"password" : "паучикапау"
}

**response** - { 200 - OK }

_добавить метод на проверку пароля (совпадение для верификации)_

---

### Обновление телефона:

PATCH api/v1/clients/{client_id}/update_phone_number

**requests** - {
"phone_number" : "89092479999"
}

**response** - { 200 - OK }

---

### Обновление дополнительной информации:

PATCH api/v1/clients/{client_id}/update_additional_info

**requests** - {
"additional_info" : "я больше не люблю собак"
}

**response** - { 200 - OK }

---

### Получение сессий:

**request** - { }

**response** - { }

---



