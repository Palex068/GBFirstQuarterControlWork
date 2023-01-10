/* Итоговая проверочная работа
    Задача:
    Написать программу, которая из 
        имеющегося массива строк
        формирует массив из строк, длинна которых 
        меньше либо равна 3 символам.
    Первоначальный массив:
        можно ввести с клавиатуры, либо
        задать на старте выполнения алгоритма.
    При решении не рекомендуется пользоваться коллекциями,
    лучше обойтись исключительно массивами.

    Примеры:

    ["hello", "2", "world", ":-)"] -> ["2",":-)"]
    ["1234", "1567", "-2", "computer science"] -> ["-2"]
    ["Russia", "Denmark", "Kazan"] -> []
*/

string RandomString() // Генерация случайной строки
{
    string str = string.Empty;
    int stringLength = new Random().Next(1, 7);
    int randValue;
    char letter;
    for (int i = 0; i < stringLength; i++)
    {
        randValue = new Random().Next(0, 26);
        letter = Convert.ToChar(randValue + 65);
        str += letter;
    }
    return str;
}

string[] CreateInputArray() // Создаем и заполняем случайными строчными значениями массив
{
    Console.WriteLine("Введите количество элементов начального массива");
    Console.WriteLine("положительное число не более 100): ");
    
    int volume = 0;
    
    while (volume < 1 || volume > 100)
    {
        while (!int.TryParse(Console.ReadLine(), out volume));
    }
    string[] array = new string[volume];
    
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = RandomString();
    }
    return array;
}

string[] ChangeArray(string[] array)    // Создаем массив и заполняем его из переданного массива
                                        // случайными строчными значениями, длинна которых 
                                        // меньше либо равна 3 символам 
{
    int countValue = 0, stringLength = 4;  // Добавил переменную - предел длины строк нового массива
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i].Length < stringLength)
        {
            countValue++;
        }
    }
    string[] newArray = new string[countValue];

    int j = 0;
    for (int i = 0; i < array.Length; i++)
    {        
        if(array[i].Length < stringLength)
        {
            newArray[j] = array[i];
            j++;
        }
    }
    return newArray;
} 

string[] ChangeArrayByList(string[] array) // Решение с использованием списка
{
    List<string> elementsList = new List<string>(array.Length);
    int stringLength = 4;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i].Length < stringLength) 
            elementsList.Add(array[i]);
    }
    string[] newArray = elementsList.ToArray();
    return newArray;
}

string[] ChangeArrayByString(string[] array) // Решение с использованием строки
{
    string elementsString = string.Empty;
    int stringLength = 4;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i].Length < stringLength) 
            if(elementsString == string.Empty)
                elementsString = array[i];
            else elementsString = elementsString + " " + array[i];
    }
    string[] newArray = elementsString.Split(" ").ToArray();
    return newArray;
}

Console.Clear();

string[] firstArray = CreateInputArray();

Console.WriteLine($"\n[{string.Join("\t", firstArray)}]");

string[] secondArray = ChangeArray(firstArray);

Console.WriteLine($"\n[{string.Join("\t", secondArray)}]");

Console.WriteLine($"\n[{string.Join("\t", ChangeArrayByList(firstArray))}]");

Console.WriteLine($"\n[{string.Join("\t", ChangeArrayByString(firstArray))}]");
