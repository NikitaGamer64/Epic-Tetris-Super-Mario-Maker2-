
namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public class GameGrid //1. Класс игрового поля
    {
        private readonly int[,] grid; //1.1. Двумерный массив для игрового поля
        public int Rows { get; } //1.1. Возвращает значение строк
        public int Columns { get; } //1.1. Возвращает значение столбцов

        public int this[int r, int c] //1.2. Удобная система координат для массива
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns) //1.3. Инициализация массива
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c) //1.4. Проверить, входит ли строка или столбец в игровое поле
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c) //1.5. Проверить, пустая ли ячейка
        {
            return IsInside(r, c) && grid[r, c] == 0;
            //Ячейка должна быть внутри поля, и её значение должно быть 0
        }

        public bool IsRowFull(int r) //1.6. Проверить, заполнена ли строка полностью
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int r) //1.7. Проверить, пуста ли строка
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }        
    }
}
