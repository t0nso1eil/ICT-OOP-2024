# Функционал оплаты

### Изменить статус оплаты:

PATCH api/v1/sessions/{session_id}/payment

**request**: {
"status" : "оплачено"
}

**response**: {200 - OK}

---
