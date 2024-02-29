# Функционал чата

### Создание чата:

POST api/v1/chats

**request**:
```json
{ 
    "client_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d"
}
```

**response**: { 201 - OK } или { "chat_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

---

### Удаление всего чата:

DELETE api/v1/chats

**request**: { "chat_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

**response**: { 200 - OK } 

---

### Получить сообщения в чате: 

GET api/v1/chats/{chat_id}/messages

**request**: {}

**response**:
```json
[{
    "message_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "client_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "psychologist_id" : null,
    "message_text" : "Ты хочешь город? Я подарю Тверь",
    "post_time" : "2024-03-01 09:30:00"
},

{
    "message_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "client_id" : null,
    "psychologist_id" : "5p6o7i8u-9y0t-r1e2w-3q4a-s5d6f7g8h9j",
    "message_text" : "Хочешь побольше? Я подарю Пермь",
    "post_time" : "2024-03-01 10:15:00"
},

{
    "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "client_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "psychologist_id" : null,
    "message_text" : "Добрый день, я бы хотела записаться к психологу",
    "post_time" : "2024-03-02 14:00:00"
}]
```

---




