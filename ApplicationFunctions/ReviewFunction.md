# Функционал отзыва

### Оставить отзыв на психолога:

POST api/v1/psychologists/reviews

**request**:
```json
{
    "client_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "psychologist_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o8",
    "rate" : 4,
    "description" : "он 10/10, но его зовут Никита"
}
```

**response**: { 201 - OK } или { "review_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7" }

---

### Изменение отзыва на психолога: 

PATCH api/v1/psychologists/reviews

**request**:
```json
{
    "review_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7",
    "rate" : null,
    "description" : "он 10/10, но его зовут Никита, к тому же он близнецы"
}
```
**response**: { 200 - ОК }

---

### Удаление отзыва

DELETE api/v1/psychologists/reviews

**request**: { "review_id" : "1a3b4c5d-6e7f-8g9h-0i1j-2k3l4m5n6o7" }

**response**: { 200 - OK }

---

### Получение отзывов на психолога:

GET api/v1/psychologists/reviews

**request**: { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response**:
```json
[{
    "review_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "user_id" : "9i8h7g-6f5e-d4c3-b2a1-0p9o8i7u6y5t",
    "rate" : 5,
    "description" : "Отличный психотерапевт, очень внимательный и понимающий",
    "post_time" : "2024-02-26 08:30:45"
},
{
    "review_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "user_id" : "8h7g6f-5e4d-c3b2-a1p0-o9i8u7y6t5r",
    "rate" : 4,
    "description" : "Хороший специалист, помог мне справиться с проблемами",
    "post_time" : "2024-02-25 10:15:30"
}]
```

---
