// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],3} ");
        }
        Console.WriteLine();
    }
}

void SortRowDesc(int[,] matrix, int row)
{
    bool isNotSorted = true;
    while (isNotSorted)
    {
        isNotSorted = false;
        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            if (matrix[row, i] > matrix[row, i - 1])
            {
                int temp = matrix[row, i];
                matrix[row, i] = matrix[row, i - 1];
                matrix[row, i - 1] = temp;
                isNotSorted = true;
            }
        }
    }
}

void SortAllRowsDesc(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        SortRowDesc(matrix, i);
    }
}

int[,] arr2d = CreateMatrixRndInt(5, 8, -20, 20);
Console.WriteLine("Массив до сортировки:");
PrintMatrix(arr2d);
SortAllRowsDesc(arr2d);
Console.WriteLine("Массив после сортировки:");
PrintMatrix(arr2d);