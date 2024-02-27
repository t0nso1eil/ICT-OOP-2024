# Функционал отзыва

### Оставить отзыв на психолога:

POST api/v1/psychologists/{psychologist_id}/reviews

**request** - {
"client_id":"",
"rate": 4,
"description": "он 10/10, но его зовут Никита",
"post_time":"2024-02-27 12:52:52"
}

**response** - {201 - OK}

---

### Изменение отзыва на психолога: 

PATCH api/v1/psychologists/{psychologist_id}/reviews/{review_id}

**request** - {
"rate": null,
"description": "он 10/10, но его зовут Никита, к тому же одержим 52"
}

**response** - {200 - ОК}

---

### Удаление отзыва

DELETE api/v1/psychologists/{psychologist_id}/reviews/{review_id}

**request** - {}

**response** - {200 - OK}
