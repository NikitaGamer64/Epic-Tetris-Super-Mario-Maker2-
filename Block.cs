namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public abstract class Block //4. Общий класс для блоков
    {
        //4.1. Информация позиций блока во всех четырёх состояниях вращения
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffSet { get; }
        //4.2. Определяет, в каком состоянии вращения появляется блок
        public abstract int Id { get; }
        //4.3. Определение облика тайла по блоку, в котором он находился при появлении

        private int rotationState;
        private Position offset;
        //4.4. Текущее состояние вращение блока и его текущие позиции

        public Block()
        //В конструкторе делаем положение блока начальным
        {
            offset = new Position(StartOffSet.Row, StartOffSet.Column);
        }

        public IEnumerable<Position> TilePositions() //4.5. Положение блока в игровом поле
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW() //4.6. Повернуть блок по часовой стрелке
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        public void RotateCCW() //4.6. Повернуть блок против часовой стрелки
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns) //4.7. Переместить блок влево или вправо
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset() //4.8. Сбросить положение блока
        {
            rotationState = 0;
            offset.Row = StartOffSet.Row;
            offset.Column = StartOffSet.Column;
        }
    }
}
