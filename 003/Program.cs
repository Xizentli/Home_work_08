/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

//метод введения числа с консоли
int GetNumber(string message)
{
    int result = 0;
    while(true)
    {
        Console.Write(message);
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
    Console.WriteLine();
}

//метод умножения одной матрицы на другую
int[,] GetMultiplication(int[,] matrixOne, int [,] matrixTwo)
{
    int[,] multiMatrix = new int[matrixOne.GetLength(0),matrixTwo.GetLength(1)]; //создаем новую матрицу с кол-вом строк равной 
                                                                                //первой матрице, и кол-вол столбцов, равной второй матрице
    for (int i = 0; i < matrixOne.GetLength(0); i++)
    {
        for (int j = 0; j < matrixTwo.GetLength(1); j++)
        {
            for (int k = 0; k < matrixTwo.GetLength(0); k++)
            {
                multiMatrix[i,j] += matrixOne[i,k] * matrixTwo[k,j];
            }
        }
    }
    return multiMatrix;
}

Console.WriteLine();
//определение диапазона максимальных элементов рандома
int numberRandom = 5; 

//инициализация первой матрицы
int indexRowOneMatrix = GetNumber("Введите количество строк первой матрицы: ");
int indexColumnOneMatrix = GetNumber("Введите количество столбцов первой матрицы: ");
int[,] matrixOne = InitMatrix(indexRowOneMatrix, indexColumnOneMatrix, numberRandom); 
Console.WriteLine("Первая матрица:");
PrintMatrix(matrixOne);

//инициализация второй матрицы
int indexRowTwoMatrix = GetNumber("Введите количество строк второй матрицы: ");
int indexColumnTwoMatrix = GetNumber("Введите количество столбцов второй матрицы: ");
int[,] matrixTwo = InitMatrix(indexRowTwoMatrix, indexColumnTwoMatrix, numberRandom); 
Console.WriteLine("Вторая матрица:");
PrintMatrix(matrixTwo);

//проверка: если количество столбцов первой матрицы равна количеству строк второй, то перемножаем матрицы
if(matrixOne.GetLength(1) == matrixTwo.GetLength(0))
{
    int[,] multiMatrix = GetMultiplication(matrixOne, matrixTwo);
    PrintMatrix(multiMatrix);
}
else
{
    Console.WriteLine("Матрицы не совместимы для умножения, "
                    + "т.к. что число столбцов первой матрицы не равно числу строк второй матрицы.");
}





