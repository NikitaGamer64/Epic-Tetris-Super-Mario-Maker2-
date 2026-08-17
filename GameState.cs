using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public class GameState
    //6. Класс состояния и механики игры
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public GameState() //6.1. Инициализация сетки игрового поля и порядка блоков
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        private bool BlockFits()
        //6.2. Проверить, находится ли блок в пределах сетки и не перекрывает другие тайлы
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }

            return true;
        }

        public void RotateBlockCW()
        //6.3. Методы вращения и перемещения блоков
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        private bool IsGameOver()
        //6.4. Метод проверки окончания игры
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        private void PlaceBlock()
        //6.5. Метод окончательного размещения блока
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        public void MoveBlockDown()
        //6.6. Метод движения блока вниз
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
    }
}
