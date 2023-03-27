// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] CreateMatrixSpiral(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    int countElements = rows * columns;
    int originalCountElements = countElements;
    int countLoop = 0;
    while (countElements > 0)
    {
        for (int i = countLoop; i < matrix.GetLength(1) - countLoop; i++)
        {
            matrix[countLoop, i] = originalCountElements - --countElements;
        }
        for (int i = countLoop + 1; i < matrix.GetLength(0) - countLoop; i++)
        {
            matrix[i, columns - countLoop - 1] = originalCountElements - --countElements;
        }
        if (countElements > 0)
        {
            for (int i = columns - countLoop - 2; i >= countLoop; i--)
            {
                matrix[rows - countLoop - 1, i] = originalCountElements - --countElements;
            }
            for (int i = rows - countLoop - 2; i > countLoop; i--)
            {
                matrix[i, countLoop] = originalCountElements - --countElements;
            }
        }
        countLoop++;
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

int[,] arr2d = CreateMatrixSpiral(4, 4);
Console.WriteLine("Спирально заполненный массив:");
PrintMatrix(arr2d);