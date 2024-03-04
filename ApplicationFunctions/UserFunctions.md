# Функционал пользователя

### Регистрация нового пользователя:

POST api/v1/users

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
    "additional_info" : "я люблю собак"
}
```
**response**: { "user_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 201 - OK }

---

### Получение профиля пользователя:

GET api/v1/users

**request**: { "user_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response**:
```json
{
    "first_name": "имя",
    "last_name" : "фамилия",
    "email": "pochta@mail.ru",
    "phone_number" : "+79092479999",
    "birthday": "2004-10-08",
    "age" : 19,
    "sex" : "женщина",
    "additional_info" : "я люблю собак",
    "registration_date" : "2024-02-27"
}
```
---

### Обновление профиля пользователя:

PATCH api/v1/users

**request**:
```json
{
      "user_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d",
      "first_name": "новая-имя",
      "last_name" : null,
      "email": null,
      "phone_number" : null,
      "password": "новый парольчикб",
      "birthday": null,
      "sex" : null,
      "additional_info" : "я люблю еще и кошек"
}
```

**response**: { "user_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" } или { 200 - OK }

---




