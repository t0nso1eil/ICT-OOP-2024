# Функционал сессии

### Создание сессии (заявки на сессию):

POST api/v1/sessions

**request**:
```json
{
    "client_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "spot_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7"
}
```

**response**: { 201 - OK } или { "session_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7"}

---

### Обновление статуса сессии:

POST api/v1/sessions/{session_id}

**request**:
```json
{ 
    "session_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "status": "проведена"
}
```

**response**: { 200 - OK }

---

### Получение сессий пользователя:

GET api/v1/users/sessions

**request**: { "user_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response**:
```json
[{
    "session_id": "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "spot_id": "2a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "status": "проведена",
    "cost": 3000.0
},

{
    "session_id": "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "spot_id": "2a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "status": "на согласовании",
    "cost": 5000.0
}]
```

---
