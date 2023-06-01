// Объявление переменной `objFive` типа `object` и присвоение ей значения переменной `intfive`.
object objFive = intfive;

// Объявление и инициализация переменной `intFive2` типа `int` со значением 5.
int intFive2 = 5;

// Объявление переменной `objFive2` типа `object` и присвоение ей значения переменной `intFive2`.
object objFive2 = intFive2;

// Проверка на равенство значений переменных `intfive` и `intFive2` с помощью оператора `==`.
// Результат сравнения сохраняется в переменной `isIntEqual`.
bool isIntEqual = intfive == intFive2;

// Вывод результата сравнения значений переменных `intfive` и `intFive2`.
Console.WriteLine(isIntEqual);

// Проверка на равенство объектов `objFive` и `objFive2` с помощью оператора `==`.
// Результат сравнения сохраняется в переменной `isObjEqual`.
bool isObjEqual = objFive == objFive2;

// Вывод результата сравнения объектов `objFive` и `objFive2`.
Console.WriteLine(isObjEqual);
