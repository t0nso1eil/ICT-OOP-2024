# Функционал сообщения


### Отправка сообщения:

POST api/v1/chats/messages

**request**:
```json
{
    "chat_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "sender_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "message_text" : "привет меня зовут апрель но друзья зовут меня играть в футбол"
}
```

**response**: { 201 - OK } или { "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

---

### Удаление сообщения:

DELETE api/v1/chats/messages

**request**: { "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

**response**: { 200 - OK }

---

### Редактировать сообщение:

PATCH api/v1/chats/messages

**request**:
```json
{
    "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "message_text" : "привет меня зовут апрель"
}
```

**response**: { 200 - OK }

---

### Получить все сообщения в чате:

GET api/v1/chats/messages

**request**: { "chat_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

**response**:
```json
[{
    "message_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "sender_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "message_text" : "Ты хочешь город? Я подарю Тверь",
    "post_time" : "2024-03-01 09:30:00"
},

{
    "message_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "sender_id" : "5p6o7i8u-9y0t-r1e2w-3q4a-s5d6f7g8h9j",
    "message_text" : "Хочешь побольше? Я подарю Пермь",
    "post_time" : "2024-03-01 10:15:00"
},

{
    "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "sender_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "message_text" : "Добрый день, я бы хотела записаться к психологу",
    "post_time" : "2024-03-02 14:00:00"
}]
```

---