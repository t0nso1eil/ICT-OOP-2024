# Функционал чата

### Создание чата:

POST api/v1/chats/create/

**request** - { }

**response** - { }

---

### Удаление всего чата:

DELETE api/v1/chat/{chat_id}/delete

**request** - { }

**response** - { }

---

### Отправка сообщения клиентом:

POST api/v1/chats/{chat_id}

**request** - { } 

**response** - { }

---

### Отправка сообщения психологом:

POST api/v1/chats/{chat_id}

**request** - { }

**response** - { }

---

### Удаление сообщения:

DELETE api/v1/chats/{chat_id}

**request** - { }

**response** - { }

---

### Редактировать сообщение:

PATCH api/v1/chats/{chat_id}/edit/{massage_id}

**request** - { }

**response** - { }

---

### Получить сообщения в чате: 

GET api/v1/chats/{chat_id}

**request** - { }

**response** - { }

---




