using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Linq;
using YourProject.Models;

namespace YourProject.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private string oneDimensionalInput = "";
    [ObservableProperty] private string oneDResult = "";

    [ObservableProperty] private string twoDimensionalInput = "";
    [ObservableProperty] private string rowsInput = "";
    [ObservableProperty] private string colsInput = "";
    [ObservableProperty] private string i1 = "";
    [ObservableProperty] private string j1 = "";
    [ObservableProperty] private string i2 = "";
    [ObservableProperty] private string j2 = "";
    [ObservableProperty] private string i3 = "";
    [ObservableProperty] private string j3 = "";
    [ObservableProperty] private string twoDResult = "";

    [RelayCommand]
    private void Process1D()
    {
        try
        {
            var array = ArrayOperations.Parse1DArray(OneDimensionalInput);
            var minIndex = ArrayOperations.GetMinIndex(array);
            var sumBetweenNeg = ArrayOperations.SumBetweenNegatives(array);
            var transformed = ArrayOperations.Transform1D(array);

            OneDResult = $"Індекс мінімального: {minIndex}\n" +
                         $"Сума між першим і другим від’ємними: {sumBetweenNeg}\n" +
                         $"Перетворений масив: {string.Join(" ", transformed)}";
        }
        catch (Exception ex)
        {
            OneDResult = "Помилка: " + ex.Message;
        }
    }

    [RelayCommand]
    private void Process2D()
    {
        try
        {
            int rows = int.Parse(RowsInput);
            int cols = int.Parse(ColsInput);
            double[,] matrix = ArrayOperations.Parse2DArray(TwoDimensionalInput, rows, cols);

            int[] indexes = { int.Parse(I1), int.Parse(J1), int.Parse(I2), int.Parse(J2), int.Parse(I3), int.Parse(J3) };

            double sum2 = matrix[indexes[0], indexes[1]] + matrix[indexes[2], indexes[3]];
            double avg3 = (matrix[indexes[0], indexes[1]] + matrix[indexes[2], indexes[3]] + matrix[indexes[4], indexes[5]]) / 3.0;

            string matrixText = string.Join("\n", Enumerable.Range(0, rows)
                .Select(r => string.Join(" ", Enumerable.Range(0, cols).Select(c => matrix[r, c]))));

            TwoDResult = $"Матриця:\n{matrixText}\n" +
                         $"Сума: {sum2}\nСереднє: {avg3:F2}";
        }
        catch (Exception ex)
        {
            TwoDResult = "Помилка: " + ex.Message;
        }
    }
}
