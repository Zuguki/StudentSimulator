># **Student Simulator**

# 1. Цель проекта.
Создать игру - симулятор студента, которая будет похожа механикой на игру: "*Бомжара*"

# 2. Описание игры.

## 2.1 Механика игры.

Предполагается, что игра будет похожа на игру: "*Бомжара*", но с особыми механиками и особенным сюжетом.

У пользователя, будет 5 сцен:

    1. Домашняя сцена, в которой можно пользователь может перейти в настройки,
    а так же увидеть текущие характеристики:
        * подготовка к экз / знания
        * уважение
        * знакомства
        * деньги
    2. Сцена, в которой можно увеличить характеристики подготовки к экз.
    3. Сцена, в которой можно увеличить характеристики уважения.
    4. Сцена, в которой можно увеличить характеристики знакомств.
    5. Сцена, в которой можно увеличить характеристики денег.

На сценах, пользователь может улучшать свои характеристики, для дальнейшей сдачи экзаменов. 

### 2.1.1 Сдача экзамена.

Пользователь может сдать экзамен при условии, что у него будут характеристики больше чем 80%.

Примеры, для сдачи экзаменов:

    1. При большом уровне подготовки.
    2. При большом уровне уважения и достаточно большом кол-ве знакомств (Списать).
    3. При большом кол-ве денег, можно купить хорошее решение экзаменов.

Так же есть вероятность не сдачи при плохих характеристиках уважения. (Будут строить козни, для твоего отчисления)

### 2.1.2 Характеристики подготовки к экзаменам.

При подготовки к экзаменам можно выбрать следующие пункты:

    1. Списать у одногрупника, пока он не видет (может ухудшиться репутация)
    2. Готовиться самому (придется решить задачу)
    3. Готовиться по учебникам (придется купить учебники)
    4. Попросить конспекты у одногрупников (должна быть высокая репутация)
    5. Купить видео курс по подготовке (5000rub)
    6. Нанять репетитора (5000rub / month)

    * Купить учебник (500rub)

### 2.1.3 Характеристики уважения.

Поскольку наш студент живет в общаге, у него достаточно много знакомых, только вот нужно проявлять себя с лучших сторон.

    1. Поделиться жижей с соседом (10мл жижи)
    2. Открыть дверь в общагу ночью (Может ухудшиться учеба)
    3. Помочь с домашкой (При высоких х-ках знаний)
    4. Делать базу ответов (Уменьшается количество знакомств)
    5. Позвать одногрупников в KillFish (1000rub)
    6. Заказать на соседей еды (1000rub)

### 2.1.4 Характеристики знакомств.

Хоть если у нашего студента будет мало друзей, но много уважения, 
вряд ли у него получится списать экзамены, ведь друзей может не оказаться с ним в аудитории. 

    1. Участвовать в ивенте от вуза (Труднее дается учеба)
    2. Менторить чатики групп (Труднее дается учеба)
    3. Скорешиться с сопрами (должно быть высокие х-ки уважения)
    4. Пойти на алейку (500rub)
    5. Приготовить еду в общаге (500rub)

### 2.1.5 Характеристики денег.

Ну, деньги всегда нужны, изначально наш студент находится на стипендии, если хорошо сдаст экзамены,
перейдет на повышку.

    *Жижи*
    1. Залить жижу соседа, пока он не видет (может ухудшиться репутация)
    2. Попросить у знакомых жижи (могут отказать)
    3. Забрать жижу у сопров (должно быть высокое уважение)

    *Деньги*
    1. Починить подик знакомому (должно быть много знакомых)
    2. Продать конспекты (нужны хорошие х-ки знаний)
    3. Продать учебники (нужно купить их)

## 2.2 Мехарика повышения характеристик.

Для того, что бы не делать кликер, решил, что за одно нажатие можно получить достаточно много exp, за прохождение мини игр.

## 2.3 Вариации Мини игр.

> Если останется время, то будет добавленно

## 2.4 *ЖИЖА*

Жижа в игре, как отдельный вид зароботка и повышения характеристик.
Жижу в любой момент можно продать на домашней странице, так же как и купить, но курс жижи постоянно варируется.

## 2.5 Чуть больше сюжета

Наш студент приехал с севера, получать знания, и завести новых друзей, ему нельзя завалить экзамены и вылетить из общаги. 
> Пока не много добавил, дальше будет еще больше сюжета, а имя студенты давайте сейчас придумаем...

# Цели на следующую пару 4/18/22

~~Добавить информацию в текущие х-ки.~~

~~Дописть README.~~

~~Добавить новую информацию в сцены.~~

# Цели на следующую пару 5/2/22

~~Переделать подгрузку кнопок.~~

~~Сделать MVP.~~

# Цели на следующую пару 5/16/22

~~Сделать дизайн для кнопок переключения~~

~~Сделать дизайн для кнопок отображения~~

~~Выбрать шрифт для игры~~

Сделать магазин

Сделать главную страницу

# Цели на следующую пару 5/23/22

~~Добавить дизайн кнопки назад, время~~

~~Добавить время до экзаменов~~

~~Добавить отображение стоимости~~

~~Добавить StatsPage~~

~~Добавить шрифты для TMP~~

~~Сделать вывод уведомлений в UI~~

~~Добавить магазин~~

~~Добавить покупку с магазина~~

~~Обновить UI~~

# Цели на следующую пару 5/31/22

~~Сделать проигрышь/победу игрока~~

~~Добавить сохранение игры~~

~~Добавить возможность покупки/продажи жижла~~

~~Добавить разукраску характеристик при улучшении/ухудшении~~

~~Добавить унижения игрока(ухудшение характеристик при прокачке чего то 1го)~~

~~Добавить разные тексты для ивент сообщений~~

~~Заменить экономику~~

~~Сделать иконку для билда~~

~~Сделать конвертер жижи (смена курса при смене дня)~~

~~Добавить возможность саморозки уведомления при наведении на него~~

~~Редизайн UI~~

~~Дать друзьям поиграть, для поиска багов~~

~~Фикс багов~~

~~Final Build~~



> Thx for Lessons
