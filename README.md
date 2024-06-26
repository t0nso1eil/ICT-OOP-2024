# ICT-OOP-2024

## Команда  12

**Тема:** Платформа для онлайн-консультаций с психологом (название - Все дело в папе)

| Состав команды |
|:-----|
| Кадникова Екатерина Михайловна |
| Гуторова Инна Владимировна |
| Бахарева Мария Александровна |
| Могильный Михаил Игоревич |
| Полухин Александр Владимирович |

---

## Сущности и связи

### ERD-диаграмма

![final](https://github.com/t0nso1eil/ICT-OOP-2024/assets/112972915/415412c8-e46e-4b80-9cb4-0eff0f6635c2)


### Связи:

`psychologist` 1:M  `review`

`psychologist` 1:M  `spot`

`psychologist` 1:1  `user`



`user` 1:M  `review`

`user` 1:M  `message`

`user` 1:M  `session`

`user` 1:M `chat`



`session` 1:1 `spot`


`message` M:1 `chat`



### Описание сущностей

#### Пользователь
Поля:
1) `user_id` - идентификатор пользователя (Guid/varchar) | генерируется, уникальный
2) `first_name` - имя (string/varchar)
3) `last_name` - фамилия (string/varchar)
4) `email` - электронная почта (string/varchar) | уникальна
5) `phone_number` - номер телефона (string/varchar)
6) `password` - пароль (string/varchar)
7) `birthday` - дата рождения (DateOnly/date)
8) `age` - возраст (uint/integer) | вычисляется на основе даты рождения
9) `sex` - пол (string/varchar) | значение выбирается из {"женщина", "мужчина"}
10) `additional_info` - дополнительная информация (string/text)
11) `registration_date` - дата и время регистрации (DateTime/timestamp) | создается автоматически при регистрации

#### Психолог:
Поля:
1) `psychologist_id` - идентификатор психолога (Guid/varchar) | генерируется, уникальный
2) `specialization` - основные подходы в психотерапии, которыми пользуется специалист (string/varchar) | пример: КПТ, гештальт-терапия, психоанализ и тд
3) `price_per_hour` - стоимость одной сессии (decimal/numeric)
4) `experience_start_date` - дата начала практики (DateOnly/date)
5) `experience_years` - стаж работы (uint/integer) | вычисляется на основе даты начала практики
6) `rate` - средняя оценка психолога (decimal/numeric) | высчитывается как среднее из оценкок в отзывах
7) `user_id` - идентификатор пользователя (Guid/varchar)

#### Отзыв:
Поля:
1) `review_id` - идентификатор отзыва (Guid/varchar) | генерируется, уникальный
2) `rate` - оценка (uint/integer) | от 0 до 5
3) `description` - текстовый отзыв (string/text)
4) `post_time` - дата и время публикации отзыва (DateTime/timestamp) | создается автоматически при публикации
5) `psychologist_id` - идентификатор психолога, на которого оставили отзыв (Guid/varchar)
6) `user_id` - идентификатор пользователя, который оставил отзыв (Guid/varchar)

#### Сессия:
Поля:
1) `session_id` - идентификатор сессии (Guid/varchar) | генерируется, уникальный
2) `status` - статус (string/varchar) | значение выбирается из {"на согласовании", "ожидает оплаты", "назначена", "отменена", "проведена"}
3) `cost` - стоимость сессии (decimal/numeric) | берется из стоимости, прописанной у психолога
4) `user_id` - идентификатор пользователя, который записался на сессию (Guid/varchar)
5) `spot_id` - идентификатор окошка, в которое записались (Guid/varchar)

Комментарии:
1) Про статус сессии:
* сессия создается как заявка со статусом "на согласовании"
* психолог подтверждает: статус "ожидает оплаты"
* если оплата прошла условно в течение суток-двух, то статус "назначена", иначе - "отменена", освобождается окошко
* в случае неотмены после проведения статус обновляется на "проведена"
2) _На подумать_: удалять отмененную запись запись из бд условно через неделю

#### Окошко:
Поля:
1) `spot_id` - идентификатор окошка (Guid/varchar) | генерируется, уникальный
2) `date` - дата (DateOnly/date)
3) `hour_start` - время начала (DateTime/time)
4) `hour_end` - время окончания (DateTime/time)
5) `status` - статус (string/varchar) | значение выбирается из { "доступно", "занято" }
6) `psychologist_id` - идентификатор психолога (Guid/varchar)

Комментарии:
1) психолог добавляет в свое "расписание" доступные для записи окошки, которые могут видеть клиенты
2) клиент записывается в окошко, создается сессия (_см. [Сессия](README.md:72)_)

#### Сообщение:
Поля:
1) `message_id` - идентификатор окошка (Guid/varchar) | генерируется, уникальный
2) `message_text` - содержание сообщения (string/text)
3) `sent_time` - дата и время отправки (DateTime/timestamp) | создается автоматически при отправке
4) `chat_id` - идентификатор чата (Guid/varchar)
5) `sender_id` - идентификатор отправителя (Guid/varchar)

#### Чат:
Поля:
1) `chat_id` - идентификатор чата (Guid/varchar) | генерируется, уникальный
2) `user_1_id` - идентификатор первого пользователя (Guid/varchar)
3) `user_2_id` - идентификатор второго пользователя (Guid/varchar)

---

## Методы работы приложения

Методы работы приложения описаны в папке [ApplicationFunctions](ApplicationFunctions)