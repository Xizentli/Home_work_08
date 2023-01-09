/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int[,] matrix = new int[4,4];
int count = 1;

int x0 = 0, xk = 4; //по столбцам
int y0 = 0, yk = 4; //по строкам

//заполняем массив
while(count < 16) 
{
    for (int i = x0; i < xk; i++)
    {
        if(matrix[y0,i] == 0)
        {
            matrix[y0,i] = count++;
        }
    }
    y0++;
    
    for (int i = y0; i < yk; i++)
    {
        if(matrix[i,xk-1] == 0)
        {
            matrix[i,xk-1] = count++;
        }
    }
    xk--;

    for (int i = xk-1; i >= x0; i--)
    {
        if(matrix[yk-1,i] == 0)
        {
            matrix[yk-1,i] = count++;
        }
    }
    yk--;

    for (int i = yk-1; i >= y0; i--)
    {
        if(matrix[i,x0] == 0)
        {
            matrix[i,x0] = count++;
        }
    }
    x0++;
}
//вывод матрицы на консоль
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write($"{matrix[i,j]} ");
    }
    Console.WriteLine();
}

