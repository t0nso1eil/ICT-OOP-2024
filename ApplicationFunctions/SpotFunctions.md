# Функционал слота

### Получение доступных для записи окон психолога:

GET api/v1/psychologists/spots

**request**: { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response**:
```json
[{
    "spot_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "date" : "2024-03-01",
    "hour_start" : "09:00:00",
    "hour_end" : "10:00:00",
    "status" : "доступно"
},
{
    "spot_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "date" : "2024-03-01",
    "hour_start" : "10:00:00",
    "hour_end" : "11:00:00",
    "status" : "доступно"
},
{
    "spot_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "date" : "2024-03-02",
    "hour_start" : "14:00:00",
    "hour_end" : "15:00:00",
    "status" : "доступно"
}]
```

---

### Добавление нового окна для записи:

POST api/v1/psychologists/spots

**request**:
```json
{
    "psychologist_id" : "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "date" : "2024-02-27",
    "hour_start" : "04:00:00",
    "hour_end" : "07:00:00"
}
```

**response**: { 201 - OK }

---

### Получение расписания психолога:

GET api/v1/psychologists/schedule

**request**: { "psychologist_id" : "7febf16f-651b-43b0-a5e3-0da8da49e90d" }

**response**:
```json
[{
    "spot_id" : "a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p",
    "date" : "2024-03-01",
    "hour_start" : "09:00:00",
    "hour_end" : "10:00:00",
    "status" : "доступно"
},
{
    "spot_id" : "b2c3d4e5-f6g7-h8i9-j0k1-l2m3n4o5p6q",
    "date" : "2024-03-01",
    "hour_start" : "10:00:00",
    "hour_end" : "11:00:00",
    "status" : "занято"
},
{
    "spot_id": "c3d4e5f6-g7h8-i9j0-k1l2-m3n4o5p6q7r",
    "date": "2024-03-02",
    "hour_start": "14:00:00",
    "hour_end": "15:00:00",
    "status": "доступно"
}]
```

---