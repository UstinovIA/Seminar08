// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

bool CanMultiplyMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    return firstMatrix.GetLength(1) == secondMatrix.GetLength(0);
}

int GetValueElement(int[,] firstMatrix, int[,] secondMatrix, int row, int column)
{
    int valueElement = 0;
    for (int i = 0; i < firstMatrix.GetLength(1); i++)
    {
        valueElement += firstMatrix[row, i] * secondMatrix[i, column];
    }
    return valueElement;
}

int[,] MultiplyMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = GetValueElement(firstMatrix, secondMatrix, i, j);
        }
    }
    return result;
}

int[,] firstArray = CreateMatrixRndInt(3, 3, -5, 5);
Console.WriteLine("Первая матрица:");
PrintMatrix(firstArray);
int[,] secondArray = CreateMatrixRndInt(3, 2, -5, 5);
Console.WriteLine("Вторая матрица:");
PrintMatrix(secondArray);
if (CanMultiplyMatrix(firstArray, secondArray))
{
    int[,] resultMultiply = MultiplyMatrix(firstArray, secondArray);
    Console.WriteLine("Результат произведения матриц:");
    PrintMatrix(resultMultiply);
}
else Console.WriteLine("Матрицы невозможно умножить.");
