# ICT-OOP-2024

### Команда  12 

**Тема:** Платформа для онлайн-консультаций с психологом

**Состав команды:** 

* Кадникова Екатерина Михайловна
* Гуторова Инна Владимировна
* Бахарева Мария Александровна
* Могильный Михаил Игоревич
* Полухин Александр Владимирович

---

Методы работы приложения описаны в папке [ApplicationFunctions](ApplicationFunctions)

![telegram-cloud-photo-size-2-5393145139318347530-y](https://github.com/t0nso1eil/ICT-OOP-2024/assets/112972915/7dc1882c-023b-4dbb-ab9f-f79f537a3358)


Расписанеи психолога -> окошки (и для психолога сесссии)

Удалять отмененную запись запись из бд условно через неделю

Про сессию: 
1) сессия создается как заявка со статусом "на согласовании"
2) психолог подтверждает: статус "ожидает оплаты"
3) если оплата прошла условно в течение суток-двух, то статус "назначена", иначе - "отменена", освобождается окошко
4) в случае неотмены после проведения статус обновляется на "проведена"


