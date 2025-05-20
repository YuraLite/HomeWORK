using System;

class MatrixWrapper
{
    private int[,] matrix;
    private double rmsValue; // середньоквадратичне значення

    public MatrixWrapper(int[,] inputMatrix)
    {
        matrix = inputMatrix;
        rmsValue = CalculateRMS();
    }

    // повертає суму елементів заданого стовпця
    public int this[int columnIndex]
    {
        get
        {
            if (columnIndex < 0 || columnIndex >= matrix.GetLength(1))
                throw new IndexOutOfRangeException("Неправильний індекс стовпця");

            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, columnIndex];
            }
            return sum;
        }
    }

    // Властивість тільки для читання
    public double RMSValue
    {
        get { return rmsValue; }
    }

    // Допоміжний метод для обчислення 
    private double CalculateRMS()
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double sumSquares = 0;
        int count = rows * cols;

        foreach (int value in matrix)
        {
            sumSquares += value * value;
        }

        return Math.Sqrt(sumSquares / count);
    }
}

class Program
{
    static void Main()
    {
        int[,] data = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        MatrixWrapper mw = new MatrixWrapper(data);

        Console.WriteLine("Сума стовпців:");
        for (int i = 0; i < data.GetLength(1); i++)
        {
            Console.WriteLine($"Стовпець {i}: сума = {mw[i]}");
        }

        Console.WriteLine($"\nСередньоквадратичне значення: {mw.RMSValue:F2}");
    }
}
