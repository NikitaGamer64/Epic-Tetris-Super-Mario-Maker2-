namespace Epic_Tetris_Super_Mario_Maker2_
{
    public class Position(int row, int column) //3. Класс позиций блоков в игровом поле
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;
    }
}
