# Функционал чата

### Создание чата:

POST api/v1/chats

**request**:
```json
{ 
    "user_1_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "user_2_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d"
}
```

**response**: { 201 - OK } или { "chat_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

---

### Удаление всего чата:

DELETE api/v1/chats

**request**: { "chat_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

**response**: { 200 - OK } 

---




