// Задача 57: Составить частотный словарь элементов
// двумерного массива. Частотный словарь содержит
// информацию о том, сколько раз встречается элемент
// входных данных.

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

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i],3} ");
    }
    Console.WriteLine();
}

void PrintFrequencyDictionary(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.WriteLine($"{matrix[i,0]} встречается {matrix[i,1]} раз(а)");
    }
}

int[] ConvertMatrixToArray(int[,] matrix)
{
    int[] array = new int[matrix.Length];
    int k = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[k] = matrix[i, j];
            k++;
        }
    }
    return array;
}

int CountUniqueElements(int[] array)
{
    int value = array[0];
    int count = 1;
    for (int i = 1; i < array.Length; i++)
    {
        if (value != array[i])
        {
            value = array[i];
            count++;
        }
    }
    return count;
}

int[,] FrequencyDictionary(int[] array)
{
    int[,] dictionary = new int[CountUniqueElements(array), 2];
    int value = array[0];
    int count = 1;
    int numberElem = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (value == array[i]) count++;
        else
        {
            dictionary[numberElem, 0] = value;
            dictionary[numberElem, 1] = count;
            value = array[i];
            count = 1;
            numberElem++;
        }
    }
    dictionary[numberElem, 0] = value;
    dictionary[numberElem, 1] = count;
    return dictionary;
}

int[,] arr2d = CreateMatrixRndInt(3, 3, 0, 5);
Console.WriteLine("Исходная матрица:");
PrintMatrix(arr2d);
Console.WriteLine();
int[] arr = ConvertMatrixToArray(arr2d);
Console.WriteLine("Матрица в виде одномерного массива:");
PrintArray(arr);
Console.WriteLine();
Array.Sort(arr);
Console.WriteLine("Матрица в виде отсортированного массива:");
PrintArray(arr);
Console.WriteLine();
int[,] frequencyDictionary = FrequencyDictionary(arr);
PrintFrequencyDictionary(frequencyDictionary);