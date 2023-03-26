// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

int SumElementsRow(int[,] matrix, int row)
{
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        sum += matrix[row, i];
    }
    return sum;
}

int MinSumElementsRow(int[,] matrix)
{
    int numberMinRow = 0;
    int valueMinSum = SumElementsRow(matrix, numberMinRow);
    int currentSum = 0;
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        currentSum = SumElementsRow(matrix, i);
        if (valueMinSum > currentSum)
        {
            valueMinSum = currentSum;
            numberMinRow = i;
        }
    }
    return numberMinRow;
}


int[,] arr2d = CreateMatrixRndInt(5, 3, 0, 10);
Console.WriteLine("Текущий массив:");
PrintMatrix(arr2d);
int numMinRow = MinSumElementsRow(arr2d);
//Сдвиг номера строки на +1 для лучшего восприятия пользователя (как и в условии задачи)
Console.WriteLine($"Номер строки с наименьшей суммой элементов -> {numMinRow + 1}"); 
