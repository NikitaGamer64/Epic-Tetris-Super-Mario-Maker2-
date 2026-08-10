namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public class Position(int row, int column) //3. Класс позиций блоков в игровом поле
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;
    }
}
