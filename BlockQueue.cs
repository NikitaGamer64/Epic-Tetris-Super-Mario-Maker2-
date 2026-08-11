using System;
using System.Collections.Generic;
using System.Text;

namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public class BlockQueue //5. Класс, устанавливающий случайный порядок появления блоков
    {
        private readonly Block[] blocks =
        [
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        ];

        private readonly Random random = new();

        public Block NextBlock { get; private set; }

        public BlockQueue() //Определяет следующий случайный блок
        {
            NextBlock = RandomBlock();
        }

        private Block RandomBlock() //Возвращает случайный блок
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
