/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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
int[,] InitMatrix(int indexRow, int indexColumn)
{
    int[,] matrix = new int[indexRow, indexColumn];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++) //0 - строка
    {
        for (int j = 0; j < matrix.GetLength(1); j++) //1 - столбец
        {
            matrix[i,j] = rnd.Next(1,10);
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

//метод копирования изначальной матрицы в новую, для последующих манипуляций с ней
int[,] GetNewMatrix (int[,] matrix)
{
    int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            newMatrix[i,j] = matrix[i,j];
        }
    }
    
    return newMatrix;
}


//метод сортировки
int[,] GetSortArray (int[,] newMatrix)
{
    int[,] newMatrixSort = GetNewMatrix (newMatrix);
       
    for (int i = 0; i < newMatrixSort.GetLength(0); i++)
    {
        for (int j = 0; j < newMatrixSort.GetLength(1) - 1; j++)
        {
            for (int k = j+1; k < newMatrixSort.GetLength(1); k++)
            {
                if(newMatrixSort[i,j] < newMatrixSort[i,k])
                {
                    int temp = newMatrixSort[i,k];
                    newMatrixSort[i,k] = newMatrixSort[i,j];
                    newMatrixSort[i,j] = temp;
                }
                
            }
        }
    }
    return newMatrixSort;
}


//int m = GetNumber("Введите количество строк: ");
//int n = GetNumber("Введите количество столбцов: ");

int[,] matrix = InitMatrix(3, 4);
Console.WriteLine("Первоначальная матрица:");
PrintMatrix(matrix);
int[,] newMatrixSort = GetSortArray (matrix);
Console.WriteLine("Отсортированная матрица:");
PrintMatrix(newMatrixSort);
Console.WriteLine("Первоначальная матрица:");
PrintMatrix(matrix);
