/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

//метод введения числа с консоли
int GetNumber(string message)
{
    int result = 0;
    while(true)
    {
        Console.WriteLine(message);
        if(int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Введено не число.");
        }
    }
    return result;
}

//метод заполнения двумерной матрицы рандомными числами
int[,] InitMatrix(int indexRow, int indexColumn, int numberRandom)
{
    int[,] matrix = new int[indexRow, indexColumn];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++) //0 - строка
    {
        for (int j = 0; j < matrix.GetLength(1); j++) //1 - столбец
        {
            matrix[i,j] = rnd.Next(1,numberRandom);
        }
    }
    return matrix;
}

//метод вывода матрицы на консоль
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

//метод подсчета суммы элементов матрицы
int GetSumElementsMatrix (int[,] matrix, int numberRandom)
{
    int sumElements = 0; //переменная для подсчета суммы элементов строки
    int indexRowMinSum = 0; //переменная для сохранения индекса строки с наименьшей суммой элементов
    int sum = numberRandom * numberRandom; //присваиваем квадрат числа, используемого для определения рандома
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumElements += matrix[i,j];
        }
        Console.WriteLine($"{i} = {sumElements}");
        if(sumElements < sum)
        {
            sum = sumElements;
            indexRowMinSum = i;
        }
        sumElements = 0; //обнуляем сумму, для подсчета суммы элементов следующей строки
    }
    return indexRowMinSum;
}


int numberRandom = 10; //переменная для определения диапазона максимальных элементов рандома
int indexRow = GetNumber("Введите количество строк: ");
int indexColumn = GetNumber("Введите количество столбцов: ");
int[,] matrix = InitMatrix(indexRow, indexColumn, numberRandom); //инициализация массива
Console.WriteLine("Инициализированная матрица:");
PrintMatrix(matrix);
int indexRowMinSum = GetSumElementsMatrix (matrix, numberRandom);
Console.WriteLine($"Номер строки с наименьшей суммой = {indexRowMinSum+1}"); //отображаем индекс строки с наименьшей суммой 
                                                                             //(для пользователя +1)




