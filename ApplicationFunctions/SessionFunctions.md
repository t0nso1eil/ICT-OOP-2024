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

**request**: { 
"status": "проведена"
}

**response**: { 200 - OK }

---

