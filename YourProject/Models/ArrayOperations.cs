using System;
using System.Collections.Generic;
using System.Linq;

namespace YourProject.Models;

public static class ArrayOperations
{
    public static double[] Parse1DArray(string input)
    {
        return input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
    }

    public static int GetMinIndex(double[] array)
    {
        return Array.IndexOf(array, array.Min());
    }

    public static double SumBetweenNegatives(double[] array)
    {
        var negIndices = array.Select((v, i) => (v, i))
                              .Where(x => x.v < 0)
                              .Select(x => x.i)
                              .ToList();

        return (negIndices.Count >= 2)
            ? array.Skip(negIndices[0] + 1).Take(negIndices[1] - negIndices[0] - 1).Sum()
            : 0;
    }

    public static double[] Transform1D(double[] array)
    {
        return array.Where(x => Math.Abs(x) <= 1).Concat(array.Where(x => Math.Abs(x) > 1)).ToArray();
    }

    public static double[,] Parse2DArray(string input, int rows, int cols)
    {
        var values = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(double.Parse).ToArray();
        if (values.Length != rows * cols)
            throw new Exception("Кількість значень не відповідає розмірам матриці.");

        var result = new double[rows, cols];
        for (int i = 0; i < values.Length; i++)
            result[i / cols, i % cols] = values[i];

        return result;
    }
}
