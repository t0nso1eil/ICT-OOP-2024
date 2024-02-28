# Функционал сообщения


### Отправка сообщения клиентом:

POST api/v1/chats/{chat_id}/messages

**request** - {
"client_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
"psychologist_id" : null,
"message_text" : "привет меня зовут апрель но друзья зовут меня играть в футбол"
}

**response** - {201 - OK} или { "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

---

### Отправка сообщения психологом:

POST api/v1/chats/{chat_id}/messages

**request** - {
"client_id" : null,
"psychologist_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
"message_text" : "привет меня зовут апрель но друзья зовут меня играть в футбол"
}

**response** - {201 - OK} или { "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

---

### Удаление сообщения:

DELETE api/v1/chats/{chat_id}/messages

**request** - { "message_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r" }

**response** - { 200 - OK }

---

### Редактировать сообщение:

PATCH api/v1/chats/{chat_id}/messages/{massage_id}

**request** - {
"message_text" : "привет меня зовут апрель"
}

**response** - { 200 - OK }

---