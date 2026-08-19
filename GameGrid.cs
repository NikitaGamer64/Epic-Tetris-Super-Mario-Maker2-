namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public class GameGrid(int rows, int columns) //1. Класс игрового поля
    {
        private readonly int[,] grid = new int[rows, columns]; //1.1. Двумерный массив для игрового поля
        public int Rows { get; } = rows; //Возвращает значение строк
        public int Columns { get; } = columns; //Возвращает значение столбцов

        public int this[int r, int c]
        //1.2. Удобная система координат для массива
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public bool IsInside(int r, int c)
        //1.4. Проверить, входит ли строка или столбец в игровое поле
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        //1.5. Проверить, пустая ли ячейка
        {
            return IsInside(r, c) && grid[r, c] == 0;
            //Ячейка должна быть внутри поля, и её значение должно быть 0
        }

        public bool IsRowFull(int r)
        //1.6. Проверить, заполнена ли строка полностью
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

        public bool IsRowEmpty(int r)
        //1.7. Проверить, пуста ли строка
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
        //2. Механизм очистки заполненных строк в тетрисе
        private void ClearRow(int r)
        //2.1. Очищает строку, если она целиком заполнена
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)
        //2.2. Сдвигает вниз строку над очищенной строкой
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        //2.3. Отсчитывает, сколько строк было удалено, и на сколько строк вниз переместятся верхие строки
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            //Проверяем по очереди строки, и если они полны, очищаем их и увеличиваем переменную
            {
                if (IsRowFull(r))
                {
                    cleared++;
                }
                else if (cleared > 0) //Если переменная больше нуля, смещаем строку вниз
                {
                    MoveRowDown(r, cleared);
                }
            }
            //Зачем возвращаем число очищенных строк
            return cleared;
        }
    }
}
