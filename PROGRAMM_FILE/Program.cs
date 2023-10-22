// Задача: Написать программу,
// которая из имеющегося массива строк формирует новый массив из строк,
// длина которых меньше, либо равна 3 символам.
// Первоначальный массив можно ввести с клавиатуры,
// либо задать на старте выполнения алгоритма.
// При решении не рекомендуется пользоваться коллекциями,
// лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

// МЕТОД 1 (функция) - ЗАДАНИЕ натурального числа > 0,
// с контролем допустимости типа значения и величины, с рекурсией
int GetNumbIntContr(string message)
{
    Console.Write($"\n Задайте число {message}");
    string numberStr = Console.ReadLine();
    
    // conrtNum - True (корректно)/False (некорректно)
    bool contrNum = int.TryParse(numberStr, out int numN); // numN = 0 (если некорректно)

    if ((contrNum) && (numN > 0)) // обработка корректного значения
    {
        return numN;
    }
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($" Заданное значение ({numberStr}) некорректно!");
    Console.ForegroundColor = ConsoleColor.White;
    return GetNumbIntContr(message);
}

// МЕТОД 2 - ЗАДАНИЯ с клав-ы массива строк
void GetStringArr(string [] diffCh)
{
    int size = diffCh.Length;
    Console.WriteLine($"\n Задайте последовательно {size} строк - элементов массива.");
    
    for (int i = 0; i < size;  i++)
    {
        Console.Write($" Введите значение {i+1}-го элемента массива : ");
        diffCh[i] = Console.ReadLine();
    }
}

// МЕТОД 3 (функция) - ФОРМИРОВАНИЕ нового массива из строк заданного массива,
// длина которых меньше либо равна заданному количеству символов (по умолчанию - 3)
string [] SelLessValueLength(string [] diffCh, int valueLength = 3)
{
    int sizeNew3Ch = 0; // счетчик числа элементов нового массива
    string [] new3Ch = new string [diffCh.Length]; // объявление нового массива

    for (int i = 0; i < diffCh.Length; i++) // цикл по всем элементам заданного массива
    {
        if (diffCh[i].Length <= valueLength)
        {
            new3Ch[sizeNew3Ch] = diffCh[i]; // формирование нового массива с длиной эл-та <= 3
            sizeNew3Ch ++; // увеличение счетчика элементов нового массива
        }
    }

    Array.Resize(ref new3Ch, sizeNew3Ch); // уменьшение размера нового массива до определ.размера
    return new3Ch;
}

// МЕТОД 4 - ВЫВОД на экран передаваемого методу массива строк
void PrintScr(string [] diffCh)
{
    Console.Write(" [ ");
    int length = diffCh.Length;
    for (int i = 0; i < length; i++)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\"");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{diffCh[i]}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\"\t");
        Console.ForegroundColor = ConsoleColor.White;
    }
    Console.Write("]\n");
}


// О С Н О В Н О Й   К О Д

// Очистка экрана
Console.Clear();
Console.WriteLine();

// ЗАДАНИЕ с клав-ы РАЗМЕРА МАССИВА,
// с контролем допустимости задан.данных, вкл.тип значения (Метод 1)
int sizeDiffChar = GetNumbIntContr("элементов массива - натуральное (целое, положительное)" +
                              " \t N: "); // обращение к Методу 1

// ЗАДАНИЕ с клав-ы всех {sizeArr} элементов МАССИВА строк (Метод 2)
string [] diffChar = new string [sizeDiffChar]; // объявление массива строк длиной {sizeArr}
GetStringArr(diffChar); // обращение к Методу 2

// ФОРМИРОВАНИЕ нового массива из строк заданного массива,
// длина которых меньше либо равна 3 символам (Метод 3)
string [] new3Char = SelLessValueLength(diffChar); // обращение к Методу 3

// ВЫВОД на экран всех элементов заданного с клавиатуры МАССИВА строк (Метод 4)
Console.Write($"\n Задан массив строк, состоящий из {diffChar.Length} элемента(ов)," +
               " каждый элемент обрамлен желтыми кавычками :\n");
PrintScr(diffChar); // обращение к Методу 4

// ВЫВОД на экран всех элементов сформированного МАССИВА строк длиной <= 3 (Метод 4)
Console.Write("\n Сформирован новый массив строк (из заданного массива)," +
             $" состоящий из {new3Char.Length} элемента(ов),\n длина каждого <= 3 символам," +
              " каждый элемент обрамлен желтыми кавычками :\n");
PrintScr(new3Char); // обращение к Методу 4

// Задержка экрана
Console.Write("\n Для продолжения нажмите любую клавишу...\n"); //  "\n - "возврат каретки"
Console.Read();
