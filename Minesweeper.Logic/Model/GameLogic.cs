using Minesweeper.Logic.Model.FieldKeys;
using Minesweeper.Logic.Model.Interface;

namespace Minesweeper.Logic.Model;

public class GameLogic : IFieldConfiguration
{
    private readonly int[,] _field;

    private readonly int _rowCount;

    private readonly int _columnCount;

    private readonly int _mineCount;

    public Dictionary<FieldConfigurationsKeys, int> FieldConfigurations { get; set; }

    public FieldConfigurationsKeys FieldConfigurationsKeys { private get; set; }    //delete

    public int CurrentMineCount { get; private set; }

    public GameLogic(Dictionary<FieldConfigurationsKeys, int> fieldConfigurations)
    {
        FieldConfigurations = fieldConfigurations;

        _rowCount = FieldConfigurations[FieldConfigurationsKeys.Row];
        _columnCount = FieldConfigurations[FieldConfigurationsKeys.Column];
        _mineCount = FieldConfigurations[FieldConfigurationsKeys.Mine];

        _field = new int[_rowCount, _columnCount];
        CurrentMineCount = _mineCount;

        SetMines();
    }

    public bool IsMinedCell(int row, int column)
    {
        if (_field[row, column] == 0)
        {
            return false;
        }

        return true;
    }

    public int GetNeighboringMinesCount(int row, int column)
    {
        int startRow = row == 0 ? 0 : row - 1;
        int startColumn = column == 0 ? 0 : column - 1;

        int endRow = row == _field.GetLength(0) ? row : row + 1;
        int endColumn = column == _field.GetLength(1) ? column : column + 1;

        int neighboringCount = 0;

        for (int i = startRow; i < endRow; i++)
        {
            for (int j = startColumn; j < endColumn; j++)
            {
                if (_field[i, j] == (int)FieldCellNumbers.Mine)
                {
                    neighboringCount++;
                }
            }
        }

        return neighboringCount;
    }

    public bool SetFlag(int row, int column)
    {
        if (CurrentMineCount > 0)
        {
            _field[row, column] += 10;
            CurrentMineCount--;

            return true;
        }

        return false;
    }

    public void RemoveFlag(int row, int column)
    {
        _field[row, column] -= 10;
        CurrentMineCount++;
    }

    public bool HasCellFlag(int row, int column)
    {
        if (_field[row, column] >= 10)
        {
            return true;
        }

        return false;
    }

    private void SetMines()
    {
        Random random = new Random();

        int i = 0;

        while (i < _mineCount)
        {
            var x = random.Next(_rowCount);
            var y = random.Next(_columnCount);

            if (_field[x, y] == 0)
            {
                _field[x, y] = 1;
                i++;
            }
            else
            {
                i--;
            }
        }
    }

    public void BreadthFirstSearch()
    {

    }
}