using System;

public class Program
{
    public static void Main()
    {
        // Two sample 2x2 matrices to test the class and multiplication method.
        int[,] matrixAValues =
        {
            { 2, 1 },
            { 3, 4 }
        };

        int[,] matrixBValues =
        {
            { 5, 2 },
            { 1, 3 }
        };

        Matrix2D matrixA = new Matrix2D(matrixAValues);
        Matrix2D matrixB = new Matrix2D(matrixBValues);

        // Print both matrices first so it is easy to compare them with the answer.
        Console.WriteLine("Matrix A");
        Console.WriteLine(matrixA.DisplayMatrix());

        Console.WriteLine("Matrix B");
        Console.WriteLine(matrixB.DisplayMatrix());

        // Multiply the two matrices and print the result.
        Console.WriteLine("A x B");
        Console.WriteLine(MatrixMultiplier.multiplies(matrixA, matrixB).DisplayMatrix());

        // Pause so the console does not close straight away.
        Console.WriteLine("Press Enter to close.");
        Console.ReadLine();
    }
}

public class Matrix2D
{
    private readonly int[,] matrixValues;

    public Matrix2D(int[,] valuesToStore)
    {
        // Week 6 assessed task only needs a 2x2 matrix.
        if (valuesToStore.GetLength(0) != 2 || valuesToStore.GetLength(1) != 2)
        {
            throw new ArgumentException("Matrix2D must be 2x2 for this exercise.");
        }

        matrixValues = valuesToStore;
    }

    public int[,] ReturnMatrix()
    {
        // This gives the stored 2D array back to the caller.
        return matrixValues;
    }

    public string DisplayMatrix()
    {
        string output = "";

        // Go through each row and column and build the matrix as text.
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                output += matrixValues[row, column] + " ";
            }

            output += Environment.NewLine;
        }

        return output;
    }
}

public class MatrixMultiplier
{
    public static Matrix2D multiplies(Matrix2D matrixA, Matrix2D matrixB)
    {
        // Get the raw arrays from each Matrix2D object first.
        int[,] aValues = matrixA.ReturnMatrix();
        int[,] bValues = matrixB.ReturnMatrix();
        int[,] resultValues = new int[2, 2];

        // Standard 2x2 matrix multiplication.
        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 2; column++)
            {
                // Each answer comes from one row in A multiplied by one column in B.
                resultValues[row, column] =
                    (aValues[row, 0] * bValues[0, column]) +
                    (aValues[row, 1] * bValues[1, column]);
            }
        }

        // Put the answer back into a Matrix2D object.
        return new Matrix2D(resultValues);
    }
}
