# Функционал отзыва

### Оставить отзыв на психолога:

POST api/v1/psychologists/{psychologist_id}/reviews

**request**:
```json
{
    "client_id" : "",
    "rate" : 4,
    "description" : "он 10/10, но его зовут Никита"
}
```

**response**: { 201 - OK } или { "review_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7" }

---

### Изменение отзыва на психолога: 

PATCH api/v1/psychologists/{psychologist_id}/reviews/{review_id}

**request**:
```json
{
    "rate" : null,
    "description" : "он 10/10, но его зовут Никита, к тому же он близнецы"
}
```
**response**: { 200 - ОК }

---

### Удаление отзыва

DELETE api/v1/psychologists/{psychologist_id}/reviews

**request**: { "review_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7" }

**response**: { 200 - OK }
