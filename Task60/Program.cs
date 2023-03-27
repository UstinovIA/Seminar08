// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// Результат:
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)

int[,,] CreateArray3DRndInt(int rows, int columns, int depth)
{
    int[,,] matrix = new int[rows, columns, depth];
    bool[] usedValue = new bool[100];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k] = GetTwoDigitValue(usedValue);
            }
        }
    }
    return matrix;
}

int GetTwoDigitValue(bool[] usedValues)
{
    Random rnd = new Random();
    int startValue = rnd.Next(10, 100);
    if (usedValues[startValue] == true)
    {
        int startValueLeft = startValue;
        int startValueRight = startValue;
        while (startValueLeft > 10 || startValueRight < 99)
        {
            if (startValueLeft > 10)
            {
                if (usedValues[--startValueLeft] == false)
                {
                    usedValues[startValueLeft] = true;
                    return startValueLeft;
                }
            }
            if (startValueRight < 99)
            {
                if (usedValues[++startValueRight] == false)
                {
                    usedValues[startValueRight] = true;
                    return startValueRight;
                }
            }
        }
        return -1; //Возврат в случае, если значение найти не удалось
    }
    else
    {
        usedValues[startValue] = true;
        return startValue;
    }
}

void PrintArray3D(int[,,] matrix)
{

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i, j, k],2}({i,2},{j,2},{k,2}) ");
            }
        }
        Console.WriteLine();
    }
}

bool CanCreateMatrix(int[,,] matrix)
{
    return matrix.GetLength(0) * matrix.GetLength(1) * matrix.GetLength(2) <= 90;
}

int[,,] arr3d = new int[15, 2, 3];
if (CanCreateMatrix(arr3d))
{
    arr3d = CreateArray3DRndInt(arr3d.GetLength(0), arr3d.GetLength(1), arr3d.GetLength(2));
    Console.WriteLine("Сгенерированный трехмерный массив:");
    PrintArray3D(arr3d);
}
else Console.WriteLine("Невозможно сгенерировать массив с такими размерами");